using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Client.lib.classes
{

    //Tutaj konstruktory sa do dupy
    //Przeciazona klasa strumienia odczytujacego
    //przeciazone jest funkcja readstring ktora wyswietla wszystko w richboxie
    public class sReader : BinaryReader, Client.lib.interfaces.IObject
    {

        public List<String> ReadLog { get; set; }

        #region Do wywalenia
        private RichTextBox _log; //Do wywalenia
        private Form _form; //Do wywalenia
        private String _lastString; //do wywalenia
        delegate void SetTextCallback(string Text); //To tez nie potrzeba
        public void _setLog(RichTextBox Log, Form Form) //Do usuniecia
        {
            _log = Log;
            _form = Form;
        }
        #endregion

        public sReader(Stream Input) : base(Input)
        {
            ReadLog = new List<string>();
        }

        //Tutaj przeciazam
        public override string ReadString()
        {
            try
            {
                string s = base.ReadString();

                _lastString = "<<" + s; //Do wywalenia
                Add("<<" + s);  //Do wywalenia

                ReadLog.Add(s);

                //Render(); //Tu bedzie render finalnie ale teraz przez to ze nie moge modyfikowac controlki na formie z innego watki jest zakomentowane
                return s;
            }
            catch (IOException ie)
            {
                Log.Error(ie.Message);
                return null;
            }

        }

        #region IObject Members

        public void Render()
        {
            this._log.SelectionFont = new Font(this._log.Font.FontFamily, this._log.Font.Size, FontStyle.Bold);
            this._log.AppendText(String.Format("{0:HH:mm:ss} : ", DateTime.Now));
            this._log.SelectionFont = new Font(this._log.Font.FontFamily, this._log.Font.Size, FontStyle.Regular);
            this._log.AppendText(_lastString + "\n");
            this._log.ScrollToCaret();
        }

        public void Clear()
        {
            ReadLog.Clear();
        }

        #endregion

        #region Do wywalenia
        public void Add(string Text)
        {
            if (this._log.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                _form.Invoke(d, new object[] { Text });
            }
            else
            {
                Render();
            }

        }

        private void SetText(string Text)
        {
            if (this._log.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                _form.Invoke(d, new object[] { Text });
            }
            else
            {
                Render();
            }

        }
        #endregion
    }

    //Przeciazona klasa strumienia piszacego
    //przeciazone jest funkcja write ktora wyswietla wszystko w richboxie
    public class sWriter : BinaryWriter, Client.lib.interfaces.IObject
    {

        public List<String> WriteLog { get; set; }

        #region Do wywalenia
        private RichTextBox _log; //Do wywalenia
        private Form _form; //Do wywalenia
        private String _lastString; //do wywalenia
        delegate void SetTextCallback(string Text); //To tez nie potrzeba
        public void _setLog(RichTextBox Log, Form Form) //Do usuniecia
        {
            _log = Log;
            _form = Form;
        }
        #endregion

        public sWriter(Stream Output) : base(Output)
        {
            WriteLog = new List<string>();
        }

        //Tutaj przeciazam
        public override void Write(string value)
        {
            _lastString = ">>" + value; //Do wywalenia
            Add(">>" + value); //Do wywalnie

            WriteLog.Add(value);
            base.Write(value);

            //Render();
        }

       
        #region IObject Members

        public void Render()
        {
            this._log.SelectionFont = new Font(this._log.Font.FontFamily, this._log.Font.Size, FontStyle.Bold);
            this._log.AppendText(String.Format("{0:HH:mm:ss} : ", DateTime.Now));
            this._log.SelectionFont = new Font(this._log.Font.FontFamily, this._log.Font.Size, FontStyle.Regular);
            this._log.AppendText(_lastString + "\n");
            this._log.ScrollToCaret();
        }

        public void Clear()
        {
            WriteLog.Clear();
        }

        #endregion

        #region Do wywalenia
        public void Add(string Text)
        {
            if (this._log.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                _form.Invoke(d, new object[] { Text });
            }
            else
            {
                Render();
            }

        }

        private void SetText(string Text)
        {
            if (this._log.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                _form.Invoke(d, new object[] { Text });
            }
            else
            {
                Render();
            }

        }
        #endregion
    }


    //To jest Singleton
    //Trzeba go przerobic bo teraz sztywno wali w richtextboxa
    //Najlepiej by bylo dać jakaś liste stringów co by miała eventa onChange
    //i w tym onChange mozna by było zmieniać co sie chce czy to richBoxa czy wywalac na ekran opengl
    public sealed class Log
    {
        static private RichTextBox _log;
        static private Form _form;

        delegate void SetTextCallback(string Text);

        static Log instance = null;
        static readonly object padlock = new object();

        static Log()
        {
        }

        Log()
        {
        }

        #region IObject Members

        public static void Render()
        {
        }

        public static void Clear()
        {
            _log.Clear();
        }

        #endregion

        public static Log Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new Log();
                    }
                    return instance;
                }
            }
        }

        //chujowe trzeba to zmienic
        public static void _SetDest(RichTextBox dest, Form Form)
        {
            _log = dest;
            _form = Form;
        }

        public static void Error(string Text)
        {
            Add("Bład! " + Text);
        }

        public static void Add(string Text)
        {
            if (_log.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                _form.Invoke(d, new object[] { Text });
            }
            else
            {
                _log.SelectionFont = new Font(_log.Font.FontFamily, _log.Font.Size, FontStyle.Bold);
                _log.AppendText(String.Format("{0:HH:mm:ss} : ", DateTime.Now));
                _log.SelectionFont = new Font(_log.Font.FontFamily, _log.Font.Size, FontStyle.Regular);
                _log.AppendText(Text + "\n");
                _log.ScrollToCaret();
            }

        }

        private static void SetText(string Text)
        {
            if (_log.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                _form.Invoke(d, new object[] { Text });
            }
            else
            {
                _log.SelectionFont = new Font(_log.Font.FontFamily, _log.Font.Size, FontStyle.Bold);
                _log.AppendText(String.Format("{0:HH:mm:ss} : ", DateTime.Now));
                _log.SelectionFont = new Font(_log.Font.FontFamily, _log.Font.Size, FontStyle.Regular);
                _log.AppendText(Text + "\n");
                _log.ScrollToCaret();
            }

        }


    }
}