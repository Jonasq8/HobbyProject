

using HobbyProject.NoteMenu;

internal class Program
{
    private static void Main(string[] args)
    {
       
        bool isRunning = true;

        while (isRunning) {
            Console.WriteLine("Hello, Jonas! What do you feel like doing today?");
            Console.WriteLine(  );


            WriteMenu();
            Console.Write("Please Write a number:  ");
            int anwser = int.Parse(Console.ReadLine());
            Console.WriteLine(anwser);

            switch (anwser)
            {
                case 1:
                    NoteMenu();
                    break;


                default:
                    break;
            }

           

        }

        

        

    }

    private static void NoteMenu()
    {
        NoteProgram noteMenu = new NoteProgram(@"C:\Users\jonas\OneDrive\Dokumenter\Notepad Noter\");
        noteMenu.NoteMenu();
    }

    private static void WriteMenu()
    {
        string Menu = "1. Make a new note. \r\n2. Open Steam.\r\n3. Open Google Chrome\r\n4. Make divided Calculation\r\n5. Check Stocks\r\n6. Open Discord - And call møn\r\n";
        Console.WriteLine(Menu);
        

    }
}