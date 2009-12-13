using System;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.Text;

using Serwer.etc;
using Serwer.lib.classes;
using Serwer.lib.interfaces;

namespace Serwer.lib.classes.skills
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

            switch (cmd[0])
            {
                case MsgC.GetID:
                    Player.WriteS.Write(MsgS.SetID + "|" + Player.Index.ToString());
                    Player.WriteS.Write(MsgS.MapSetting + "|" + Setting.Map.MaxX.ToString() + "|" + Setting.Map.MaxY.ToString() + "|" + Setting.Map.MaxPlayers.ToString());

                    Player.X = Setting.Position.Pos[Player.Index, 0];
                    Player.Y = Setting.Position.Pos[Player.Index, 1];

                    Player.Map.SendToAll(
                        MsgS.Join + "|" + Player.Index.ToString() + "|" + Player.X.ToString() + "|" +
                                Player.Y.ToString(), Player.Index
                    );


                    for (int i = 0; i < Player.Index && i != Player.Index; i++)
                    {
                        Player.WriteS.Write(
                            MsgS.Move + "|" + i.ToString() + "|" + Player.Map.Players[i].X.ToString() + "|" +
                                Player.Map.Players[i].Y.ToString()
                        );
                    }

                break;
                case MsgC.SetNick:

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

                    Player.Nick = cmd[2];

                    Player.Map.SendToAll(MsgS.GetNick + "|" + Index.ToString() + "|" + Player.Nick, Index);

                    for (int i = 0; i < Player.Map.Index && i != Player.Index; i++)
                    {
                            Player.WriteS.Write(MsgS.GetNick + "|" + i.ToString() + "|" +
                                Player.Map.Players[i].Nick);
                    }

                    Player.WriteS.Write(MsgS.Move + "|" + Index.ToString() + "|" + Player.X.ToString() + "|" +
                        Player.Y.ToString());

                    break;

            }
        }

        #endregion

        public Join()
        {
            Commands = new StringCollection();
            Commands.Add(MsgC.GetID);
            Commands.Add(MsgC.SetNick);
        }
    }
}
