using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        bool isRunning = true;

        while (isRunning)
        {

            Dictionary<string, string> typos = new Dictionary<string, string>
            {
            { "привет", "првиет" },
            { "пока", "пака"  },
            };

            Console.WriteLine("Choose your directory: ");

            string directory = Console.ReadLine();

            Console.WriteLine("Type 1 if you want to fix typos in file");
            Console.WriteLine("Type 2 if you want to replace phone numbers in file");
            Console.WriteLine("Type 3 to exit");

            int userChoice = Convert.ToInt32(Console.ReadLine());
            DirectoryInfo directoryInfo = new DirectoryInfo(directory);
            FileInfo[] files = directoryInfo.GetFiles("*.txt");

            if (userChoice != 1 && userChoice != 2 && userChoice != 3)
            {
                Console.WriteLine("you're not the brigthest one, huh? Idk, try again");

                userChoice = Convert.ToInt32(Console.ReadLine());
            }

            if (userChoice == 1)
            {
                foreach (var file in files)
                {
                    string content = File.ReadAllText(file.FullName);

                    foreach (var typo in typos)
                    {
                        content = content.Replace(typo.Value, typo.Key);
                    }

                    File.WriteAllText(file.FullName, content);
                }

                Console.WriteLine("Typos have been fixed :D ");
            }

            if (userChoice == 2)
            {
                foreach (var file in files)
                {
                    string content = File.ReadAllText(file.FullName);

                    content = Regex.Replace(content, @"\(\d{3}\) \d{3}-\d{2}-\d{2}", "+380 12 345 67 89");

                    File.WriteAllText(file.FullName, content);
                }

                Console.WriteLine("Phone numbers have been changed :D ");
            }

            if (userChoice == 3)
            {
                Console.WriteLine("death :D");
                Environment.Exit(0);
            }
        }
    }
}
