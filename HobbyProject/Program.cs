using HobbyProject.Manager.NoteProgram;
using HobbyProject.Manager.SteamProgram;
using HobbyProject.Manager.StockProgram;
using HobbyProject.View;
using HobbyProject.Manager.StockProgram.API;

internal class Program
{
    private static void Main(string[] args)
    {
        MainMenu mainMenu = new MainMenu(new NoteProgramManager(@"C:\Users\jonas\OneDrive\Dokumenter\Notepad Noter\"),
            new SteamMenu(
                new SteamManager()
                ),
            new StockMenu(
                new StockManager(
                    new StockApi()
                    )
                )
            );
        mainMenu.OpenMainMenu();
       
    }
}