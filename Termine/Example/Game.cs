using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Termine;

namespace Example
{
    class Game : Termine.Game
    {
        Player player;
        Map main;
        public Game() : base()
        {
            // Initialise the game
            Initialise(this); 
            // Set Game title
            GameTitle = "Example Game for Termine!";

            // Create main menu
            Menu main_menu = new Menu(this, true); // Menu(Game, show title)
            // Create menu item
            MenuItem start = new MenuItem("Start!", 0); // MenuItem(Text, Rank)
            MenuItem exit = new MenuItem("Exit!", 1); //
            MenuItem text = new MenuItem("Updated: Transparent Characters, Collison Detection, Custom Run loops", 4, MenuItem.MenuItemType.Text);
            // Add menu items to main menu
            main_menu.MenuItems.Add(start); // Add(MenuItem)
            main_menu.MenuItems.Add(exit);
            main_menu.MenuItems.Add(text);
            // Show the menu on screen
            int a = main_menu.Show(); 
            if(a ==1) { close(); } // closes the game when rank 1 is selected
            // Create the player
            player = new Player(SpriteLoader.LoadSpriteFromFile(BaseDirectory + "player.sprite")); // Player(Sprite)
               
            // Create the map
            main = new Map(MapLoader.LoadMapFromFile(BaseDirectory + "main.map")); // Map(MapSprite)
            main.CollidableChars.Add('0');
            // Set created player as the main player on the created map
            main.Player = player;
            // Run the game on the defined map
            Run(main); // Run(Map)
        }

        /// <summary>
        /// This method runs every frame
        /// </summary>
        public override void Running()
        {
            player.checkCollison(main);
        }
    }
}
