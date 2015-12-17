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
using System.IO;

namespace Mad_Bomber_
{
    public partial class MainForm : Form
    {
        Game thisGame;
        Keyboard keyboard;

        public MainForm()
        {
            InitializeComponent();
            RenderWindow.InitializeContexts();
            Texture.OpenGLInit(RenderWindow);

            thisGame = new Game();
            keyboard = new Keyboard();


            //Выпилить!
            thisGame.levels = XML.getListOfLevels("level.xml", "block.xml");
            thisGame.activeLevel = thisGame.levels[0];            
            thisGame.activeLevel.background = new Block("img\\background.png", 0, 0, false, true);

            
            







            
            //strongWall = new GameObj("img\\wall.jpg"); //temp
            //emptyObj   = new GameObj(""); //temp
            //character  = new GameObj("img\\hero.png"); //temp

            //background = new Block("img\\background.jpg", 0, 0, false, true); //temp, TODO: Запилить нормальный уровень

            //c = new Block(character, 0, 0, true); // temp, TODO: Запилить нормального персонажа (GameObj->Creature->Player), несколько скинов

            //blocks = new Block[17, 33]; //temp, TODO: Запилить нормальный уровень (Level, contains List of blocks, XML)

            //////----------
            //for (int i = 0; i < 17; i++)
            //{
            //    for (int j = 0; j < 33; j++)
            //    {
            //        if(i == 0 || j==0 || i==16 || j==32 || (i%2 == 0 && j%2 == 0))
            //        {
            //            blocks[i, j] = new Block("img\\wall.jpg",  j * 0.0015f, i * 0.0015f, true, false);
            //        }
            //        else 
            //        {
            //            blocks[i, j] = new Block("", -1 + j * (RenderWindow.Height / RenderWindow.Width) * 0.1f, 1f - i *(RenderWindow.Width / RenderWindow.Height) * 0.1f, false, true);
            //            blocks[i, j].type = 0;
            //        }
            //    }
            //}
            ////--- Temp, залить в XML ---
            

        }
        
        private void drawTimer_Tick(object sender, EventArgs e)
        {
           
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);
            Gl.glClearColor(255, 255, 255, 1);
            Gl.glLoadIdentity();

            thisGame.checkPlayer(keyboard);
            thisGame.drawAll();

            RenderWindow.Invalidate();

            //StreamWriter w = new StreamWriter("level.xml");

            //w.WriteLine("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
            //w.WriteLine("<library>");
            //w.WriteLine("  <level id=\"1\" name=\"Hello, World!\" sizeX=\"33\" sizeY=\"17\">");

            //for (int i = 0; i < 17; i++)
            //{
            //    for (int j = 0; j < 33; j++)
            //    {
            //        if (i == 0 || j == 0 || i == 16 || j == 32 || (i % 2 == 0 && j % 2 == 0))
            //        {
            //            w.WriteLine("    <block type=\"1\" X=\"{0}\" Y=\"{1}\" destroyable=\"{2}\" passeble=\"{3}\" />", j, i, true.ToString(), false.ToString());
            //            //blocks[i, j] = new Block("img\\wall.jpg",  + j * 0.0015f, 0.9f - i * 0.1f, false);
            //        }
            //        else
            //        {
            //            w.WriteLine("    <block type=\"0\" X=\"{0}\" Y=\"{1}\" destroyable=\"{2}\" passeble=\"{3}\" />", j, i, false.ToString(), true.ToString());

            //            //blocks[i, j] = new Block("", -1 + j * (RenderWindow.Height / RenderWindow.Width) * 0.1f, 1f - i *(RenderWindow.Width / RenderWindow.Height) * 0.1f, false, true);
            //            //blocks[i, j].type = 0;
            //        }
            //    }
            //}



            //w.WriteLine("  </level>");
            //w.WriteLine("</library>");

            //w.Close();

            //Application.Exit();

            //this.Text = "AAAAA";

            //drawTimer.Enabled = false;
        }

        private void RenderWindow_KeyDown(object sender, KeyEventArgs e)
        {
            keyboard.KeyDown(e);
        }
        private void RenderWindow_KeyUp(object sender, KeyEventArgs e)
        {
            keyboard.KeyUp(e);
        }
    }
}
