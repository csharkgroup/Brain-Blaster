using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;

using Serwer.etc;
using Serwer.lib.interfaces;

namespace Serwer.lib.classes
{
    public class Player : IField
    {
        public RichTextBox txtLog { get; set; }
        public Form Form { get; set; }

        public string Nick;
        public Map Map;

        public sReader ReadS { get; set; }
        public sWriter WriteS { get; set; }
        public TcpClient Client { get; set; }

        private Thread _readT = null;

        public int Index { get; set; }

        public Player(Map Map)
        {
            this.Map = Map;

            _readT = new Thread(new ThreadStart(Reader));
            _readT.Start();
        }

        #region IField Members

        public int X { get; set; }

        public int Y { get; set; }

        #endregion

        #region Net

        //Do usuniecia
        public void _setLog(RichTextBox txtLog, Form Form)
        {
            this.txtLog = txtLog;
            this.Form = Form;
        }

        public void Disconnect()
        {
            WriteS.Write(MsgS.Disconnect);
        }

        #endregion

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
            while (buf != MsgC.Disconnect)
            {
                try
                {
                    buf = ReadS.ReadString();
                    data = buf.Split('|');
                    action(data);
                }
                catch (NullReferenceException ne)
                {
                    Log.Error(ne.Message);
                    //return;
                }
            }
        }
    }
}
