using System;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using static System.Net.Mime.MediaTypeNames;
using System.Linq;
using System.Threading;

namespace Space_Game
{
    class Cutscenes
    {
        public static void PrintAnimation(string txt)
        {
            for (int i = 0; i < txt.Length; i++)
            {
                Console.Write(txt[i]);
                Thread.Sleep(20);
            }
        }

        public static void BowserCutscene()
        {
            Console.ResetColor();
            Console.SetCursorPosition(0, 0);
            for (int i = 0; i < 29; i++)
            {
                Console.WriteLine(new string(' ', 120));
            }
            Console.SetCursorPosition(0, 0);
            Menu.ClearMenuArea();
            string path = Path.Combine(Directory.GetCurrentDirectory(), "..\\..\\..\\..\\images/Bowser.bmp");
            Bitmap bmpSrc = new Bitmap(path, true);
            Console.SetCursorPosition(0,0);
            ConsoleWriteImage4(bmpSrc);
            Thread.Sleep(4000);
        }
        public static void EarthCutScene()
        {
            Menu.ClearMenuArea();
            string earthNear = $"\n\n                  You are now approaching {Planet.GetPlanetName(1)}";
            Cutscenes.PrintAnimation(earthNear);
            Thread.Sleep(1000);
            string path = Path.Combine(Directory.GetCurrentDirectory(), "..\\..\\..\\..\\images/Earth.bmp");
            Menu.ClearMenuArea();
            Console.SetCursorPosition(0, 0);
            Bitmap bmpSrc = new Bitmap(path, true);
            ConsoleWriteImage(bmpSrc);
            Thread.Sleep(1000);
            Console.SetCursorPosition(0, 0);
            Bitmap bmpSrc1 = new Bitmap(path, true);
            ConsoleWriteImage2(bmpSrc1);
            Thread.Sleep(1000);
            Console.SetCursorPosition(0, 0);
            Bitmap bmpSrc2 = new Bitmap(path, true);
            ConsoleWriteImage3(bmpSrc2);
            Thread.Sleep(1000);
            Menu.ClearMenuArea();
            string earthDescription = $"\n             Welcome to {Planet.GetPlanetName(1)}.\n             Earth is no longer a lush, green, wet planet, but now is a dry and grimy\n             industrial powerhouse.\n             Its primary output is Styrofoam and liquid soap.";
            Cutscenes.PrintAnimation(earthDescription);
            Thread.Sleep(1000);

        }

        public static void BarnardCutscene()
        {
            Menu.ClearMenuArea();
            string barnardNear = $"\n\n                  You are now approaching {Planet.GetPlanetName(3)}";
            Cutscenes.PrintAnimation(barnardNear);
            Thread.Sleep(1000);
            string path = Path.Combine(Directory.GetCurrentDirectory(), "..\\..\\..\\..\\images/Barnard.bmp");
            Menu.ClearMenuArea();
            Console.SetCursorPosition(1, 1);
            Bitmap bmpSrc = new Bitmap(path, true);
            ConsoleWriteImage(bmpSrc);
            Thread.Sleep(1000);
            Console.SetCursorPosition(1, 1);
            Bitmap bmpSrc1 = new Bitmap(path, true);
            ConsoleWriteImage2(bmpSrc1);
            Thread.Sleep(1000);
            Console.SetCursorPosition(1, 1);
            Bitmap bmpSrc2 = new Bitmap(path, true);
            ConsoleWriteImage3(bmpSrc2);
            Thread.Sleep(1000);
            Menu.ClearMenuArea();
            string barnardDescription = $"\n             Welcome to {Planet.GetPlanetName(3)}.\n             Bernard's Star B is a cold, dry, and dark planet, inhabited by short furry creatures known as ALFs.\n             However, they have mastered the ability for producing oatmeal cream pies, which all of the \n             planets desire. planet has a natural abundance of gold, which they consider worthless on their own planet,\n             but know that humans from Earth value it for some reason. They primarily\n             desire lightbulbs for not only lighting their dark planet, but as a primary food\n             source.  The many attempts by the ALFs to manufacture lightbulbs to supply\n             their own needs always fail; they eat them before they can develop\n             sufficient enough quantities to fulfill demand.";
            Cutscenes.PrintAnimation(barnardDescription);
            Thread.Sleep(1000);
        }

        public static void ProximaCutscene()
        {
            Menu.ClearMenuArea();
            string proximaNear = $"\n\n                  You are now approaching {Planet.GetPlanetName(2)}";
            Cutscenes.PrintAnimation(proximaNear);
            Thread.Sleep(1000);
            string path = Path.Combine(Directory.GetCurrentDirectory(), "..\\..\\..\\..\\images/Proxima.bmp");
            Menu.ClearMenuArea();
            Console.SetCursorPosition(0, 0);
            Bitmap bmpSrc = new Bitmap(path, true);
            ConsoleWriteImage(bmpSrc);
            Thread.Sleep(1000);
            Console.SetCursorPosition(0, 0);
            Bitmap bmpSrc1 = new Bitmap(path, true);
            ConsoleWriteImage2(bmpSrc1);
            Thread.Sleep(1000);
            Console.SetCursorPosition(0, 0);
            Bitmap bmpSrc2 = new Bitmap(path, true);
            ConsoleWriteImage3(bmpSrc2);
            Thread.Sleep(1000);
            Menu.ClearMenuArea();
            string proximaDescription = $"\n             Welcome to {Planet.GetPlanetName(2)}.\n             Proxima Centauri 1 is a windy, wet, and warm planet inhabited by a race of beings known as Cylons.\n             Their chief export is lightbulbs, which the Star B's devour and pay a premium for.\n             Their other primary export is water; which Earth requires to survive but is extremely heavy\n             and difficult to ship.\n             They subsist off liquid soap, oatmeal cream pies, and enjoy long walks on the beach.";
            Cutscenes.PrintAnimation(proximaDescription);
            Thread.Sleep(1000);
        }

