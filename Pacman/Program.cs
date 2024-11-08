using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Pacman
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Parse the level txt file to GameState
            var levelLines = Properties.Resources.levels.Split('\n');
            char[,] level = new char[100,100];
            for (int i = 0; i < levelLines.Length; i++)
            {
                string line = levelLines[i];
                for (int j = 0; j < line.Length; j++)
                {
                    level[j, i] = line[j];
                }
            }
            GameState gameState = GameState.Create(level);
            Queue<ConsoleKey> keyQueue = new Queue<ConsoleKey>();

            // Run the game
            /* TODO: implement Collide methods for all actors and GameState.
            * After updating every actor the collide method will check
            * for collisions and return updated State instead of Actor
            * 
            * Also there's no need to update walls
            */
            while (true)
            {
                // Draw
                Console.Clear();
                foreach (Actor actor in gameState.actors)
                {
                    Console.SetCursorPosition(actor.position.x, actor.position.y);
                    Console.ForegroundColor = actor.Color;
                    Console.Write(actor.Character);
                }
                Console.SetCursorPosition(10, 12);
                Console.ForegroundColor = ConsoleColor.White;

                // TODO: make key detection more responsive
                if (Console.KeyAvailable)
                    keyQueue.Enqueue(Console.ReadKey().Key);
                gameState = gameState.Update(keyQueue);

                if (gameState.foods.list.Count() == 0)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("MAX WIN");
                    return;
                }

                Thread.Sleep(300);
            }
        }
    }
}
