using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Termine
{
    class Graphics
    {
       

    }
    public static class ColourGraphics
    {
        public static void setForeground(ConsoleColor color)
        {
            Console.ForegroundColor = color;
        }

        public static void setBackground(ConsoleColor color)
        {
            Console.BackgroundColor = color;
        }
    }
}
