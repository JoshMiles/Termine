using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Termine.Graphic
{
    public class Sprite
    {
        private static int spriteheight;
        private static int spritewidth;
        private char[,] sprite;
        public Sprite(int SpriteHeight, int SpriteWidth)
        {
            this.SpriteHeight = SpriteHeight;
            this.SpriteWidth = SpriteWidth;
            sprite = new char[spriteheight, spritewidth];
        }

        public char[,] SpriteImage
        {
            get { return sprite; }
            set { sprite = value; }
        }
        public int SpriteHeight
        {
            get { return spriteheight; }
            set { spriteheight = value; }
        }
        public int SpriteWidth
        {
            get { return spritewidth; }
            set { spritewidth = value; }
        }
    }
}
