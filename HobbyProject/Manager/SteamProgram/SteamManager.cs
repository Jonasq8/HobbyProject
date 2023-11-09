using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HobbyProject.Manager.SteamProgram
{
    internal class SteamManager : ISteamManager
    {
        public void OpenSteam()
        {
            string SteamPath = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + @"\steam\steam.exe";
            Console.WriteLine($"Opening Steam at {SteamPath}");
            Process.Start(SteamPath);
          
        }
        public List<string> FindSteamGames()
        {
            List<string> gameFolders = null;
            try
            {
                
                string path = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + @"\Steam\steamapps\libraryfolders.vdf";

                StreamReader streamReader = new StreamReader(path);
                List<string> steamConfig = new List<string>();

                var line = streamReader.ReadLine();
                while (line != null)
                {

                    line = streamReader.ReadLine();
                    if (line != null)
                    {
                        steamConfig.Add(line);
                    }

                }
                streamReader.Close();
                List<string> steamLibaryPaths = findSteamLibary(steamConfig);
                gameFolders = FindGameFolders( steamLibaryPaths);
                

            }
            catch (Exception e)
            {
                Console.WriteLine($"Error:  {e}");
               
                
            }

            return gameFolders;
        }

        private  List<string> findSteamLibary(List<string> steamConfig)
        {
            List<string> steamLibaryPaths =

            new List<string>();
            foreach (var Configline in steamConfig)
            {
                if (Configline.Contains("path"))
                {
                    var trim = Configline.Replace("\"path\"", "").Replace("\"", "").Trim();
                    steamLibaryPaths.Add(trim + @"\steamapps\common\");
                }
            }

            return steamLibaryPaths;
        }

        private  List<string> FindGameFolders( List<string> steamLibaryPaths)
        {
            List<string> gameFolder = new List<string>();
            foreach (var item in steamLibaryPaths)
            {
                if (Directory.Exists(item))
                {
                    var array = Directory.GetDirectories(item);
                    foreach (var folder in array)
                    {
                        gameFolder.Add(folder);
                    }
                }

            }

            return gameFolder;
        }

    }
}
