using HobbyProject.Manager.NoteProgram.Interface;
using HobbyProject.View.Interface;

namespace HobbyProject.View
{
    internal class MainMenu
    {
        INoteProgramManager _noteProgramManager;
        ISteamMenu _steamMenu;
        IStockMenu _stockMenu;

        public MainMenu(INoteProgramManager noteProgramManager, ISteamMenu steamMenu, IStockMenu stockMenu)
        {
            this._noteProgramManager = noteProgramManager;
            this._steamMenu = steamMenu;
            this._stockMenu = stockMenu;
        }
        public void OpenMainMenu()
        {
            bool isRunning = true;

            while (isRunning)
            {
                Console.WriteLine("Hello, Jonas! What do you feel like doing today?");
                Console.WriteLine();
                WriteMainMenu();
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
                    case 5:
                        OpenStocksMenu();
                        break;
                    default:
                        break;
                }
            }
        }

        private void OpenStocksMenu()
        {
            _stockMenu.OpenStockMenu();
        }

        private  void WriteMainMenu()
        {
            string Menu = "1. Go to note Menu. \r\n2. Open Steam.\r\n3. Open Google Chrome\r\n4. Make divided Calculation\r\n5. Check Stocks\r\n6. Open Discord - And call møn\r\n";
            Console.WriteLine(Menu);
        }
        private  void NoteMenu()
        {
            _noteProgramManager.DisplayNoteMenu();
        }
        private void OpenSteamMenu() {
            
            
            _steamMenu.DisplaySteamMenu();
        }
    }
}
