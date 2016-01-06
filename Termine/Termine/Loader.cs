using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Termine
{
    public static class Loader
    {
        public static int getWidth(char[,] c)
        {
            return c.GetLength(1);
        }

        public static int getLongest(string[] str)
        {
            List<int> l = new List<int>();
            foreach(var line in str)
            {
                System.Diagnostics.Debug.WriteLine(line.Length);
                l.Add(line.Length);
            }
            System.Diagnostics.Debug.WriteLine(l.Max());
            return l.Max();
        }
    }
}
