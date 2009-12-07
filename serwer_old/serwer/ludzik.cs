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
using serwer;

namespace serwer
{
    class ludzik
    {
        private ludzik[] _l;

        public TcpClient Client { get; set; }
        private Thread _readT;

        public sReader readS { get; set; }
        public sWriter writeS { get; set; }

        public int X { set; get; }
        public int Y { set; get; }
        public char C { set; get; }

        public ludzik(TcpClient Client, sReader readS, sWriter writeS, ludzik[] L, int x, int y, bool Run)
        {
            _l = L;
            this.Client = Client;

            NetworkStream stream = Client.GetStream();

            this.readS = readS;
            this.writeS = writeS;
            this.X = x;
            this.Y = y;

            if (Run)
            {
                _readT = new Thread(new ThreadStart(reader));
                _readT.Start();
            }
        }

        public void action(string[] data)
        {
            int bIndex = 0;

            try
            {
                bIndex = int.Parse(data[1]);

            }
            catch (FormatException fe)
            {

            }

            switch(data[0])
            {
                case MsgS.Move:

                    this.X = int.Parse(data[2]);
                    this.Y = int.Parse(data[3]);

                    for (int i = 0; i < _l.Length; i++)
                    {
                        if ((_l[i] != null) && (_l[i].Client.Connected) && (i != bIndex))
                        {
                            _l[i].writeS.Write(MsgS.Move + "|" + data[1] + "|" + data[2] + "|" + data[3]);
 
                        }
                    }
                break;
                case MsgC.SetNick:

                    this.C = data[2][0];

                    for (int i = 0; i < _l.Length; i++)
                    {
                        if ((_l[i] != null) && (_l[i].Client.Connected) && (i != bIndex) )
                        {
                            _l[i].writeS.Write(MsgS.GetNick + "|" + bIndex.ToString() + "|" + _l[bIndex].C.ToString());
                        }
                    }

                    for (int i = 0; i < _l.Length; i++)
                    {
                        if ((_l[i] != null) && (_l[i].Client.Connected) && (i != bIndex))
                        {
                            writeS.Write(MsgS.GetNick + "|" + i.ToString() + "|" + _l[i].C.ToString());
                        }
                    }

                    writeS.Write(MsgS.Move + "|" + bIndex.ToString() + "|" + X.ToString() + "|" + Y.ToString());

                break;
            }
        }

        public void reader()
        {
            string buf;
            string[] data;
            try
            {
                while ((buf = readS.ReadString()) != MsgC.Disconnect)
                {
                    data = buf.Split('|');
                    action(data);
                }
            }catch(IOException ie){
                
            };
        }
    }
}
