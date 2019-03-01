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
    class Program
    {
        private static void Main(string[] args)
        {
            Program.Welcome();
        }

        private static void Welcome()
        {
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
            Console.WriteLine("Working... (If the file is BIG it will take a lot more time)");
            foreach (string line in Variables.Lines)
            {
                string[] pw = line.Split(':');
                string result = string.Format(pw[0] + ":" + pw[1].First().ToString().ToUpper() + pw[1].Substring(1));
                Variables.NewLines.Add(result);
                Console.Title = string.Format("EnlargeThePW | v{0} | {1}/{2} lines | by jewdev", Variables.Version, Variables.NewLines.Count, Variables.Lines.Count);
            }
            Variables.Lines.Clear();
            Program.SaveToFile();
        }

        private static void SaveToFile()
        {
            Console.Clear();
            Console.WriteLine("[Input] File name?");
            var filename = Console.ReadLine();
            foreach (string textToAppend in Variables.NewLines)
            {
                Program.writer.FilePath = filename + ".txt";
                Program.writer.AppendToFile(textToAppend);
            }
            Variables.NewLines.Clear();
            Console.Clear();
            Console.WriteLine("[Info] Saved the file in the name you have chosen: {0}! (The file is probably in my file location!)", filename);
            Console.WriteLine("[Done] Press any key to close this program!");
            Console.ReadKey();
        }

        private static readonly Writer writer = new Writer();
    }
}
