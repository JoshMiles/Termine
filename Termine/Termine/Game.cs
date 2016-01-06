using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleExtender;
using System.Drawing;
using System.Runtime.InteropServices;

namespace Termine
{
    public class Game
    {
        private Game game_derv;
        private string gameTitle = "Example Game!";
        private int x = 0;
        private int y = 0;
        private bool GameRunning = true;

        [DllImport("kernel32.dll", SetLastError = true)]
        internal static extern bool SetConsoleMode(IntPtr hConsoleHandle, int mode);

        public virtual string GameTitle
        {
            get { return gameTitle; }
            set { gameTitle = value; Console.Title = gameTitle; }
        }
        public string BaseDirectory = AppDomain.CurrentDomain.BaseDirectory;
        public Game()
        {
            Console.CursorVisible = false;
            setConsoleFontSize(1);
            defaultWindowSize();
            Console.Title = gameTitle;
        }
        public void Initialise(Game gme)
        {
            game_derv = gme;
        }
        public void Run(Map map)
        {
            map.PreRender(this);
            while (GameRunning)
            {
                map.Render(y,x);
                game_derv.Running();
                ConsoleKeyInfo cki = Console.ReadKey(true);
                if(cki.Key == map.Player._UpKey && map.Player.PlayerUp) { y += map.Player.Speed; }
                if(cki.Key == map.Player._DownKey && map.Player.PlayerDown) { y -= map.Player.Speed; }
                if(cki.Key == map.Player._RightKey && map.Player.PlayerRight) { x -= map.Player.Speed; }
                if(cki.Key == map.Player._LeftKey && map.Player.PlayerLeft) { x += map.Player.Speed; }
            }
        }
        public virtual void Running()
        {
            
        }
        private void setWindowSize(int height, int width)
        {
            Console.SetWindowSize(width, height);
        }
        private void defaultWindowSize()
        {
            Console.SetWindowSize(Console.LargestWindowWidth/2, Console.LargestWindowHeight/2);
        }
        private void Fullscreen()
        {
            Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
        }
      
        public void Clear()
        {
            Console.Clear();
            ColourGraphics.setForeground(ConsoleColor.White);
            ColourGraphics.setBackground(ConsoleColor.Black);
        }
        public void setConsoleFontSize(uint font_size)
        {
            ConsoleHelper.SetConsoleFont(font_size);
        }
        public void resetCursor()
        {
            Console.SetCursorPosition(0, 0);
        }

        public void hideCursor()
        {
            Console.SetCursorPosition(0, 0);
        }
        public void close()
        {
            Environment.Exit(0);
        }
        public void writeCentre(string text, int top, bool surround = false, char surround_char = '#')
        {
            if (surround)
            {
                int len = text.Length;
                string top_btm = "";
                for(int i = 0; i < len+4; i++)
                {
                    top_btm += surround_char;
                }
                writeCentre(top_btm, top - 1);
                writeCentre(surround_char + " " + text + " " + surround_char, top);
                writeCentre(top_btm, top + 1);
            }
            else {
                Console.SetCursorPosition(((Console.WindowWidth / 2) - ((text).Length) / 2), top);
                Console.Write(text);
            }
        }
    }
}
