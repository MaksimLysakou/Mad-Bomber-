using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

using Tao.OpenGl;

namespace Mad_Bomber_
{
    class NPC:GameObj
    {
        public PointF position;
        public float speed;

        //public GameObj.Direction direction;

        public NPC(float y, float x, float scale = 1.0f/30)
            : base("img//heroK.png")
        {
            position = new PointF(x, y);
            this.speed = 0.1f;

            this.size.X *= scale;
            this.size.Y *= scale;            
        }

        public void Draw(float scale = 1.0f, float rot = 0.0f)
        {
            Gl.glEnable(Gl.GL_TEXTURE_2D);
            Gl.glBindTexture(Gl.GL_TEXTURE_2D, this.texture);


            Gl.glTranslated((Texture.RenderWindow.Location.X + this.position.X) * 0.1f - 1, (Texture.RenderWindow.Location.Y + this.position.Y) * 0.05f - 1, 1);
            Gl.glRotated(rot, 0, 0, 1);
            Gl.glScalef((0.03f * scale * this.size.Y * Texture.RenderWindow.Width / Texture.RenderWindow.Height), 0.03f * scale * this.size.X, 0.0f);


            Gl.glBegin(Gl.GL_QUADS);

            Gl.glVertex2d(0, 0);
            Gl.glTexCoord2f(0, 0);
            Gl.glVertex2d(1, 0);
            Gl.glTexCoord2f(1, 0);
            Gl.glVertex2d(1, 1);
            Gl.glTexCoord2f(1, 1);
            Gl.glVertex2d(0, 1);
            Gl.glTexCoord2f(0, 1);

            Gl.glEnd();

            
            Gl.glPopMatrix();
            Gl.glDisable(Gl.GL_TEXTURE_2D);
        }
        public bool IsCrossed(Block block)
        {
            float X1 = block.position.X;
            float Y1 = block.position.Y;

            float X2 = block.position.X + block.size.X;
            float Y2 = block.position.Y + block.size.Y;

            float X3 = this.position.X;
            float Y3 = this.position.Y;

            float X4 = this.position.X + this.size.X;
            float Y4 = this.position.Y + this.size.Y;

             if (
                 (X3 > Y1 && X3 < Y2) && (Y3 > X1 && Y3 < X2) ||
                 (X3 > Y1 && X3 < Y2) && (Y4 > X1 && Y4 < X2) ||
                 (X4 > Y1 && X4 < Y2) && (Y3 > X1 && Y3 < X2) ||
                 (X4 > Y1 && X4 < Y2) && (Y4 > X1 && Y4 < X2)
                )
                return true;
            else
                return false;
        }
    }
}
