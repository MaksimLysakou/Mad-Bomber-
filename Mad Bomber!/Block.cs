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

        public Block(string pathToTexture, float X, float Y, bool destroyable, bool passeble = false) : base(pathToTexture)
        {
            this.position = new PointF(X, Y);
            this.destroyable = destroyable;

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
        public Block(GameObj obj, float X, float Y, bool destroyable, bool passeble = false): base(obj)
        {
            this.position = new PointF(X, Y);
            this.destroyable = destroyable;

            this.passeble = passeble;
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

            // включаем режим текстурирования 
            Gl.glEnable(Gl.GL_TEXTURE_2D);

            // включаем режим текстурирования, указывая идентификатор mGlTextureObject 
            Gl.glBindTexture(Gl.GL_TEXTURE_2D, this.texture);

            // сохраняем состояние матрицы 
            Gl.glPushMatrix();

            // выполняем перемещение для более наглядного представления сцены 
            Gl.glTranslated(this.position.X, this.position.Y, 0);
            // реализуем поворот объекта 
            Gl.glRotated(rot, 0, 0, 1);

            Gl.glScalef((0.0030f * scale * this.size.Y * Texture.RenderWindow.Height / Texture.RenderWindow.Width), 0.0030f * scale * this.size.X, 0.0f);

            // отрисовываем полигон 
            Gl.glBegin(Gl.GL_QUADS);

            // указываем поочередно вершины и текстурные координаты 
            Gl.glVertex2d(0, 0);
            Gl.glTexCoord2f(0, 0);
            Gl.glVertex2d(1, 0);
            Gl.glTexCoord2f(1, 0);
            Gl.glVertex2d(1, 1);
            Gl.glTexCoord2f(1, 1);
            Gl.glVertex2d(0, 1);
            Gl.glTexCoord2f(0, 1);

            // завершаем отрисовку 
            Gl.glEnd();

            // возвращаем матрицу 
            Gl.glPopMatrix();
            // отключаем режим текстурирования 
            Gl.glDisable(Gl.GL_TEXTURE_2D);
        }
    }
}
