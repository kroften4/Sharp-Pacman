using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Runtime.CompilerServices;

namespace Pacman
{
    internal class Program
    {
        static void DrawGame(GameState gameState)
        {
            Console.Clear();
            foreach (Actor actor in gameState.actors.list)
            {
                Console.SetCursorPosition(actor.position.x, actor.position.y);
                Console.ForegroundColor = actor.Color;
                Console.Write(actor.Character);
            }
            Console.SetCursorPosition(10, 12);
            Console.ForegroundColor = ConsoleColor.White;
        }
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
            DrawGame(gameState);

            // Run the game
            while (true)
            {
                Thread.Sleep(250);

                if (Console.KeyAvailable)
                {
                    keyQueue.Enqueue(Console.ReadKey(true).Key);
                    if (keyQueue.Count() > 4)
                        keyQueue.Dequeue();
                }
                gameState = gameState.Update(keyQueue);

                switch (gameState.status)
                {
                    case GameStatus.Won:
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine("MAX WIN");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("Press any key to exit...");
                        Console.ReadKey();
                        return;
                    case GameStatus.Lost:
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("GAME OVER");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("Press any key to exit...");
                        Console.ReadKey();
                        return;
                }

                DrawGame(gameState);
            }
        }
    }
}
