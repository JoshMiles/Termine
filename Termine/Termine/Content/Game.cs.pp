using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Termine;
namespace $rootnamespace$
{
    class Game : Termine.Game
    {
        public Game() : base()
        {
            Initialise(this); // Initialise the engine

            GameTitle = "Example Game!"; // Set the Game's Title
        }

        public override void Running()
        {
            // Runs every frame update
        }
    }
}
