using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

using Client.lib.interfaces;

namespace Client.lib.classes
{
    public class Map : IObject
    {
        public Player[] Players { get; set; }
        public DataGridView _Map { get; set; } //Do usuniecia

        public int Index 
        { 
            get;
            set;
        }

        private int _maxPlayers; //Do usuniecia
        private bool _firtRender; //Do usuniecia robi X na pozycjach

        public Map(int MaxPlayers, DataGridView Map)
        {
            Players = new Player[MaxPlayers];

            _maxPlayers = MaxPlayers;
            _firtRender = true;

            Index = 0;

            _Map = Map;
        }

        public void AddPlayer(Player Player)
        {
            if (Index < _maxPlayers)
            {
                Player.Index = Index;
                Players[Index++] = Player;
            }
        }

        #region IObject Members

        public void Clear()
        {
            for (int i = 0; i < Index; i++)
            {
                Players[i].Clear();
            }
        }

        public void Render()
        {
            if (_firtRender)
            {
                for (int i = 1; i < _Map.ColumnCount; i += 2)
                {
                    for (int j = 1; j < _Map.RowCount; j += 2)
                    {
                        _Map.Rows[j].Cells[i].Value = 'X';
                    }
                }
            }

            for (int i = 0; i < Index; i++)
            {
                Players[i].Render();
            }
        }

        #endregion
    }
}
