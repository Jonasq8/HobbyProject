using HobbyProject.Manager.NoteProgram;
using HobbyProject.Manager.SteamProgram;
using HobbyProject.View;

internal class Program
{
    private static void Main(string[] args)
    {
        MainMenu mainMenu = new MainMenu(new NoteProgramManager(@"C:\Users\jonas\OneDrive\Dokumenter\Notepad Noter\"));
        mainMenu.OpenMainMenu();
    }
}