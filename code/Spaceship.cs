using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Space_Game
{
    class Spaceship
    {
        public double WarpFactor { get; set; }
        public double travelMultiplier { get; set; }
        public double EarthToPC1 { get; set; } = 4.2441;
        public double EarthToBernard { get; set; } = 7.895;
        public double PC1ToBernard { get; set; } = 6.5;

        internal Spaceship()
        {
            WarpFactor = GetWarp();
            travelMultiplier = GetTravelMultiplier();

        }
        public void ReFuel() 
        {
            int fuelPrice = Planet.GetFuel(Global.currentPlanet);
            int diff = 100 - Global.gas;
            
            if(diff == 0)
            {
                Menu.ClearMenuArea();
                Console.SetCursorPosition(40, 10);
                Console.WriteLine("Gas is already Full!");
                Console.SetCursorPosition(25, 13);
                Console.WriteLine($"{Global.name}, please select an action by pressing a key from the menu below.");
                return;
            }
            
            for(int i = 0; i < diff; i++)
            {
                if (Global.money < fuelPrice)
                {
                    Menu.ClearMenuArea();
                    Console.SetCursorPosition(35, 10);
                    Console.WriteLine($"Could not fill tank. You filled {i} units.");
                    Console.SetCursorPosition(25, 13);
                    Console.WriteLine($"{Global.name}, please select an action by pressing a key from the menu below.");
                    return;
                }
                Global.money -= fuelPrice;
                Global.gas++;
            }
            Menu.ClearMenuArea();
            Console.SetCursorPosition(35, 10);
            Console.WriteLine("Ready to go!!! You filled the fuel tank.");
            Console.SetCursorPosition(25, 13);
            Console.WriteLine($"{Global.name}, please select an action by pressing a key from the menu below.");
        }

        public void Travel(List<Product> inventories) //change current position
        {
            bool fuelTravel = true;
            Menu.PrintMenu(true);
            int travelPlanet = Navigation().PlanetNum;
            
            int temp = Global.gas;
            if(Global.currentPlanet == 1 && travelPlanet == 2 || Global.currentPlanet == 2 && travelPlanet == 1)
            {
                Global.gas -= Convert.ToInt32(EarthToPC1 * travelMultiplier);
                if(Global.gas < 0)
                {
                    fuelTravel = false;
                    Menu.ClearMenuArea();
                    Global.gas = temp;
                    Console.SetCursorPosition(35, 10);
                    Console.WriteLine("Not enough Gas to travel...");
                    Console.SetCursorPosition(25, 13);
                    Console.WriteLine($"{Global.name}, please select an action by pressing a key from the menu below.");
                }
                else
                {
                    Global.age = Convert.ToByte(Global.age + EarthToPC1 / WarpFactor);
                    Global.currentPlanet = Convert.ToByte(travelPlanet);
                }
                
            }
            if (Global.currentPlanet == 1 && travelPlanet == 3 || Global.currentPlanet == 3 && travelPlanet == 1)
            {
                Global.gas -= Convert.ToInt32(EarthToBernard * travelMultiplier);
                if (Global.gas < 0)
                {
                    fuelTravel = false;
                    Menu.ClearMenuArea();
                    Global.gas = temp;
                    Console.SetCursorPosition(35, 10);
                    Console.WriteLine("Not enough Gas to travel...");
                    Console.SetCursorPosition(25, 13);
                    Console.WriteLine($"{Global.name}, please select an action by pressing a key from the menu below.");
                }
                else
                {
                    byte age = Convert.ToByte(Global.age + EarthToBernard / WarpFactor);
                    Global.age = age;
                    Global.currentPlanet = Convert.ToByte(travelPlanet);
                }
                
            }
            if (Global.currentPlanet == 2 && travelPlanet == 3 || Global.currentPlanet == 3 && travelPlanet == 2)
            {
                Global.gas -= Convert.ToInt32(PC1ToBernard * travelMultiplier);
                if (Global.gas < 0)
                {
                    fuelTravel = false;
                    Menu.ClearMenuArea();
                    Global.gas = temp;
                    Console.SetCursorPosition(35, 10);
                    Console.WriteLine("Not enough Gas to travel...");
                    Console.SetCursorPosition(25, 13);
                    Console.WriteLine($"{Global.name}, please select an action by pressing a key from the menu below.");
                }
                else
                {
                    byte age = Convert.ToByte(Global.age + PC1ToBernard / WarpFactor);
                    Global.age = age;
                    Global.currentPlanet = Convert.ToByte(travelPlanet);
                }
            }
            if (fuelTravel == false)
            {
                return;
            }
            else
            {
                SpacePirate.RobbedBySpacePirate(inventories);
                if (travelPlanet == 1)
                {
                    Cutscenes.EarthCutScene();
                }
                else if (travelPlanet == 2)
                {
                    Cutscenes.ProximaCutscene();
                }
                else if (travelPlanet == 3)
                {
                    Cutscenes.BarnardCutscene();
                }
            }
            return;
           
        }

        public double GetWarp()
        {
            if (Global.origin == 1)
            {
                return 2.0;
            }
            if (Global.origin == 2)
            {
                return 1.317;
            }
            if (Global.origin == 3)
            {
                return 1.621;
            }
            else
            {
                Menu.ClearMenuArea();
                Console.WriteLine("");
                return 1.0;
            }
        }

        static double GetTravelMultiplier()
        {
            switch (Global.origin)
            {
                case 1:
                    return 2;
                case 2:
                    return 1.0;
                case 3:
                    return 1.5;
                default:
                    Menu.ClearMenuArea();
                    Console.WriteLine("");
                    return 1.0;

            }
           
        }

        public override string ToString()
        {
            return $"Global.origin {Global.origin} WarpFactor {WarpFactor} Current Gas {Global.age}";
        }

        Planet Navigation()
        {
            List<Planet> planet = new List<Planet>()
                                            {
                                                new Planet() { PlanetName = "Earth", PlanetNum= 1 },
                                                new Planet() { PlanetName = "Proxima Centauri 1", PlanetNum= 2 },
                                                new Planet() { PlanetName = "Bernard's Star 1", PlanetNum= 3 }
                                            };

            var planetToRemove = planet.Single(r => r.PlanetNum == Global.currentPlanet);
            planet.Remove(planetToRemove);

            Menu.ClearMenuArea();
            planet.ForEach(x => { Console.WriteLine($"{x.PlanetName}"); });// print list of planets 

            ConsoleKeyInfo consoleKeyInfo;
            int index = 0;
          
            Console.SetCursorPosition(0, index);
            Console.ResetColor();
            Console.BackgroundColor = ConsoleColor.Blue;     
            Console.Write($"{planet[index].PlanetName}".PadRight(119, ' '));

            while ((consoleKeyInfo = Console.ReadKey()).Key != ConsoleKey.Enter)
            {
                switch (consoleKeyInfo.Key)
                {
                    case ConsoleKey.DownArrow:
                        index++;
                        if (index >= 0 && index < planet.Count)
                        {
                            Console.SetCursorPosition(0, index - 1);
                            Console.ResetColor();
                            Console.Write($"{planet[index - 1].PlanetName}".PadRight(119, ' ')); 
                            Console.SetCursorPosition(0, index);
                            Console.ResetColor();
                            Console.BackgroundColor = ConsoleColor.Blue;                    
                            Console.Write($"{planet[index].PlanetName}".PadRight(119, ' ')); 
                        }                    
                        else if (index >= planet.Count)
                        {
                            Console.SetCursorPosition(0, index - 1);
                            Console.ResetColor();
                            Console.Write($"{planet[index - 1].PlanetName}".PadRight(119, ' '));
                            index = 0;
                            Console.SetCursorPosition(0, index);
                            Console.ResetColor();
                            Console.BackgroundColor = ConsoleColor.Blue;                           
                            Console.Write($"{planet[index].PlanetName}".PadRight(119, ' '));
                        }
                        break;
                    case ConsoleKey.UpArrow:
                        index--;
                        if (index >= 0 && index < planet.Count)
                        {                  
                            Console.SetCursorPosition(0, index + 1);
                            Console.ResetColor();
                            Console.Write($"{planet[index + 1].PlanetName}".PadRight(119, ' '));
                            Console.SetCursorPosition(0, index);
                            Console.ResetColor();
                            Console.BackgroundColor = ConsoleColor.Blue;                    
                            Console.Write($"{planet[index].PlanetName}".PadRight(119, ' '));
                        }
                        else if (index < 0)
                        {
                            Console.SetCursorPosition(0, index + 1);
                            Console.ResetColor();                         
                            Console.Write($"{planet[index + 1].PlanetName}".PadRight(119, ' '));
                            index = planet.Count - 1;
                            Console.SetCursorPosition(0, index);
                            Console.ResetColor();
                            Console.BackgroundColor = ConsoleColor.Blue;                           
                            Console.Write($"{planet[index].PlanetName}".PadRight(119, ' '));
                        }
                        break;
                    default:
                        Console.Write("\b \b");
                        break;
                }             
            }   
            Console.ResetColor();
            return planet[index];
        }

    }
}
