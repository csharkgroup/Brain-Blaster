using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace serwer
{
    class sReader : BinaryReader
    {
        RichTextBox _r;
        Form _f;

        delegate void SetTextCallback(string text);

        public sReader(RichTextBox r, Form f, Stream Input) : base(Input)
        {
            _r = r;
            _f = f;
        }

        public override string ReadString()
        {
            string s = base.ReadString();
            wyswietl(s);
            return s;
        }

        public void wyswietl(string text)
        {
            if (this._r.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                _f.Invoke(d, new object[] { text });
            }
            else
            {
                this._r.AppendText(text + "\n");
                this._r.ScrollToCaret();
                //this.logTxt.Focus();
            }

        }

        private void SetText(string text)
        {
            if (this._r.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                _f.Invoke(d, new object[] { text });
            }
            else
            {
                this._r.AppendText(text + "\n");
                this._r.ScrollToCaret();
                //this.logTxt.Focus();
            }

        }
    }

    class sWriter : BinaryWriter
    {
        RichTextBox _r;
        Form _f;

        delegate void SetTextCallback(string text);

        public sWriter(RichTextBox r, Form f, Stream Output): base(Output)
        {
            _r = r;
            _f = f;
        }

        public override void  Write(string value)
        {
             wyswietl(value);
 	         base.Write(value);
        }

        public void wyswietl(string text)
        {
            if (this._r.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                _f.Invoke(d, new object[] { text });
            }
            else
            {
                this._r.AppendText(text + "\n");
                this._r.ScrollToCaret();
                //this.logTxt.Focus();
            }

        }

        private void SetText(string text)
        {
            if (this._r.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                _f.Invoke(d, new object[] { text });
            }
            else
            {
                this._r.AppendText(text + "\n");
                this._r.ScrollToCaret();
                //this.logTxt.Focus();
            }

        }
    }

    class log
    {
    }
}