        static int[] cColors = { 0x000000, 0x000080, 0x008000, 0x008080, 0x800000, 0x800080, 0x808000, 0xC0C0C0, 0x808080, 0x0000FF, 0x00FF00, 0x00FFFF, 0xFF0000, 0xFF00FF, 0xFFFF00, 0xFFFFFF };

        public static void ConsoleWritePixel(Color cValue)
        {
            Color[] cTable = cColors.Select(x => Color.FromArgb(x)).ToArray();
            char[] rList = new char[] { (char)9617, (char)9618, (char)9619, (char)9608 }; // 1/4, 2/4, 3/4, 4/4
            int[] bestHit = new int[] { 0, 0, 4, int.MaxValue }; //ForeColor, BackColor, Symbol, Score

            for (int rChar = rList.Length; rChar > 0; rChar--)
            {
                for (int cFore = 0; cFore < cTable.Length; cFore++)
                {
                    for (int cBack = 0; cBack < cTable.Length; cBack++)
                    {
                        int R = (cTable[cFore].R * rChar + cTable[cBack].R * (rList.Length - rChar)) / rList.Length;
                        int G = (cTable[cFore].G * rChar + cTable[cBack].G * (rList.Length - rChar)) / rList.Length;
                        int B = (cTable[cFore].B * rChar + cTable[cBack].B * (rList.Length - rChar)) / rList.Length;
                        int iScore = (cValue.R - R) * (cValue.R - R) + (cValue.G - G) * (cValue.G - G) + (cValue.B - B) * (cValue.B - B);
                        if (!(rChar > 1 && rChar < 4 && iScore > 50000)) // rule out too weird combinations
                        {
                            if (iScore < bestHit[3])
                            {
                                bestHit[3] = iScore; //Score
                                bestHit[0] = cFore;  //ForeColor
                                bestHit[1] = cBack;  //BackColor
                                bestHit[2] = rChar;  //Symbol
                            }
                        }
                    }
                }
            }
            Console.ForegroundColor = (ConsoleColor)bestHit[0];
            Console.BackgroundColor = (ConsoleColor)bestHit[1];
            Console.Write(rList[bestHit[2] - 1]);
        }


        public static void ConsoleWriteImage(Bitmap source)
        {
            int sMax = 20;
            decimal percent = Math.Min(decimal.Divide(sMax, source.Width), decimal.Divide(sMax, source.Height));
            Size dSize = new Size((int)(source.Width * percent), (int)(source.Height * percent));
            Bitmap bmpMax = new Bitmap(source, dSize.Width * 2, dSize.Height);
            for (int i = 0; i < dSize.Height; i++)
            {
                for (int j = 0; j < dSize.Width; j++)
                {
                    ConsoleWritePixel(bmpMax.GetPixel(j * 2, i));
                    ConsoleWritePixel(bmpMax.GetPixel(j * 2 + 1, i));
                }
                System.Console.WriteLine();
            }
            Console.ResetColor();
        }
        public static void ConsoleWriteImage2(Bitmap source)
        {
            int sMax = 23;
            decimal percent = Math.Min(decimal.Divide(sMax, source.Width), decimal.Divide(sMax, source.Height));
            Size dSize = new Size((int)(source.Width * percent), (int)(source.Height * percent));
            Bitmap bmpMax = new Bitmap(source, dSize.Width * 2, dSize.Height);
            for (int i = 0; i < dSize.Height; i++)
            {
                for (int j = 0; j < dSize.Width; j++)
                {
                    ConsoleWritePixel(bmpMax.GetPixel(j * 2, i));
                    ConsoleWritePixel(bmpMax.GetPixel(j * 2 + 1, i));
                }
                System.Console.WriteLine();
            }
            Console.ResetColor();
        }
        public static void ConsoleWriteImage3(Bitmap source)
        {
            int sMax = 26;
            decimal percent = Math.Min(decimal.Divide(sMax, source.Width), decimal.Divide(sMax, source.Height));
            Size dSize = new Size((int)(source.Width * percent), (int)(source.Height * percent));
            Bitmap bmpMax = new Bitmap(source, dSize.Width * 2, dSize.Height);
            for (int i = 0; i < dSize.Height; i++)
            {
                for (int j = 0; j < dSize.Width; j++)
                {
                    ConsoleWritePixel(bmpMax.GetPixel(j * 2, i));
                    ConsoleWritePixel(bmpMax.GetPixel(j * 2 + 1, i));
                }
                System.Console.WriteLine();
            }
            Console.ResetColor();
        }

        public static void ConsoleWriteImage4(Bitmap source)
        {
            int sMax = 55;
            decimal percent = Math.Min(decimal.Divide(sMax, source.Width), decimal.Divide(sMax, source.Height));
            Size dSize = new Size((int)(source.Width * percent), (int)(source.Height * percent));
            Bitmap bmpMax = new Bitmap(source, dSize.Width * 2, dSize.Height);
            for (int i = 0; i < dSize.Height; i++)
            {
                for (int j = 0; j < dSize.Width; j++)
                {
                    ConsoleWritePixel(bmpMax.GetPixel(j * 2, i));
                    ConsoleWritePixel(bmpMax.GetPixel(j * 2 + 1, i));
                }
                System.Console.WriteLine();
            }
            Console.ResetColor();
        }
    }
}
