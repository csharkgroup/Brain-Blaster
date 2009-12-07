using System;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text;
using System.Drawing;

using Client.etc;
using Client.lib.interfaces;

namespace Client.lib.classes.skills
{
    class Move : ISkill
    {
        #region ISkill Members

        public StringCollection Commands
        {
            get;
            set;
        }

        public void Action(Player Player, Keys k)
        {
            int x, y;

            x = Player.X;
            y = Player.Y;

            switch (k)
            {
                case Keys.Left: x += x == 0 ? 0 : -1; break;
                case Keys.Right: x += x == 32 ? 0 : 1; break;
                case Keys.Up: y += y == 0 ? 0 : -1; break;
                case Keys.Down: y += y == 18 ? 0 : 1; break;
            }

            if (!(x % 2 == 1 && y % 2 == 1))
            {
                Player.X = x;
                Player.Y = y;
            }
            Player.WriteS.Write(MsgC.Move + "|" + Player.Index.ToString() + "|" + Player.X.ToString() + "|" + Player.Y.ToString());            
        }

        public void Action(Player Player, string[] cmd)
        {
            int index = int.Parse(cmd[1]);
            Player p = Player.Map.Players[index];

            p.Clear();

            p.X = int.Parse(cmd[2]);
            p.Y = int.Parse(cmd[3]);

            p.Render();
        }

        #endregion

        public Move()
        {
            Commands = new StringCollection();
            Commands.Add(MsgS.Move);
        }
    }
}
