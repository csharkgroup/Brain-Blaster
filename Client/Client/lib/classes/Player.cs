using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;
using System.Drawing;

using Client.etc;
using Client.lib.interfaces;
using Client.lib.classes;
using Client.lib;

namespace Client.lib.classes
{
    public class Player : IObject, IField
    {

        public RichTextBox txtLog { get; set; }
        public Form Form { get; set; }

        public string Nick;
        public Map Map;

        private TcpClient _client = null;

        private sReader _readS = null;
        public sWriter WriteS { get; set; }

        private Thread _readT = null;

        public int Index { get; set; }

        public Player(Map Map)
        {
            this.Map = Map;
        }

        #region IField Members

        public int X { get; set; }

        public int Y { get; set; }

        #endregion

        #region IObject Members

        public void Render()
        {
            char n = Nick == null ? 'O' : Nick[0];

            Map._Map.Rows[Y].Cells[X].Value = n;
            Map._Map.Rows[Y].Cells[X].Style.BackColor = Color.Yellow;
        }

        public void Clear()
        {
            Map._Map.Rows[Y].Cells[X].Value = "";
            Map._Map.Rows[Y].Cells[X].Style.BackColor = Color.White;
        }

        #endregion

        #region Net


        //Do usuniecia
        public void _setLog(RichTextBox txtLog, Form Form)
        {
            this.txtLog = txtLog;
            this.Form = Form;
        }

        //To jest do dupy przekazywanie richTextBoxa i Form do logowania tak nie moze byc
        //Trzeba by bylo sie zastanowic czy czasem to pobieranie id i wysylanie nicka innym nie da jako osobny skill
        //i tego skila opakowac w jakiegos wiekszego skilla ktory jeszcze by pobieral mape 
        public bool Connect(string Host, int Port)
        {
            try
            {
                _client = new TcpClient();
                _client.Connect(Host, Port);

                if (!_client.Connected)
                {
                    return false;
                }

                NetworkStream stream = _client.GetStream();

                WriteS = new sWriter(stream);
                _readS = new sReader(stream);

                WriteS._setLog(this.txtLog, this.Form); //Do usuniecia
                _readS._setLog(this.txtLog, this.Form); //Do usuniecia

                WriteS.Write(MsgC.GetID);

                string buf;
                string[] data;

                buf = _readS.ReadString();

                data = buf.Split('|');

                if (data[0] == MsgS.SetID)
                {

                    Index = int.Parse(data[1]);

                    for (int i = 0; i < Index; i++)
                    {
                        Map.AddPlayer(new Player(Map));
                    }

                    Map.AddPlayer(this);

                    WriteS.Write(MsgC.SetNick + "|" + Index.ToString() + "|" + Nick);

                    _readT = new Thread(new ThreadStart(Reader));
                    _readT.Start();
                }
                else
                {
                    if (_client != null)
                    {
                        _client.Close();
                        Log.Add("Błąd połączenia!");
                    }
                }

            }
            catch (SocketException se)
            {
                Log.Add("Błąd!" + se.Message);
                return false;
            }
            return true;
        }

        public void Disconnect()
        {
            WriteS.Write(MsgC.Disconnect);
        }

        #endregion

        //Lista akcj po odebraniu komunikatu od serwera do wykonania
        private void action(string[] data)
        {
            ISkill skill = (ISkill)Skill.List[data[0]];
            skill.Action(this, data);
        }


        //funkcja wykonywana w watku czytajaca wiadomosc od serwera
        private void Reader()
        {
            string buf = "";
            string[] data;
            while (buf != MsgS.Disconnect)
            {
                try
                {
                    buf = _readS.ReadString();
                    data = buf.Split('|');
                    action(data);
                }
                catch (NullReferenceException ne)
                {
                    Log.Error(ne.Message);
                    return;
                }
            }
        }
    }
}
