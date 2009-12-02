using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OpenGL;

namespace GameClient
{
    public partial class Form1 : Form
    {
        GLRenderer glr;
        Mapa map;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            glr = new GLRenderer();
            if(!glr.InitGL((uint)this.Handle)) Application.Exit();
            glr.ResizeGL(this.ClientSize.Width, this.ClientSize.Height);
            glr.PrepareGL();
            map = new Mapa();
            glr.OnRender += new GLRenderer.Render(map.Draw);

            rendering_timer.Enabled = true;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            glr.CloseGL();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Alt && e.KeyCode == Keys.Enter)
            {
                if (this.FormBorderStyle == FormBorderStyle.None)
                {//if fullscreen
                    this.FormBorderStyle = FormBorderStyle.Sizable;
                    this.WindowState = FormWindowState.Normal;
                }
                else
                {
                    this.FormBorderStyle = FormBorderStyle.None;
                    this.WindowState = FormWindowState.Maximized;
                }
            }
            //fullscreen
            //rest
        }

        private void rendering_timer_Tick(object sender, EventArgs e)
        {
            glr.DrawGL();
            this.Text = System.Environment.TickCount.ToString();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            glr.ResizeGL(this.ClientSize.Width, this.ClientSize.Height);
        }

    }
}
