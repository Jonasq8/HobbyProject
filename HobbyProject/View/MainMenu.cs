using HobbyProject.Manager.NoteProgram;
using HobbyProject.Manager.NoteProgram.Interface;
using HobbyProject.Manager.SteamProgram;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HobbyProject.View
{
    internal class MainMenu
    {
        INoteProgramManager _noteProgramManager;


        public MainMenu(INoteProgramManager noteProgramManager)
        {
            this._noteProgramManager = noteProgramManager;

        }

        public void OpenMainMenu()
        {
            bool isRunning = true;

            while (isRunning)
            {
                Console.WriteLine("Hello, Jonas! What do you feel like doing today?");
                Console.WriteLine();


                WriteMenu();
                Console.Write("Please Write a number:  ");
                int anwser = int.Parse(Console.ReadLine());
                Console.WriteLine(anwser);

                switch (anwser)
                {
                    case 1:
                        NoteMenu();
                        break;
                    case 2:
                        OpenSteamMenu();
                        break; 
                    default:
                        break;
                }
            }
        }

        private  void WriteMenu()
        {
            string Menu = "1. Go to note Menu. \r\n2. Open Steam.\r\n3. Open Google Chrome\r\n4. Make divided Calculation\r\n5. Check Stocks\r\n6. Open Discord - And call møn\r\n";
            Console.WriteLine(Menu);
        }

        private  void NoteMenu()
        {
            _noteProgramManager.DisplayNoteMenu();
        }

        private void OpenSteamMenu() {
            SteamManager steamManager = new SteamManager();
            SteamMenu steamMenu = new SteamMenu(steamManager);
            steamMenu.DisplaySteamMenu();
        }

        

        

    }
}
