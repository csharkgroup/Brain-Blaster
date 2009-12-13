using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;

using Serwer;
using Serwer.etc;
using Serwer.lib;
using Serwer.lib.classes;
using Serwer.lib.interfaces;

namespace Serwer
{
    public partial class MainForm : Form
    {

        private Map _map;

        private TcpListener _listener = null;
        private Thread _readT;

        public MainForm()
        {
            InitializeComponent();

            _map = new Map();
            Serwer.lib.classes.Timer.Start();

            Log._SetDest(logTxt, this); //Do wywalenia
        }

        //Procedura wykonujaca przez watek nasluchujacy serwera
        private void Reader()
        {
            while (_map.Index < Setting.Map.MaxPlayers)
            {
                TcpClient Client = _listener.AcceptTcpClient();
                NetworkStream stream = Client.GetStream();
                
                sWriter writeS = new sWriter(stream);
                sReader readS = new sReader(stream);

                writeS._setLog(logTxt, this); //Do usuniecia
                readS._setLog(logTxt, this); //Do usuniecia

                string buf = readS.ReadString();
                string[] data = buf.Split('|');

                if (data[0] == MsgC.GetID)
                {
                    Player p = new Player(_map);

                    p.ReadS = readS;
                    p.WriteS = writeS;
                    p.Client = Client;

                    _map.AddPlayer(p);

                    ISkill o = (ISkill)Skill.List[MsgC.GetID];
                    o.Action(p, data);

                }
                
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            Log.Clear();

            Log.Add("Wczytywanie ustawien...");

            Setting.Net.Host = txtIP.Text;
            Setting.Net.Port = int.Parse(txtPort.Text);

            Setting.Map.MaxX = int.Parse(txtMapMaxX.Text);
            Setting.Map.MaxY = int.Parse(txtMapMaxY.Text);
            Setting.Map.MaxPlayers = int.Parse(txtMapMaxPlayers.Text);
            Setting.Map.Rate = int.Parse(txtMapRateW.Text) / int.Parse(txtMapRateH.Text);

            Log.Add("Uruchamianie serwera...");

            try
            {
                _listener = new TcpListener(IPAddress.Parse(Setting.Net.Host), Setting.Net.Port);
                _listener.Start();

                _readT = new Thread(new ThreadStart(Reader));
                _readT.Start();
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
            }
            
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            _readT.Suspend();
            _listener.Stop();
            
            Log.Add("Zatrzymano Serwer");
        }
    }
}
