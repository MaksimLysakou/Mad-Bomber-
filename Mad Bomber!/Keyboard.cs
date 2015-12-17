using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mad_Bomber_
{
    class Keyboard
    {
        private Dictionary<string, bool> keys;

        public Keyboard()
        {
            //Добавить пробел, эск, ентер и тп
            keys = new Dictionary<string, bool>();

            keys.Add("a", false);
            keys.Add("w", false);
            keys.Add("s", false);
            keys.Add("d", false);
        }

        public bool GetState(string key)
        {
            if (keys.ContainsKey(key.ToLower()))
            {
               return keys[key.ToLower()];
            }

            return false;
        }

        public bool KeyDown(KeyEventArgs e)
        {
            if (keys.ContainsKey(((char)e.KeyCode).ToString().ToLower()))
            {
                keys[((char)e.KeyCode).ToString().ToLower()] = true;
                return true;
            }

            return false;
        }
        public bool KeyUp(KeyEventArgs e)
        {
            if (keys.ContainsKey(((char)e.KeyCode).ToString().ToLower()))
            {
                keys[((char)e.KeyCode).ToString().ToLower()] = false;
                return true;
            }

            return false;
        }
    }
}
