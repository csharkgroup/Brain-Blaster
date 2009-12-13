using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.Threading;

using Client.etc;
using Client.lib.interfaces;

namespace Client.lib.classes.skills
{
    class Bomb : ISkill
    {
        #region ISkill Members

        public StringCollection Commands
        {
            get;
            set;
        }

        public void Action(Player Player, System.Windows.Forms.Keys k)
        {
            Player.WriteS.Write(MsgC.SetBomb + "|" + Player.X.ToString() + "|" + Player.Y.ToString());
        }

        public void Action(Player Player, string[] cmd)
        {
            switch (cmd[0])
            {
                case MsgS.SetBomb:
                    Player.Map._Map.Rows[int.Parse(cmd[2])].Cells[int.Parse(cmd[1])].Value = 'O';
                    break;
                case MsgS.Bomb:
                    Explode(Player, int.Parse(cmd[1]), int.Parse(cmd[2]));
                    break;
            }
        }

        #endregion

        private void Explode(Player Player, int X, int Y)
        {

            int x, y;

            for (int i = 0; i < Player.ExplodeSize; i++)
            {
                Thread.Sleep(100);

                if (X % 2 == 0)
                {
                    y = Y - i > 0 ? Y - i : Y; x = X;
                    Player.Map._Map.Rows[y].Cells[x].Value = 'Q';

                    y = Y + i < Setting.Map.MaxY ? Y + i : Y; x = X;
                    Player.Map._Map.Rows[y].Cells[x].Value = 'Q';
                }

                if (Y % 2 == 0)
                {
                    y = Y; x = X - i > 0 ? X - i : X;
                    Player.Map._Map.Rows[y].Cells[x].Value = 'Q';

                    y = Y; x = X + i < Setting.Map.MaxX ? X + i : X;
                    Player.Map._Map.Rows[y].Cells[x].Value = 'Q';
                }
            }

            for (int i = 0; i < Player.ExplodeSize; i++)
            {
                if (X % 2 == 0)
                {
                    y = Y - i > 0 ? Y - i : Y; x = X;
                    Player.Map._Map.Rows[y].Cells[x].Value = "";

                    y = Y + i < Setting.Map.MaxY ? Y + i : Y; x = X;
                    Player.Map._Map.Rows[y].Cells[x].Value = "";
                }

                if (Y % 2 == 0)
                {
                    y = Y; x = X - i > 0 ? X - i : X;
                    Player.Map._Map.Rows[y].Cells[x].Value = "";

                    y = Y; x = X + i < Setting.Map.MaxX ? X + i : X;
                    Player.Map._Map.Rows[y].Cells[x].Value = "";
                }
            }

            //Player.Map._Map.Rows[Y - i + 1].Cells[X].Value = "";
            //Player.Map._Map.Rows[Y + i - 1].Cells[X].Value = "";
            //Player.Map._Map.Rows[Y].Cells[X - i + 1].Value = "";
            //Player.Map._Map.Rows[Y].Cells[X + i - 1].Value = "";
        }

        public Bomb()
        {
            Commands = new StringCollection();
            Commands.Add(MsgS.SetBomb);
            Commands.Add(MsgS.Bomb);
        }
    }
}
