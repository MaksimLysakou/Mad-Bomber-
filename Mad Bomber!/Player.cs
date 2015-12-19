using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mad_Bomber_
{
    class Player:NPC
    {
        private string nickName;
        public int score;

        public Player(string nickName, float x, float y) : base(x, y)
        {
            this.nickName = nickName;
            this.score = 0;
        }
    }
}
