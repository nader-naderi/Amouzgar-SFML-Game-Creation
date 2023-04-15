using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace MyFirstSFMLGame
{
    public class Program
    {

        static void Main(string[] args)
        {
            Game game = new Game();
            Game.Instance = game;

            game.Run();
        }

        
    }
}