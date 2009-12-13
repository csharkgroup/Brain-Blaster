using System;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text;

using Serwer.etc;
using Serwer.lib.classes;
using Serwer.lib.interfaces;

namespace Serwer.lib.classes.skills
{
    class Move : ISkill
    {
        #region ISkill Members

        public StringCollection Commands
        {
            get;
            set;
        }

        public void Action(Player Player, string[] cmd)
        {
            Player.X = int.Parse(cmd[2]);
            Player.Y = int.Parse(cmd[3]);

            Player.Map.SendToAll(cmd[0] + "|" + cmd[1] + "|" + cmd[2] + "|" + cmd[3]);

        }

        #endregion

        public Move()
        {
            Commands = new StringCollection();
            Commands.Add(MsgS.Move);
        }
    }
}
