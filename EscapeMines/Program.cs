using System;
using EscapeMines.Common;
using System.Threading;

namespace EscapeMines.Game
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var game = Common.MinesGameModels.Game.CreateNewGame();
                if (!game.Validate())
                {
                    game.Dispose();                    
                }

                else
                {
                    game.Start();
                    game.Dispose();
                }
                Thread.Sleep(60000);
                System.Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error starting game:\n {ex.Message}");
                throw;
            }                                  
        }
    }
}
