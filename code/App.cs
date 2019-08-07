using System;
using System.Collections.Generic;
using System.Text;

namespace Space_Game
{
    class App
    {
        
        public void Run()
        {
            

            Planet earth = new Planet();

            Spaceship userSpaceship = new Spaceship(); //<--This class appears to be broken

            Product product = new Product();

            List<Product> products = new List<Product>();
            List<Product> inventories = new List<Product>();
            product.AddProducts(products);

            // Set the window size (left number is column, right number is row), need to do this only when we first run the program.
            Console.SetWindowSize(150, 40);

            //Need to do this only when we first run the program.
            Console.SetWindowPosition(0, 0);

            // Set the buffer size of console, need to do this only when we first run the program.
            Console.SetBufferSize(150, 40);

            Menu menu = new Menu();
            
            // Draw the the right and bottom boxes
            PrintSideBottomMenu(inventories, userSpaceship);
            menu.KeyCatch(inventories, products);
            
        }
        static public void PrintSideBottomMenu(List<Product> inventories, Spaceship userSpaceship)
        {
            int numOfGold = 0;
            int numOfwater = 0;
            int numOfLiquidSoap = 0;
            int numOfStyrofoam = 0;
            int numOfOatmeal = 0;
            int numOfLightBulbs = 0;
            int numOfHeartOfGold = 0;

            for (int i = 0; i < 31; i++)
            {
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.SetCursorPosition(120, i);
                Console.WriteLine(" ");
                Console.BackgroundColor = ConsoleColor.Black;
            }
            //Put current planet, Age, Fuel level, and Money in the right box.

            Planet currentPlanet = new Planet();
            string currentPlanetName = Planet.GetPlanetName(Global.currentPlanet);


            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.SetCursorPosition(122, 0);
            Console.WriteLine($"----==={Global.name}'s Stats===----".PadRight(28, ' '));
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(122, 1);
            Console.WriteLine($"     Age: {Global.age}".PadRight(18,' '));
            Console.SetCursorPosition(122, 3);
            Console.WriteLine($"    Fuel: {Global.gas}".PadRight(18,' '));
            Console.SetCursorPosition(122, 5);
            Console.WriteLine($"  Wallet: {Global.money} Cubits".PadRight(20,' '));
            Console.SetCursorPosition(122, 7);
            Console.WriteLine($"Location: {currentPlanetName.PadRight(18,' ')}");
            Console.SetCursorPosition(122, 9);
            Console.WriteLine($"Max Warp: {userSpaceship.GetWarp()}".PadRight(18, ' '));
            Console.SetCursorPosition(122,11);



            //Put current inventory in the bottom box
            for (int i = 0; i < inventories.Count; i++)
            {
                if (inventories[i].ProductName == "Gold")
                    numOfGold += 1;
            }
            for (int i = 0; i < inventories.Count; i++)
            {
                if (inventories[i].ProductName == "Water")
                    numOfwater += 1;
            }
            for (int i = 0; i < inventories.Count; i++)
            {
                if (inventories[i].ProductName == "Liquid Soap")
                    numOfLiquidSoap += 1;
            }
            for (int i = 0; i < inventories.Count; i++)
            {
                if (inventories[i].ProductName == "Styrofoam")
                    numOfStyrofoam += 1;
            }
            for (int i = 0; i < inventories.Count; i++)
            {
                if (inventories[i].ProductName == "Oatmeal Pies")
                    numOfOatmeal += 1;
            }
            for (int i = 0; i < inventories.Count; i++)
            {
                if (inventories[i].ProductName == "Light Bulbs")
                    numOfLightBulbs += 1;
            }
            for (int i = 0; i < inventories.Count; i++)
            {
                if (inventories[i].ProductName == "The Heart of Gold Spaceship")
                    numOfHeartOfGold += 1;
            }

            for (int i = 0; i < 150; i++)
            {
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.SetCursorPosition(i, 30);
                Console.WriteLine(" ");
                Console.BackgroundColor = ConsoleColor.Black;
            }
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.SetCursorPosition(0, 31);
            Console.WriteLine("--------=====Inventory=====--------");
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(0, 32);
            Console.WriteLine($"       Gold: {numOfGold}".PadRight(18, ' '));
            Console.SetCursorPosition(0, 33);
            Console.WriteLine($"      Water: {numOfwater}".PadRight(18, ' '));
            Console.SetCursorPosition(0, 34);
            Console.WriteLine($"Liquid Soap: {numOfLiquidSoap}".PadRight(18, ' '));
            Console.SetCursorPosition(20, 32);
            Console.WriteLine($"   Styrofoam: {numOfStyrofoam}".PadRight(18, ' '));
            Console.SetCursorPosition(20, 33);
            Console.WriteLine($"Oatmeal Pies: {numOfOatmeal}".PadRight(18, ' '));
            Console.SetCursorPosition(20, 34);
            Console.WriteLine($" Light Bulbs: {numOfLightBulbs}".PadRight(18, ' '));
            Console.WriteLine($" ");
            Console.WriteLine($" ");
            Console.WriteLine($" ");

            if (numOfHeartOfGold >= 1)
            {
                Menu.ClearMenuArea();
                OpenAndEndCredits.WinEndingCredits();
                Console.SetCursorPosition(20, 10);
                Console.WriteLine("Press the Space Bar to exit the game.");
                while (Console.ReadKey(true).Key != ConsoleKey.Spacebar);
                Console.Clear();
                Environment.Exit(0);

            }
            if (Global.age >= 60 || Global.money == 0 && numOfGold == 0 && numOfLightBulbs == 0 && numOfLiquidSoap == 0 && numOfOatmeal == 0 && numOfwater == 0 && numOfStyrofoam == 0)
            {
                Menu.ClearMenuArea();
                OpenAndEndCredits.LoseEndingCredits();
                Console.SetCursorPosition(20, 10);
                Console.WriteLine("Press the Space Bar to exit the game.");
                while (Console.ReadKey(true).Key != ConsoleKey.Spacebar) ;
                Console.Clear();
                Environment.Exit(0);
            }
        }
        
    }
}
