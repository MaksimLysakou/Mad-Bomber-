using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Mad_Bomber_
{
    class Level
    {
        public string Name;

        public Block background;

        public List<Block> blocks;
        public List<NPC> mobs;

        public Point size;

        public Level(string name)
        {
            this.Name = name;

            this.blocks = new List<Block>();
            this.mobs = new List<NPC>();

            //this.background = new Block()
        }
        public Level(string name, List<Block> blocks, List<NPC> mobs, GameObj background)
        {
            this.Name = name;

            this.blocks = blocks;
            this.mobs = mobs;

            this.background = new Block(background, -1, 0.9f, destroyable:false, passeble:true);
        }

        public void drawLevel()
        {
            this.background.Draw();

            foreach(Block block in blocks)
            {
                block.Draw();
            }

            foreach (NPC mob in mobs)
            {
                mob.Draw();
            }
        }
    }
}
