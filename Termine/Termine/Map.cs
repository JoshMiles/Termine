using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Termine
{
    public class Map
    {
        private int current_x = 0;
        private int current_y = 0;
        private static int map_height;
        private static int map_width;
        private List<char> collidables = new List<char>();
        private char[,] map;
        private Player player;
        private Game game;

        public char[,] SAMap
        {
            get { return map; }
        }

        public List<char> CollidableChars
        {
            get { return collidables; }
            set { collidables = value; }
        }
        public int MapX
        {
            get { return current_x; }
            set { current_x = value; }
        }

        public int MapY
        {
            get { return current_y; }
            set { current_y = value; }
        }

        [DllImport("kernel32.dll")]
        static extern void OutputDebugString(string lpOutputString);

        public Map(Map _Map)
        {
            MapHeight = _Map.MapHeight;
            MapWidth = _Map.MapWidth;
            map = new char[map_width, map_height];
            SetMap(_Map);
        }

        public Map(int Height, int Width)
        {
            MapHeight = Height;
            MapWidth = Width;
            map = new char[map_width, map_height];
        }
        public void PreRender(Game game)
        {
            this.game = game;
        }

        public void Render(int baseX = 0, int baseY = 0)
        {
            MapX = baseY;
            MapY = baseX;
            Console.Clear();
            Console.SetCursorPosition(0, 0);
            int boundsY = Console.WindowWidth;
            int boundsX = Console.WindowHeight;
            int remY = 0;
            int rY = 0;
            string buffer_left = "";
            string[] out_map = new string[MapHeight];
            if (!(baseY < 0))
            {
                remY = baseY;
                for (int i = 0; i < baseY; i++)
                {
                    buffer_left += " ";
                }
            }
            else {
                rY = 0 - baseY;
            }
            bool posT = baseX >= 0;

            if (posT)
            {
                int count = 0;
                out_map = new string[MapHeight + baseX];
                for (int x = 0; x < MapHeight; x++)
                {
                    out_map[x] += buffer_left;

                    if (baseX > x)
                    {
                        out_map[x] += "";
                        count++;
                    }
                    else
                    {
                        for (int y = rY; y < (MapWidth - remY); y++)
                        {
                            out_map[x] += map[x - count, y];
                        }
                    }
                    out_map[x] += Environment.NewLine;
                }
            }
            else
            {
                out_map = new string[MapHeight];
                for (int x = 0 - baseX; x < MapHeight; x++)
                {
                    out_map[x] += buffer_left;
                    for (int y = rY; y < (MapWidth - remY); y++)
                    {
                        out_map[x] += map[x, y];
                    }

                    out_map[x] += Environment.NewLine;
                }
            }

            foreach (string line in out_map) { Console.Write(line); }
            player.Render();
            Console.SetCursorPosition(0, 0);
        }
        public void SetPixel(int x, int y, char obj)
        {
            map[x, y] = obj;
        }
        public void SetMap(Map map)
        {
            this.map = map.map;
            this.MapHeight = map.MapHeight;
            this.MapWidth = map.MapWidth;
        }
        public void SetMap(char[,] map, int map_height, int map_width)
        {
            this.map = map;
            this.MapHeight = map_height;
            this.MapWidth = map_width;
        }
        public int MapHeight
        {
            get { return map_height; }
            set { map_height = value; }
        }
        public int MapWidth
        {
            get { return map_width; }
            set { map_width = value; }
        }

        public Player Player
        {
            get { return player; }
            set { player = value; }
        }
    }

}
