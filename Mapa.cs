using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenGL;

namespace GameClient
{
    class Mapa
    {
        Pole [,] _polaMapy;
        public Mapa()
        {
            _polaMapy = new Pole[33, 19];
            _polaMapy[2, 2] = new Skala();

        }

        public void Draw(object sender, EventArgs e)
        {
            GL.glColor3f(1, 0, 0);
            for (int x = 0; x < 33; x++)
            {
                for (int y = 0; y < 19; y++)
                {
                    if (_polaMapy[x,y] != null) _polaMapy[x,y].Draw(x+1, y+1);
                }
            }
            //GL.glColor3f(1, 0, 0);
            //GL.glBegin(GL.GL_QUADS);
            //GL.glVertex2i(100, 100);
            //GL.glVertex2i(200, 100);
            //GL.glVertex2i(200, 200);
            //GL.glVertex2i(100, 200);
            //GL.glEnd();
            //GL.glBegin(GL.GL_LINES);
            //for (int x = 1; x <= 33; x++)
            //{
            //    GL.glVertex2i(x * 32, 0);
            //    GL.glVertex2i(x * 32, 19 * 32);
            //}
            //for (int y = 1; y <= 19; y++)
            //{
            //    GL.glVertex2i(0, y * 32);
            //    GL.glVertex2i(33 * 32, y * 32);
            //}

            //GL.glEnd();
        }
    }
}
