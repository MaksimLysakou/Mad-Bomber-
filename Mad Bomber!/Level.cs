using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mad_Bomber_
{
    class Level
    {
        public string Name;

        public List<Block> blocks;
        public List<NPC> mobs;

        public Level(string name)
        {
            this.Name = name;

            this.blocks = new List<Block>();
            this.mobs = new List<NPC>();
        }
        public Level(string name, List<Block> blocks, List<NPC> mobs)
        {
            this.Name = name;

            this.blocks = blocks;
            this.mobs = mobs;
        }

        public void drawAll()
        {
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
