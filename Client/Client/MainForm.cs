using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;
using System.Text;
using System.Windows.Forms;

using Client;
using Client.etc;
using Client.lib;
using Client.lib.classes;
using Client.lib.interfaces;

namespace Client
{
    //TODO Przeciazanie strumieni wszystkie _setLog i metody "do usuniecia" WON!!!
    //TODO Formatowanie kodu i komentarze

    //BUG cos player nie chce sie renderowac na poczatku
    //jak drugi sie podlaczy to on jest, dopiero trzeba pierwszym ruszyc i sie pokazuje
    public partial class MainForm : Form
    {
        private Map _map;
        private Player _player;

        public MainForm()
        {
            InitializeComponent();

            Log._SetDest(logTxt, this); //Do wywalenia

            _map = new Map(Setting.Map.MaxPlayers, tmpMap);

        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            Log.Clear();

            Log.Add("Wczytywanie ustawien...");

            Setting.Net.Host = txtHost.Text;
            Setting.Net.Port = int.Parse(txtPort.Text);

            Log.Add("Łączenie...");

            _player = new Player(_map);
            _player.Nick = TxtNick.Text;
            _player._setLog(logTxt, this); //Do usuniecia

            if (_player.Connect(Setting.Net.Host, Setting.Net.Port))
            {
                Log.Add("Połączono!");

                #region Tworzenie kolumn i wierszy tego tam komponentu niby do mapy

                for (int i = 0; i < Setting.Map.MaxX; i++)
                {
                    tmpMap.Columns.Add(i.ToString(), i.ToString());
                    tmpMap.Columns[i].Width = Setting.Field.Width;
                }

                for (int i = 0; i < Setting.Map.MaxY; i++)
                {
                    tmpMap.Rows.Add();
                    tmpMap.Rows[i].Height = Setting.Field.Height;
                }
                #endregion

                _map.Render();
                _player.Render();

                tmpMap.Focus();
            }
            else
            {
                Log.Add("Nie połączono!");
            }

        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            Log.Add("Rozłączono");
            _player.Disconnect();
        }

        private void tmpMap_KeyDown(object sender, KeyEventArgs e)
        {
            ISkill o = (ISkill)Skill.List[MsgS.Move];

            _player.Clear();
            o.Action(_player, e.KeyCode);
            _player.Render();
        }

    }
}
