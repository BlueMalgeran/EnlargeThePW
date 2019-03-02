using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EnlargeThePW
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.Write("Please type jewdev's BTC address here: ");
            var btc = Console.ReadLine();
            if (btc != "18Pi9W51XZS9zQVyfG8mWGUcSFtbc1rET7")
            {
                Console.WriteLine("nice try");
                Console.ReadKey();
                Environment.Exit(0);
            }
            Program.Welcome();
        }

        private static void Welcome()
        {
            Console.Clear();
            Console.Title = string.Format("EnlargeThePW | v{0} | by jewdev", Variables.Version);
            Variables.Logo();
            Console.WriteLine("[Welcome] Press any key to continue.");
            Console.ReadKey();
            Console.Clear();
            Program.FileForEnlarge();
        }

        private static void FileForEnlarge()
        {
            Console.WriteLine("Okay, please drag your file to the console.");

            string file = Console.ReadLine();
            bool removeBrackets = file.Contains("\"");
            string path;
            if (removeBrackets)
            {
                path = file.Replace("\"", "");
            }
            else
            {
                path = file;
            }

            Console.Clear();
            Variables.Lines = File.ReadLines(path).ToList<string>();
            Console.WriteLine("[Info] Loaded {0} lines from the file!", Variables.Lines.Count);
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
            Program.Enlargement();
        }

        private static void Enlargement()
        {
            Console.Clear();
            Console.WriteLine("Working... (If the file is BIG it will take a lot more time)");
            Console.WriteLine("Do NOT freakout if the console doesn't print anything!!!");
            foreach (string line in Variables.Lines)
            {
                string[] pw = line.Split(':');
                var result = Regex.Replace(pw[1], "^[a-z]", m => m.Value.ToUpper());
                Variables.NewLines.Add(pw[0] + ":" + result);
            }
            Variables.Lines.Clear();
            Program.SaveToFile();
        }

        private static void SaveToFile()
        {
            Console.Clear();
            Console.WriteLine("[Input] File name?");
            var filename = Console.ReadLine();
            File.WriteAllLines(filename + ".txt", Variables.NewLines);
            Variables.NewLines.Clear();
            Console.Clear();
            Console.WriteLine("[Info] Saved the file in the name you have chosen: {0}! (The file is probably in my file location!)", filename);
            Console.WriteLine("[Done] Press any key to close this program!");
            Console.ReadKey();
        }

        private static readonly Writer writer = new Writer();
    }
}