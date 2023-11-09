using HobbyProject.Manager.SteamProgram;
using HobbyProject.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace HobbyProject.View
{
    internal class SteamMenu
    {
        private ISteamManager _steamManager;
        public SteamMenu(ISteamManager steamManager)
        {
            this._steamManager = steamManager;
        }

        public void DisplaySteamMenu()
        {
            Console.WriteLine("Welcome to the Steam Menu\r\n\r\nWhat would you like to do? \r\n\r\n1. Open Steam\r\n2. Open a Game\r\n");
            int answer = int.Parse(Console.ReadLine());

            switch (answer)
            {

                case 1:
                    _steamManager.OpenSteam();
                    break;
                case 2:
                    OpenSteamGame();
                    break;
                default:
                    Console.WriteLine("Something when wrong");
                    break;

            }


            


        }

        private void OpenSteamGame()
        {
            List<string> gamesFolder = _steamManager.FindSteamGames();
            
            for (int i = 0; i < gamesFolder.Count; i++)
            {
                DisplayGameName(gamesFolder[i],i);
            }

            Console.WriteLine("Please Write Number of game to play");

            int anwser = InputHandler.CheckStringForNumber(Console.ReadLine());

            var exes = Directory.GetFiles(gamesFolder[anwser - 1], "*.exe");

            for (int i = 0; i < exes.Length; i++)
            {
                Console.WriteLine($"{i+1}: {exes[i]}");
            }

            Console.WriteLine("Please Write Number of game to play");

            int anwserexe = InputHandler.CheckStringForNumber(Console.ReadLine());

            Process.Start(exes[anwserexe-1]);


        }

        private static void DisplayGameName(string gameFolder, int number)
        {
            var array = gameFolder.Split(@"common\", StringSplitOptions.TrimEntries);
            Console.WriteLine($"{number+1}: {array[1]}");
            Console.WriteLine();
        }
    }
}
