using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

using Client.etc;
using Client.lib.interfaces;

namespace Client.lib.classes
{
    public class Map : IObject
    {
        public Player[] Players { get; set; }
        public int Index { get; set; }

        #region Do usuniecia
        public DataGridView _Map { get; set; } //Do usuniecia
        private bool _firtRender; //Do usuniecia robi X na pozycjach

        public void _setMap(DataGridView Map)
        {
            _Map = Map;
        }
        #endregion

        public Map()
        {
            Players = new Player[Setting.Map.MaxPlayers];
            Index = 0;

            _firtRender = true;

        }

        public void AddPlayer(Player Player)
        {
            if (Index < Setting.Map.MaxPlayers)
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
