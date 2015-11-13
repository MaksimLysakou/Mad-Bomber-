using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

using Tao.OpenGl;
using Tao.FreeGlut;
using Tao.Platform.Windows;
using Tao.DevIl;

namespace Mad_Bomber_
{
    class Texture
    {
        public static int getTexture(string url)
        {
            int mGlTextureObject = -1;
            int imageId = 0;

            // создаем изображение с идентификатором imageId 
            Il.ilGenImages(1, out imageId);
            // делаем изображение текущим 
            Il.ilBindImage(imageId);

            Il.ilLoadImage(url);

            // если загрузка прошла успешно 
            // сохраняем размеры изображения 
            int width = Il.ilGetInteger(Il.IL_IMAGE_WIDTH);
            int height = Il.ilGetInteger(Il.IL_IMAGE_HEIGHT);

            // определяем число бит на пиксель 
            int bitspp = Il.ilGetInteger(Il.IL_IMAGE_BITS_PER_PIXEL);

            switch (bitspp) // в зависимости от полученного результата 
            {
                // создаем текстуру, используя режим GL_RGB или GL_RGBA 
                case 24:
                    mGlTextureObject = MakeGlTexture(Gl.GL_RGB, Il.ilGetData(), width, height);
                    break;
                case 32:
                    mGlTextureObject = MakeGlTexture(Gl.GL_RGBA, Il.ilGetData(), width, height);
                    break;
            }

            // очищаем память 
            Il.ilDeleteImages(1, ref imageId);

            return mGlTextureObject;
        }
        public static Point getSizeOfTexture(string url)
        {
            int imageId = 0;

            // создаем изображение с идентификатором imageId 
            Il.ilGenImages(1, out imageId);
            // делаем изображение текущим 
            Il.ilBindImage(imageId);

            Il.ilLoadImage(url);

            return new Point(Il.ilGetInteger(Il.IL_IMAGE_WIDTH), Il.ilGetInteger(Il.IL_IMAGE_HEIGHT));
        }

        private static int MakeGlTexture(int Format, IntPtr pixels, int w, int h)
        {
            // идентификатор текстурного объекта 
            int texObject;

            // генерируем текстурный объект 
            Gl.glGenTextures(1, out texObject);

            // устанавливаем режим упаковки пикселей 
            Gl.glPixelStorei(Gl.GL_UNPACK_ALIGNMENT, 1);

            // создаем привязку к только что созданной текстуре 
            Gl.glBindTexture(Gl.GL_TEXTURE_2D, texObject);

            // устанавливаем режим фильтрации и повторения текстуры 
            Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_WRAP_S, Gl.GL_REPEAT);
            Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_WRAP_T, Gl.GL_REPEAT);
            Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MAG_FILTER, Gl.GL_LINEAR);
            Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MIN_FILTER, Gl.GL_LINEAR);
            Gl.glTexEnvf(Gl.GL_TEXTURE_ENV, Gl.GL_TEXTURE_ENV_MODE, Gl.GL_REPLACE);

            // создаем текстуру  (RGB/RGBA)
            switch (Format)
            {
                case Gl.GL_RGB:
                    Gl.glTexImage2D(Gl.GL_TEXTURE_2D, 0, Gl.GL_RGB, w, h, 0, Gl.GL_RGB, Gl.GL_UNSIGNED_BYTE, pixels);
                    break;

                case Gl.GL_RGBA:
                    Gl.glTexImage2D(Gl.GL_TEXTURE_2D, 0, Gl.GL_RGBA, w, h, 0, Gl.GL_RGBA, Gl.GL_UNSIGNED_BYTE, pixels);
                    break;
            }

            return texObject;
        }
    }
}
