using HobbyProject.Utils;
using HobbyProject.Manager.NoteProgram;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using HobbyProject.Manager.NoteProgram.Interface;

namespace HobbyProject.Manager.NoteProgram
{
    internal class NoteProgramManager : INoteProgramManager
    {
        private string NotePath;

        public NoteProgramManager(string NotePath)
        {
            this.NotePath = NotePath;
        }

        public void DisplayNoteMenu()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("Note Menu: \r\n1. Make a new note?\r\n2. See all notes?\r\n3. Open a note?\r\n4. Delete a note\r\n0. Back");
            Console.Write("Write your anwser: ");
            int anwser = InputHandler.CheckStringForNumber(Console.ReadLine());
            if (anwser == -1)
            {
                DisplayNoteMenu();
            }
            else
            {
                Console.WriteLine(anwser);
            }

            switch (anwser)
            {
                case 0:
                    break;
                case 1:
                    CreateNewNote();
                    break;
                case 2:
                    GetNotes();
                    break;
                case 3:
                    OpenNote();
                    break;
                case 4:
                    DeleteNote();
                    break;
                default:
                    Console.WriteLine("Please write a number");
                    break;
            }
        }

        private void DeleteNote()
        {
            string[] Notes = GetNotes();
            int NoteNumber = InputHandler.CheckStringForNumber(Console.ReadLine()) - 1;

            if (NoteNumber < 0)
            {
                Console.WriteLine("Please write a number");
                OpenNote();
            }
            else
            {
                Console.WriteLine("Press Y to confirm");
                string confirmation = Console.ReadLine();
                if (confirmation.ToLower() == "y")
                {

                    File.Delete(Notes[NoteNumber]);
                    Console.WriteLine("You have succesfully delete af note ");
                }
                else
                {
                    Console.WriteLine("No note was deleted");
                }

                Console.Clear();

            }

        }

        private void OpenNote()
        {
            try
            {
                Console.Clear();

                string[] Notes = GetNotes();

                int fileNumber = InputHandler.CheckStringForNumber(Console.ReadLine()) - 1;

                if (fileNumber < 0)
                {
                    Console.WriteLine("Please write a number");
                    OpenNote();
                }
                else
                {
                    Console.Clear();
                    List<string> lines = new List<string>();
                    string line;
                    //Pass the file path and file name to the StreamReader constructor
                    StreamReader streamReader = new StreamReader($"{Notes[fileNumber]}");
                    //Read the first line of text
                    line = streamReader.ReadLine();
                    //Continue to read until you reach end of file
                    while (line != null)
                    {
                        //write the line to console window
                        //Console.WriteLine(line);
                        //Read the next line
                        line = streamReader.ReadLine();


                        lines.Add(line);



                    }
                    streamReader.Close();
                    NoteEditingManager noteEditing = new NoteEditingManager();
                    noteEditing.EditNote(lines);
                    //close the file

                    Console.WriteLine();
                    Console.WriteLine("Press any key to close file");
                    Console.ReadLine();

                }
                Console.Clear();

            }
            catch (Exception e)
            {

                Console.WriteLine("Exception: " + e.Message);
            }


        }



        private string[] GetNotes()
        {
            string path = NotePath;
            string[] files;
            try
            {
                files = Directory.GetFiles(path);
                int number = 1;
                foreach (string file in files)
                {
                    Console.WriteLine();
                    Console.WriteLine($"{number}: {file}");
                    Console.WriteLine();
                    number++;
                }

            }
            catch (Exception e)
            {
                files = null;
                Console.WriteLine("Exception: " + e.Message);
            }

            return files;

        }

        public void CreateNewNote()
        {
            Console.Write("Write the name of the Note: ");
            string answer = Console.ReadLine();
            string path = @$"{NotePath}{answer}.txt";
            try
            {
                using (StreamWriter sw = File.CreateText(path))
                    Console.WriteLine($"You have created a new file:  {answer}, at : {path}");
                Console.WriteLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }

        }

    }
}
