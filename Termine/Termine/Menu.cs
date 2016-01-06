using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Termine
{
    public class Menu
    {
        public List<MenuItem> MenuItems = new List<MenuItem>();
        Game game = null;
        bool ShowGameTitle;
        public Menu(Game game, Boolean game_title = true)
        {
            ShowGameTitle = game_title;
            this.game = game;
        }
        public int Show()
        {
            int selected = 0;
            bool selecting = true;
            while (selecting)
            {
                game.Clear();
                if (ShowGameTitle)
                {

                    game.writeCentre(game.GameTitle, 2, true);
                }
                game.resetCursor();
                int menuitem_count = 0;
                foreach (var _MenuItem in MenuItems)
                {
                    int top = (_MenuItem.Rank * 5) + 8;
                    if (!(_MenuItem.MIT == MenuItem.MenuItemType.Text))
                    {
                        if (selected == _MenuItem.Rank)
                        {
                            game.writeCentre(_MenuItem.Text, top, true, '~');
                        }
                        else {
                            game.writeCentre(_MenuItem.Text, top);
                        }
                        menuitem_count++;
                    }
                    else
                    {
                        game.writeCentre(_MenuItem.Text, top, true, '=');
                    }
                }
                game.hideCursor();

                ConsoleKeyInfo ck = Console.ReadKey(true);
                if (ck.Key == ConsoleKey.UpArrow)
                {
                    if (selected == 0)
                    {
                        selected = menuitem_count - 1;
                    }
                    else
                    {
                        selected -= 1;
                    }
                }
                else if (ck.Key == ConsoleKey.DownArrow)
                {
                    if (selected == menuitem_count - 1)
                    {
                        selected = 0;
                    }
                    else
                    {
                        selected += 1;
                    }
                }
                else if (ck.Key == ConsoleKey.Enter)
                {
                    selecting = false;
                }
            }
            return selected;
        }
    }

    public class MenuItem
    {
        private string text;
        private int rank;
        public enum MenuItemType { Button, Text }
        private MenuItemType _mit;

        public MenuItem(string Text, int Rank, MenuItemType mit = MenuItemType.Button)
        {
            this.text = Text;
            this.rank = Rank;
            this._mit = mit;
        }

        public MenuItemType MIT
        {
            get { return _mit; }
            set { _mit = value; }
        }

        public string Text
        {
            get { return text; }
            set { text = value; }
        }

        public int Rank
        {
            get { return rank; }
            set { rank = value; }
        }
    }
}
