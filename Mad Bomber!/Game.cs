using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mad_Bomber_
{
    class Game
    {
        public List<Level> levels;
        public List<Player> players;

        public Level activeLevel;
        
        public Game()
        {
            
        }

        public void drawAll()
        {
            //activeLevel.DrawAll();

            foreach(Player player in players)
            {
                player.Draw();
            }
        }
    }
}
