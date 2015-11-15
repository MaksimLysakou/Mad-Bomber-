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

        public NPC()
        {
            //TODO: add NPC
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
