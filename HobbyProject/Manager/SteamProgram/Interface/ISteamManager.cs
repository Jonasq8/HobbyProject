using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HobbyProject.Manager.SteamProgram.Interface
{
    internal interface ISteamManager
    {
        public void OpenSteam();
        public List<string> FindSteamGames();

        public void OpenGameEXE(string[] exes, int anwserexe);
    }
}
