using HobbyProject.Manager.NoteProgram.Interface;
using HobbyProject.Utils;
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
        public  void OpenMainMenu()
        {
            bool isRunning = true;

            while (isRunning)
            {
                Console.WriteLine("  _    _      _ _              _                                                                                                \r\n | |  | |    | | |            | |                                                                                               \r\n | |__| | ___| | | ___        | | ___  _ __   __ _ ___                                                                          \r\n |  __  |/ _ \\ | |/ _ \\   _   | |/ _ \\| '_ \\ / _` / __|                                                                         \r\n | |  | |  __/ | | (_) | | |__| | (_) | | | | (_| \\__ \\                                                                         \r\n |_|  |_|\\___|_|_|\\___/   \\____/ \\___/|_| |_|\\__,_|___/                                                                         \r\n __          ___           _         _                 _     _                      _         _            _               ___  \r\n \\ \\        / / |         | |       | |               | |   | |                    | |       | |          | |             |__ \\ \r\n  \\ \\  /\\  / /| |__   __ _| |_   ___| |__   ___  _   _| | __| | __      _____    __| | ___   | |_ ___   __| | __ _ _   _     ) |\r\n   \\ \\/  \\/ / | '_ \\ / _` | __| / __| '_ \\ / _ \\| | | | |/ _` | \\ \\ /\\ / / _ \\  / _` |/ _ \\  | __/ _ \\ / _` |/ _` | | | |   / / \r\n    \\  /\\  /  | | | | (_| | |_  \\__ \\ | | | (_) | |_| | | (_| |  \\ V  V /  __/ | (_| | (_) | | || (_) | (_| | (_| | |_| |  |_|  \r\n     \\/  \\/   |_| |_|\\__,_|\\__| |___/_| |_|\\___/ \\__,_|_|\\__,_|   \\_/\\_/ \\___|  \\__,_|\\___/   \\__\\___/ \\__,_|\\__,_|\\__, |  (_)  \r\n                                                                                                                    __/ |       \r\n                                                                                                                   |___/        ");
                Console.WriteLine();
                WriteMainMenu();
                Console.Write(StaticText.PleaseWriteANumber);
                int anwser = int.Parse(Console.ReadLine());
                
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

        private  void OpenStocksMenu()
        {
            _stockMenu.OpenStockMenu();
        }

        private  void WriteMainMenu()
        {
            
            Console.WriteLine(StaticText.MainMenuText);
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
