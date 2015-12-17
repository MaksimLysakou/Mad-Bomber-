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

        public NPC(float y, float x):base("img//heroK.png")
        {
            //TODO: add NPC
            position = new PointF(x, y);
            this.speed = 0.5f;
        }

        public void Draw(float scale = 1.0f, float rot = 0.0f)
        {
            Gl.glEnable(Gl.GL_TEXTURE_2D);
            Gl.glBindTexture(Gl.GL_TEXTURE_2D, this.texture);


            Gl.glTranslated((Texture.RenderWindow.Location.X + this.position.X) * 0.1f - 1, (Texture.RenderWindow.Location.Y + this.position.Y) * 0.05f - 1, 1);
            Gl.glRotated(rot, 0, 0, 1);
            Gl.glScalef((0.0015f * scale * this.size.Y * Texture.RenderWindow.Width / Texture.RenderWindow.Height), 0.0015f * scale * this.size.X, 0.0f);


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

    }
}
