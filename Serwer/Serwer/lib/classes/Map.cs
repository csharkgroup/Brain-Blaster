using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;

using Serwer.etc;
using Serwer.lib.interfaces;

namespace Serwer.lib.classes
{
    public class Map
    {
        public Player[] Players { get; set; }
        public int Index { get; set; }

        public Map()
        {
            Players = new Player[Setting.Map.MaxPlayers];
            Index = 0;

        }

        public void SendToAll(String cmd)
        {
            SendToAll(cmd, -1);

        }

        public void SendToAll(String cmd, int Index)
        {
            for (int i = 0; i < this.Index && i != Index && Players[i].Client.Connected; i++)
            {
                    Players[i].WriteS.Write(cmd);
            }

        }

        public void AddPlayer(Player Player)
        {
            if (Index < Setting.Map.MaxPlayers)
            {
                Player.Index = Index;
                Players[Index++] = Player;
            }
        }

    }
}
