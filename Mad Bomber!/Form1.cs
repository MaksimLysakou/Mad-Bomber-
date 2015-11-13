using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Tao.OpenGl; 
using Tao.FreeGlut;
using Tao.Platform.Windows;
using Tao.DevIl;

namespace Mad_Bomber_
{
    public partial class MainForm : Form
    {
        Block[,] blocks;

        GameObj strongWall, emptyObj;
        Block background;
           
        public MainForm()
        {
            InitializeComponent();
            RenderWindow.InitializeContexts();
            OpenGLInit();

            strongWall = new GameObj("img\\wall.jpg");
            emptyObj   = new GameObj("");

            background = new Block("img\\background.jpg", -1, -1, false, true);

            blocks = new Block[17, 33];


            for (int i = 0; i < 17; i++)
            {
                for (int j = 0; j < 33; j++)
                {
                    if(i == 0 || j==0 || i==16 || j==32 || (i%2 == 0 && j%2 == 0))
                    {
                        blocks[i, j] = new Block(strongWall, -1 + j * 0.055f, 0.9f - i * 0.1f, false);
                    }
                    else 
                    {
                        blocks[i, j] = new Block(emptyObj, -1 + j * 0.055f, 0.9f - i * 0.1f, false, true);
                    }
                }
            }
        }
        private void OpenGLInit()
        {
            Glut.glutInit();
            Glut.glutInitDisplayMode(Glut.GLUT_RGB | Glut.GLUT_DOUBLE | Glut.GLUT_DEPTH);

            // инициализация библиотеки openIL 
            Il.ilInit();
            Il.ilEnable(Il.IL_ORIGIN_SET);

            Gl.glClearColor(255, 255, 255, 1); // отчитка окна 

            Gl.glViewport(0, 0, RenderWindow.Width, RenderWindow.Height); // установка порта вывода в соответствии с размерами окна
            

            // настройка проекции 
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();
            Glu.gluPerspective(0, (float)RenderWindow.Width / (float)RenderWindow.Height, 0.1, 200);
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();

        }
        private void drawTimer_Tick(object sender, EventArgs e)
        {
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);
            Gl.glClearColor(255, 255, 255, 1);
            Gl.glLoadIdentity();


            background.Draw(RenderWindow);

            foreach(Block block in blocks)
            {
                block.Draw(RenderWindow);
            }



            RenderWindow.Invalidate();
        }
    }
}
