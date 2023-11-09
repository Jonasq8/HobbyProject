
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HobbyProject.NoteMenu.NoteEditingProgram
{
    public class NoteEditing
    {
        public void EditNote(List<string> lines)
        {
            bool closed = false;
            List<char[]> NoteGrid = createGrid(lines);

            int currentLine = NoteGrid.Count - 1;
            int? lastLine = null;

            int currentCharIndex = NoteGrid[currentLine].Length-1;
            int? lastCharIndex = null;

            while (!closed)
            {
                DrawLines(NoteGrid);
                ConsoleKeyInfo pressedKey = Console.ReadKey();
                switch (pressedKey.Key)
                {
                    case ConsoleKey.UpArrow:
                        MoveMarkerUp( ref currentLine, ref lastLine, ref currentCharIndex,ref lastCharIndex,  NoteGrid);
                        break;
                    case ConsoleKey.DownArrow:
                        MoveMarkerDown(ref currentLine, ref lastLine, ref currentCharIndex, ref lastCharIndex, NoteGrid);
                        break;
                    case ConsoleKey.RightArrow:
                        MoveMarkerRight(ref currentLine, ref lastLine, ref currentCharIndex, ref lastCharIndex, NoteGrid);
                        break;
                    default:
                        closed = true;
                        break;
                }
            }
        }

        private List<char[]> createGrid(List<string> lines)
        {
            List<char[]> grid = new List<char[]>();

            foreach (string line in lines)
            {
                if(line == null) continue;
                char[] chars = line.ToCharArray();
                grid.Add(chars);
            }
            return grid;
        }

        private static void DrawLines(List<char[]> lines)
        {
            Console.Clear();
            foreach (char[] line in lines)
            {
                Console.WriteLine(line);
            }
        }
        private void MoveMarkerRight(ref int currentLine, ref int? lastLine, ref int currentChar, ref int? lastChar, List<char[]> inputGrid)
        {
            
        }
        private void MoveMarkerDown(ref int currentLine, ref int? lastLine, ref int currentChar, ref int? lastChar, List<char[]> inputGrid)
        {
            List<char[]> NoteGrid = inputGrid;
            lastLine = currentLine;
            currentLine = currentLine + 1;
            //Console.WriteLine(lines[currentLine-1]);
            NoteGrid = UpdateGrid(currentLine, currentChar, '|', NoteGrid);
            if (lastLine != null)
            {
                string line = new string(NoteGrid[(int)lastLine]).Replace("|", "");
                NoteGrid[(int)lastLine] = line.ToCharArray();
            }

        }

        private static void MoveMarkerUp(ref int currentLine, ref int? lastLine, ref int currentChar, ref int? lastChar, List<char[]> inputGrid)
        {
            List<char[]> NoteGrid = inputGrid;
            lastLine = currentLine;
            currentLine = currentLine - 1;
            //Console.WriteLine(lines[currentLine-1]);
            NoteGrid = UpdateGrid(currentLine, currentChar, '|', NoteGrid);
            if (lastLine != null)
            { 
                string line = new string(NoteGrid[(int)lastLine]).Replace("|", "");
                NoteGrid[(int)lastLine] = line.ToCharArray();
            }
        }

        private static List<char[]> UpdateGrid(int LineIndex, int charIndex, char UpdateValue, List<char[]> NoteGrid)
        {
            string line = new string( NoteGrid[LineIndex]);
            line = line.Insert(charIndex, UpdateValue.ToString());
            NoteGrid[LineIndex] = line.ToCharArray();
            return NoteGrid;
        }

    }
}
