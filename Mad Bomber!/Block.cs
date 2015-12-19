using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

using Tao.OpenGl;

namespace Mad_Bomber_
{
    class Block:GameObj
    {
        public PointF position;

        private bool destroyable;
        private bool passeble;

        public int type;

        public Block(string pathToTexture, float X, float Y, float scale = 0.03125f, bool destroyable = true, bool passeble = false)
            : base(pathToTexture)
        {
            this.position = new PointF(X, Y);
            this.destroyable = destroyable;

            this.size.X *= scale;
            this.size.Y *= scale;

            this.passeble = passeble;
        }

        public Block(Block block)
        {
            this.position = block.position;
            this.texture = block.texture;
            this.destroyable = block.destroyable;
            this.size = block.size;
            this.passeble = block.passeble;
        }

        public Block(GameObj obj, float X, float Y, float scale = 0.03125f, bool destroyable = true, bool passeble = false)
            : base(obj)
        {
            this.position = new PointF(X, Y);
            this.destroyable = destroyable;
            this.passeble = passeble;

            this.size.X *= scale;
            this.size.Y *= scale;
        }
        public bool isDestroyable()
        {
            return destroyable;
        }
        public bool isPasseble()
        {
            return passeble;
        }

        public void Draw(float scale = 1.0f, float rot = 0.0f)
        {
            Gl.glEnable(Gl.GL_TEXTURE_2D);
            Gl.glBindTexture(Gl.GL_TEXTURE_2D, this.texture);
            Gl.glPushMatrix();

            Gl.glTranslated((Texture.RenderWindow.Location.X + this.position.X) * 0.1f - 1, (Texture.RenderWindow.Location.Y + this.position.Y) * 0.05f - 1, 1);
            Gl.glRotated(rot, 0, 0, 1);
            Gl.glScalef((0.05f * scale * this.size.Y * Texture.RenderWindow.Width / Texture.RenderWindow.Height), 0.05f * scale * this.size.X, 0.0f);


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
            return (((this.position.X > block.position.X) && (this.position.Y > block.position.Y)) && ((this.position.X < block.position.X + block.size.X) && (this.position.Y < block.position.Y + block.size.Y)) ||
                    ((this.position.X + this.size.X > block.position.X) && (this.position.Y + this.size.Y > block.position.Y)) && ((this.position.X + this.size.X < block.position.X + block.size.X) && (this.position.Y + this.size.Y < block.position.Y + block.size.Y)));
        }
    }
}
