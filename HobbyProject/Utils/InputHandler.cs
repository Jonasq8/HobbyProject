using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HobbyProject.Utils
{
    internal class InputHandler
    {

        public static int CheckStringForNumber(string answer)
        {
            int result;
            if(int.TryParse(answer, out int number))
            {
                result = number;
            }
            else
            {
                
                result = -1;
            }
            return result;
        }

    }
}
