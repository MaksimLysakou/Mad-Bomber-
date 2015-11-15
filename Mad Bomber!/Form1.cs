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
    //    Block[,] blocks;

    //    GameObj strongWall, emptyObj, character;
    //    Block background, c;

        Level level;
           
        public MainForm()
        {
            InitializeComponent();
            RenderWindow.InitializeContexts();
            Texture.OpenGLInit(RenderWindow);

            level = new Level("");

            level = XML.getListOfLevels("level.xml", "block.xml")[0];

            //strongWall = new GameObj("img\\wall.jpg"); //temp
            //emptyObj   = new GameObj(""); //temp
            //character  = new GameObj("img\\hero.png"); //temp

            //background = new Block("img\\background.jpg", 0, 0, false, true); //temp, TODO: Запилить нормальный уровень

            //c = new Block(character, 0, 0, true); // temp, TODO: Запилить нормального персонажа (GameObj->Creature->Player), несколько скинов

            //blocks = new Block[17, 33]; //temp, TODO: Запилить нормальный уровень (Level, contains List of blocks, XML)

            ////----------
            //for (int i = 0; i < 17; i++)
            //{
            //    for (int j = 0; j < 33; j++)
            //    {
            //        if(i == 0 || j==0 || i==16 || j==32 || (i%2 == 0 && j%2 == 0))
            //        {
            //            blocks[i, j] = new Block(strongWall, -1 + j * 0.055f, 0.9f - i * 0.1f, false);
            //            blocks[i, j].type = 1;
            //        }
            //        else 
            //        {
            //            blocks[i, j] = new Block(emptyObj, -1 + j * 0.055f, 0.9f - i * 0.1f, false, true);
            //            blocks[i, j].type = 0;
            //        }
            //    }
            //}
            ////--- Temp, залить в XML ---

        }
        
        private void drawTimer_Tick(object sender, EventArgs e)
        {
            //TODO: Сделать game.DrawAll(RenderWindow);
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);
            Gl.glClearColor(255, 255, 255, 1);
            Gl.glLoadIdentity();

            //background.Draw();

            foreach (Block block in level.blocks)
            {
                block.Draw();
            }

            RenderWindow.Invalidate();
        }
    }
}
