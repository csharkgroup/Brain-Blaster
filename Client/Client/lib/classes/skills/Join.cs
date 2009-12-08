using System;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.Text;

using Client.etc;
using Client.lib.interfaces;

namespace Client.lib.classes.skills
{
    class Join : ISkill
    {
        #region ISkill Members

        public StringCollection Commands
        {
            get;
            set;
        }

        public void Action(Player Player, string[] cmd)
        {
            int Index = 0;

            try
            {
                Index = int.Parse(cmd[1]);

            }
            catch (FormatException fe)
            {
                Log.Error(fe.Message);
                return;
            }

            switch (cmd[0])
            {
                case MsgS.Join:
                    int x, y;

                    x = int.Parse(cmd[2]);
                    y = int.Parse(cmd[3]);

                    Player p = new Player(Player.Map);

                    Player.Map.AddPlayer(p);

                    ISkill skill = (ISkill)Skill.List[MsgS.Move];
                    skill.Action(p, new string[] { MsgS.Move, cmd[1], cmd[2], cmd[3] });

                    break;
                case MsgS.GetNick:
                    Player.Map.Players[Index].Nick = cmd[2];
                    Player.Map.Players[Index].Render();
                    break;

            }
        }

        public string[] Translate(Player Player, System.Windows.Forms.Keys k)
        {
            throw new NotImplementedException();
        }

        #endregion

        public Join()
        {
            Commands = new StringCollection();
            Commands.Add(MsgS.Join);
            Commands.Add(MsgS.GetNick);
        }
    }
}
