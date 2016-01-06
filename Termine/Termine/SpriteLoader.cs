using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Termine
{
    public static class SpriteLoader
    {
        public static Termine.Graphic.Sprite LoadSpriteFromFile(string file_location)
        {
            string[] file = File.ReadAllLines(file_location);

            int sprite_height = file.Length;
            int sprite_width = Termine.Loader.getLongest(file);

            char[,] sprite = new char[sprite_height, sprite_width];
            int count = 0;
            foreach(var line in file)
            {
                if(line.Length < sprite_width)
                {
                    for(int i = 0; i < sprite_width - line.Length; i++)
                    {
                        file[count] += " ";
                    }
                }
                count++;
            }

            for(int x = 0; x < sprite_width; x++)
            {
                for(int y = 0; y < sprite_height; y++)
                {
                        sprite[x, y] = file[x][y];
                   
                }
            }
            Termine.Graphic.Sprite spt = new Termine.Graphic.Sprite(sprite_height, sprite_width);
            spt.SpriteImage = sprite;
            return spt;
        }
    }
}
