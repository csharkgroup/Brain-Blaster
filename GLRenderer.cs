using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using OpenGL;
using System.Windows.Forms;

namespace GameClient
{
    class GLRenderer
    {
        private uint DC;
        private uint Handle;
        private uint RC;
        public bool InitGL(uint windowHandle)
        {
            Handle = windowHandle;
            DC = WGL.GetDC(windowHandle);
            if (DC == 0) return false;

            WGL.wglSwapBuffers(DC);

            WGL.PIXELFORMATDESCRIPTOR pfd = new WGL.PIXELFORMATDESCRIPTOR();
            WGL.ZeroPixelDescriptor(ref pfd);
            pfd.nVersion = 1;
            pfd.dwFlags = WGL.PFD_DRAW_TO_WINDOW | WGL.PFD_SUPPORT_OPENGL | WGL.PFD_DOUBLEBUFFER;
            pfd.iPixelType = (byte)WGL.PFD_TYPE_RGBA;
            pfd.cColorBits = 16;
            pfd.cDepthBits = 16;//mozna zmienic na 0 chyba
            pfd.iLayerType = (byte)WGL.PFD_MAIN_PLANE;

            int pixelFormat = WGL.ChoosePixelFormat(DC, ref pfd);
            if (pixelFormat == 0)
            {
                MessageBox.Show("Niedozwolony format pixela");
                return false;
            }
            if (WGL.SetPixelFormat(DC, pixelFormat, ref pfd) == 0)
            {
                MessageBox.Show("set pix format");
                return false;
            }
            RC = WGL.wglCreateContext(DC);
            if (RC == 0)
            {
                MessageBox.Show("cannot cre");
                return false;
            }
            if (WGL.wglMakeCurrent(DC, RC) == 0)
            {
                MessageBox.Show("cannot set");
                return false;
            }

            return true;
        }

        public void ResizeGL(int x, int y)
        {
            WGL.wglMakeCurrent(Handle, RC);
            GL.glMatrixMode(GL.GL_PROJECTION);
            GL.glLoadIdentity();
            //GLU.gluPerspective(45, x / y, 0, 10);//zNear, zFar bycmoze do zmiany
            GL.glViewport(0, 0, x, y);
            GL.glOrtho(0, 33 * 32, 0, 19 * 32, -1, 1);
            GL.glMatrixMode(GL.GL_MODELVIEW);
            GL.glLoadIdentity();
        }

        public void PrepareGL()
        {
            //ustawienia
            GL.glClearColor(0, 1, 0, 1);
            //GL.glEnable(GL.GL_TEXTURE_2D);
        }

        public delegate void Render(object renderer, EventArgs args);

        public event Render OnRender;


        public void DrawGL()
        {
            GL.glClear(GL.GL_COLOR_BUFFER_BIT);
            GL.glLoadIdentity();
            //render
            if(OnRender != null) OnRender(this, new EventArgs());
            GL.glFlush();
            WGL.wglSwapBuffers(DC);
        }

        public bool CloseGL()
        {
            WGL.wglMakeCurrent(DC, 0);
            WGL.wglDeleteContext(RC);
            WGL.ReleaseDC(Handle, DC);
            return true;
        }

    }
}
