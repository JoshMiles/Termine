using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Termine
{
    public static class MapLoader
    {
        public static Map LoadMapFromFile(string file_location)
        {
            string[] file = File.ReadAllLines(file_location);
            string[] temp = new string[file.Length];

            int map_height = file.Length;
            int map_width = Termine.Loader.getLongest(file);

            for (int i = 0; i < map_height; i++)
            {
                if(file[i].Length < map_width)
                {
                    for(int z = 0; z < file[i].Length; z++)
                    {
                        temp[i] += file[i][z];
                    }

                    for(int z = file[i].Length; z < map_width; z++)
                    {
                        temp[i] += ' ';
                    }
                }
                else
                {
                    temp[i] = file[i];
                }
            }
            file = temp;

            char[,] map = new char[map_height, map_width];

            for(int x = 0; x < map_height; x++)
            {
                for(int y = 0; y < map_width; y++)
                {
                 
                        map[x, y] = file[x][y];
                    
                }
            }
            Map _map = new Map(map_height, map_width);
            _map.SetMap(map, map_height, map_width);
            return _map;
        }
    }
}
