using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;

using Serwer.etc;
using Serwer.lib.interfaces;

namespace Serwer.lib.classes.skills
{
    class Bomb : ISkill
    {
        #region ISkill Members

        public StringCollection Commands
        {
            get;
            set;
        }

        public void Action(Player Player, string[] cmd)
        {
            switch (cmd[0])
            {
                case MsgC.SetBomb:
                    TimeObject t = new TimeObject(Player, new string[] { MsgS.Bomb, cmd[1], cmd[2] }, Setting.Map.BombDelay);
                    Timer.Queue.Enqueue(t);
                    Player.Map.SendToAll(MsgS.SetBomb + "|" + cmd[1] + "|" + cmd[2]);
                    break;
                case MsgC.Bomb:
                    Player.Map.SendToAll(MsgS.Bomb + "|" + cmd[1] + "|" + cmd[2]);
                    break;
            }
        }

        #endregion

        public Bomb()
        {
            Commands = new StringCollection();
            Commands.Add(MsgC.SetBomb);
            Commands.Add(MsgC.Bomb);
        }
    }
}
