using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;
using Msg;
using Settings;

namespace serwer
{
    public partial class Form1 : Form
    {
        private ludzik[] _l;
        private int _index;

        private TcpListener _listener = null;

        private Thread _readT;

        private PosSetting _posS;

        public Form1()
        {
            InitializeComponent();
            
            _l = new ludzik[4];
            _index = 0;

            _posS = new PosSetting(18, 18);

            _listener = new TcpListener(IPAddress.Parse(InetSetting.Host), InetSetting.Port);
            _listener.Start();

            _readT = new Thread(new ThreadStart(reader));
            _readT.Start();

        }


        private void action(TcpClient Client)
        {
            NetworkStream stream = Client.GetStream();

            sWriter writeS = new sWriter(logTxt, this, stream);
            sReader readS = new sReader(logTxt, this, stream);

            string buf = readS.ReadString();
            string[] data = buf.Split('|');


            switch (data[0])
            {
                case MsgC.GetID:

                    writeS.Write(MsgS.SetID + "|" + _index.ToString());

                    int x = _posS.Pos[_index, 0];
                    int y = _posS.Pos[_index, 1];

                    for (int i = 0; i < _index; i++)
                    {
                        _l[i].writeS.Write(
                            MsgS.Join + "|" + _index.ToString() + "|" + x.ToString() + "|" + y.ToString()
                        );

                    }

                    for (int i = 0; i < _index; i++)
                    {
                        writeS.Write(
                            MsgS.Move + "|" + i.ToString() + "|" + _l[i].X.ToString() + "|" + _l[i].Y.ToString()
                        );
                    }

                    _l[_index++] = new ludzik(Client, readS, writeS, _l, x, y, true);


                    break;

            }

        }

        public void reader()
        {
            while(_index < 4)
            {
                TcpClient Client = _listener.AcceptTcpClient();
                action(Client);
            }
        }

    }
}
