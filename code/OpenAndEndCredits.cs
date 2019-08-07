using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Threading;

namespace Space_Game
{
    class OpenAndEndCredits
    {
        static public void OpeningCredits()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "..\\..\\..\\intro.txt");
            StoryWriter(path);

        }

        static public void WinEndingCredits()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "..\\..\\..\\win.txt");
            StoryWriter(path);
        }

        static public void LoseEndingCredits()
        {

            string path = Path.Combine(Directory.GetCurrentDirectory(), "..\\..\\..\\lose.txt");
            StoryWriter(path);

        }
        static private void StoryWriter(string path)
        {
            string line;
            StreamReader file = new System.IO.StreamReader(path);
            do
            {
                
                line = null;
                for (int i = 0; i < 5; i++)
                {
                    line = file.ReadLine();
                    Console.SetCursorPosition(20, 10 + i);
                    if (line != null)
                    {
                        for (int j = 0; j < line.Length; j++)
                        {
                            Console.Write(line[j]);
                            Thread.Sleep(20);
                        }
                    }
                }
                Console.SetCursorPosition(20, 20);
                Console.WriteLine("Press the Space Bar to Continue...");
                while (Console.ReadKey(true).Key != ConsoleKey.Spacebar);
                Menu.ClearMenuArea();
            } while (line != null);
            file.Close();
        }
    }
}
