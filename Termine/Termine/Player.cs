using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Termine.Graphic;
namespace Termine
{
    public class Player
    {
        private Sprite sprite;
        private ConsoleKey UpKey = ConsoleKey.W;
        private ConsoleKey DownKey = ConsoleKey.S;
        private ConsoleKey LeftKey = ConsoleKey.A;
        private ConsoleKey RightKey = ConsoleKey.D;
        public bool PlayerLeft = true;
        public bool PlayerRight = true;
        public bool PlayerUp = true;
        public bool PlayerDown = true;
        private int sheight;
        private int swidth;
        private int speed = 1;

        public int Speed
        {
            get { return speed; }
            set { speed = value; }
        }

        public ConsoleKey _UpKey
        {
            get { return UpKey; }
            set { UpKey = value; }
        }
        public ConsoleKey _DownKey
        {
            get { return DownKey; }
            set { DownKey = value; }
        }
        public ConsoleKey _LeftKey
        {
            get { return LeftKey; }
            set { LeftKey = value; }
        }
        public ConsoleKey _RightKey
        {
            get { return RightKey; }
            set { RightKey = value; }
        }

        public Player(Sprite sprite)
        {
            this.sprite = sprite;
            swidth = sprite.SpriteWidth;
            sheight = sprite.SpriteHeight;
        }

        public void checkCollison(Map m)
        {
            
            int player_x = (Console.WindowWidth / 2) - (swidth) / 2;
            int player_y = (Console.WindowHeight / 2) - (sheight) / 2;

            int map_x = m.MapX;
            int map_y = m.MapY;

            char[,] map = m.SAMap;
            if (map_x == player_x) { PlayerLeft = false; } else { PlayerLeft = true; }
            if (map_y == player_y) { PlayerUp = false; } else { PlayerUp = true; }
            if (player_y - map_y == m.MapHeight - 1) { PlayerDown = false; } else { PlayerDown = true; }
            if (player_x - map_x == m.MapWidth - 1) { PlayerRight = false; } else { PlayerRight = true; }


            int mh = m.MapHeight;
            foreach (var coll in m.CollidableChars)
            {
                for (int y = 0; y < sprite.SpriteHeight; y++)
                {
                    for (int x = 0; x < sprite.SpriteHeight; x++)
                    {
                        if ((map[(player_y) - map_y + y, (player_x) - map_x + x] == coll))
                        {
                            if (!(sprite.SpriteImage[x, y] == ' '))
                            {
                                Console.Title = "0";
                            }
                            else
                            {
                                Console.SetCursorPosition(player_x + x, player_y + y);
                                Console.Write(coll);
                            }
                        }
                        else if ((map[(player_y + 1) - map_y + y, (player_x) - map_x + x] == coll))
                        {
                            if (!(sprite.SpriteImage[x, y] == ' '))
                            {
                                Console.Title = "1";
                                PlayerDown = false;
                            }
                            else
                            {
                                PlayerDown = true;
                            }
                        }
                        else if (map[(player_y) - map_y + y, (player_x + 1) - map_x + x] == coll)
                        {
                            if (!(sprite.SpriteImage[x, y] == ' '))
                            {
                                Console.Title = "2";
                                PlayerRight = false;
                            }
                            else
                            {
                                PlayerRight = true;
                            }
                        }
                        else if (map[(player_y - 1) - map_y + y, (player_x) - map_x + x] == coll)
                        {
                            if (!(sprite.SpriteImage[x, y] == ' '))
                            {
                                Console.Title = "3";
                                PlayerUp = false;
                            }
                            else
                            {
                                PlayerUp = true;
                            }
                        }
                        else if (map[(player_y) - map_y + y, (player_x - 1) - map_x + x] == coll)
                        {
                            if (!(sprite.SpriteImage[x, y] == ' '))
                            {
                                Console.Title = "4";
                                PlayerLeft = false;
                            }
                            else
                            {
                                PlayerLeft = true;
                            }
                        }
                    }
                }
            }

        }

        public void Render()
        {
            for (int x = 0; x < sheight; x++)
            {
                for (int y = 0; y < swidth; y++)
                {
                    Console.SetCursorPosition(((Console.WindowWidth / 2) - (swidth) / 2) + y, ((Console.WindowHeight / 2) - (sheight) / 2) + x);
                    Console.Write(sprite.SpriteImage[x, y]);
                }
            }

        }


    }
}
