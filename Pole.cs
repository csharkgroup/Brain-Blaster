using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenGL;

namespace GameClient
{
    class Pole
    {
        public virtual void Draw(int x, int y)
        {

        }
    }

    class Skala : Pole
    {
        public virtual void Draw(int x, int y)
        {
            GL.glBegin(GL.GL_LINES);
            GL.glVertex2i(x * 32    , y * 32);
            GL.glVertex2i((x+1) * 32, y * 32);
            GL.glVertex2i((x+1) * 32, (y+1) * 32);
            GL.glVertex2i(x * 32    , (y+1) * 32);
            GL.glEnd();
        }
    }
}
