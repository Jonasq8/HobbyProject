
namespace HobbyProject.Manager.NoteProgram
{
    public class NoteEditingManager
    {
        public void EditNote(List<string> lines)
        {
            bool closed = false;
            List<char[]> NoteGrid = CreateGrid(lines);

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
                    case ConsoleKey.LeftArrow:
                        MoveMarkerLeft(ref currentLine, ref lastLine, ref currentCharIndex, ref lastCharIndex, NoteGrid);
                        break;
                    default:
                        WriteKey(pressedKey, ref currentLine, ref lastLine, ref currentCharIndex, ref lastCharIndex, NoteGrid);
                        break;
                }
            }
        }

        private void WriteKey(ConsoleKeyInfo pressedKey, ref int currentLine, ref int? lastLine, ref int currentChar, ref int? lastChar, List<char[]> inputGrid)
        {
            Console.WriteLine(pressedKey.Key.ToString());
            WriteText(pressedKey, ref currentLine, ref lastLine, ref currentChar, ref lastChar, inputGrid);


        }

        private static List<char[]> WriteText(ConsoleKeyInfo pressedKey, ref int currentLine, ref int? lastLine, ref int currentChar, ref int? lastChar, List<char[]> NoteGrid)
        {

            var line = new string( NoteGrid[currentLine]);
            line = line.Insert(currentChar, pressedKey.Key.ToString());
            NoteGrid[currentLine] = line.ToCharArray();
            currentChar++;
            return NoteGrid;
        }

        private List<char[]> CreateGrid(List<string> lines)
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


        private void MoveMarkerLeft(ref int currentLine, ref int? lastLine, ref int currentChar, ref int? lastChar, List<char[]> inputGrid)
        {
            List<char[]> NoteGrid = inputGrid;
            lastLine = currentLine;
            lastChar = currentChar;
            currentChar = currentChar - 1;
            if (currentChar < 0)
            {
                currentChar++;
                lastLine--;
            }

            UpdateGridWithCurcer(ref currentLine, lastLine, currentChar, lastChar, NoteGrid);

        }

        private void MoveMarkerRight(ref int currentLine, ref int? lastLine, ref int currentChar, ref int? lastChar, List<char[]> inputGrid)
        {
            List<char[]> NoteGrid = inputGrid;
            lastLine = currentLine;
            lastChar = currentChar;
            currentChar = currentChar + 1;
            if(currentChar > inputGrid[currentLine].Length-1)
            {
                currentChar--;
                currentLine++;
                if (currentLine > inputGrid.Count - 1)
                {
                    inputGrid.Add(new char[0]);
                }
            }
            UpdateGridWithCurcer(ref currentLine, lastLine, currentChar, lastChar, NoteGrid);

        }

        private void MoveMarkerDown(ref int currentLine, ref int? lastLine, ref int currentChar, ref int? lastChar, List<char[]> inputGrid)
        {
            List<char[]> NoteGrid = inputGrid;
            lastLine = currentLine;
            lastChar = currentChar;
            currentLine = currentLine + 1;
            //Console.WriteLine(lines[currentLine-1]);
            if (currentLine > inputGrid.Count-1)
            {
                inputGrid.Add(new char[0]);
            }
                NoteGrid = UpdateGridWithCurcer(ref currentLine, lastLine, currentChar, lastChar, NoteGrid);
            
            



        }

        private static void MoveMarkerUp(ref int currentLine, ref int? lastLine, ref int currentChar, ref int? lastChar, List<char[]> inputGrid)
        {
            List<char[]> NoteGrid = inputGrid;
            lastLine = currentLine;
            lastChar = currentChar;
            currentLine = currentLine - 1;
            //Console.WriteLine(lines[currentLine-1]);
            NoteGrid = UpdateGridWithCurcer(ref currentLine, lastLine, currentChar,lastChar, NoteGrid);
        }

        private static List<char[]> UpdateGridWithCurcer(ref int currentLine, int? lastLine, int currentChar, int? lastChar, List<char[]> NoteGrid)
        {
            if (currentLine < NoteGrid.Count  )
            {
                if (currentLine >= 0)
                {


                    if (currentChar > NoteGrid[currentLine].Length)
                    {
                        currentChar = NoteGrid[currentLine].Length;
                    }
                    if (lastLine != null)
                    {
                        if (lastChar + 1 == currentChar || lastChar - 1 == currentChar)
                        {
                            string removeWithinLine = new string(NoteGrid[(int)currentLine]).Replace("|", "");
                            NoteGrid[(int)lastLine] = removeWithinLine.ToCharArray();
                        }
                        else
                        {
                            string replacestring = new string(NoteGrid[(int)lastLine]).Replace("|", "");
                            NoteGrid[(int)lastLine] = replacestring.ToCharArray();
                        }

                    }
                    string line = new string(NoteGrid[currentLine]);
                    line = line.Insert(currentChar, "|");
                    NoteGrid[currentLine] = line.ToCharArray();
                }else
                {
                    currentLine = 0;
                }
            }
            else
            {
                
                currentLine = NoteGrid.Count;
                
            }
                
            

           
            return NoteGrid;
        }

    }
}
