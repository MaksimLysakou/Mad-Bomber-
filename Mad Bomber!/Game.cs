using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mad_Bomber_
{
    class Game
    {
        //PointF GameFieldPosition;

        public List<Level> levels;
        public List<Player> players;

        public Level activeLevel;

        private string frame; //Определяет на каком этапе находится игрок. (Меню, игра, ...)
        
        public Game()
        {
           // GameFieldPosition.X = (Texture.RenderWindow.Size.Width  - activeLevel.size.X) / 2;
           // GameFieldPosition.Y = (Texture.RenderWindow.Size.Height - activeLevel.size.Y) / 2;

            players = new List<Player>();
            players.Add(new Player(".tico", 1, 1));
            frame = "Game.Playing";
        }

        public void drawAll()
        {
            switch(frame)
            {
                case "Game.Playing": 
                
                activeLevel.drawLevel();

                foreach(Player player in players)
                {
                    player.Draw(1.67f);
                }

                break;

                case "Manu.Main":

                break;
            }
        }
        public void checkPlayer(Keyboard keyboard)
        {
            if(keyboard.GetState("a") == true)
            {
                players[0].position.Y -= players[0].speed;
            }

            if (keyboard.GetState("d") == true)
            {
                players[0].position.Y += players[0].speed;
            }

            if (keyboard.GetState("w") == true)
            {
                players[0].position.X -= players[0].speed;
            }

            if (keyboard.GetState("s") == true)
            {
                players[0].position.X += players[0].speed;
            }
        }
    }
}
