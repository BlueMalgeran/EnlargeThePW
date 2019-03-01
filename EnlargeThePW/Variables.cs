using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnlargeThePW
{
    class Variables
    {
        public static string Version = "1.0.0";

        public static void Logo()
        {
            Console.WriteLine(@"

 ▄▄▄██▀▀▀▓█████  █     █░▓█████▄ ▓█████ ██▒   █▓
   ▒██   ▓█   ▀ ▓█░ █ ░█░▒██▀ ██▌▓█   ▀▓██░   █▒
   ░██   ▒███   ▒█░ █ ░█ ░██   █▌▒███   ▓██  █▒░
▓██▄██▓  ▒▓█  ▄ ░█░ █ ░█ ░▓█▄   ▌▒▓█  ▄  ▒██ █░░
 ▓███▒   ░▒████▒░░██▒██▓ ░▒████▓ ░▒████▒  ▒▀█░  
 ▒▓▒▒░   ░░ ▒░ ░░ ▓░▒ ▒   ▒▒▓  ▒ ░░ ▒░ ░  ░ ▐░  
 ▒ ░▒░    ░ ░  ░  ▒ ░ ░   ░ ▒  ▒  ░ ░  ░  ░ ░░  
 ░ ░ ░      ░     ░   ░   ░ ░  ░    ░       ░░  
 ░   ░      ░  ░    ░       ░       ░  ░     ░  
                          ░                 ░   ");
        }

        public static List<string> Lines = new List<string>();
        public static List<string> NewLines = new List<string>();
    }
}
