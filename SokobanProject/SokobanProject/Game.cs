using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SokobanLocal
{
    class Game
    {
        public static void PlayGame()
        {
            Boolean GameWon = false;
            GameLevel gamelevel1 = new GameLevel(1);
            gamelevel1.PrintBoard();
            while (GameWon == false)
            {
                Console.WriteLine("W to go Up, A to go Left, S to go Down and D to go Right");
                ConsoleKey direction = Console.ReadKey().Key;
                Console.Clear();
                switch (direction)
                {
                    case ConsoleKey.UpArrow: 
                    case ConsoleKey.W : gamelevel1.Move(0);
                        break;
                    case ConsoleKey.LeftArrow:
                    case ConsoleKey.A: gamelevel1.Move(1);
                        break;
                    case ConsoleKey.DownArrow:
                    case ConsoleKey.S: gamelevel1.Move(2);
                        break;
                    case ConsoleKey.RightArrow:
                    case ConsoleKey.D: gamelevel1.Move(3);
                        break;
                    default:
                        Console.WriteLine("Didn't understand input");
                        break;
                }
                GameWon = gamelevel1.IsGameWon();
                gamelevel1.PrintBoard();
            }
            Console.WriteLine("Congratulations, you won the game");
        }
    }
}
