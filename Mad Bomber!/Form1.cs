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
            thisGame.activeLevel.background = new Block("img\\background.png", 0, 0, destroyable: false, passeble: true);
        }
        
        private void drawTimer_Tick(object sender, EventArgs e)
        {
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);
            Gl.glClearColor(255, 255, 255, 1);
            Gl.glLoadIdentity();

            thisGame.checkPlayer(keyboard);
            thisGame.drawAll();

            RenderWindow.Invalidate();
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
