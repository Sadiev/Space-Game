using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Space_Game
{
    class SpacePirate
    {
        public static void RobbedBySpacePirate(List<Product> inventories)
        {
            Random random = new Random();
            int randomNumber = random.Next(1, 6);

            if (randomNumber == 4)
            {
                Cutscenes.BowserCutscene();
                Menu.ClearMenuArea();
                Console.SetCursorPosition(4, 10);
                Console.WriteLine($"You've been robbed by space pirates on your way to {Planet.GetPlanetName(Global.currentPlanet)} and lost half of your precious inventory!!!");
                Console.SetCursorPosition(4, 12);
                Console.WriteLine($"Luckily, you escaped with your life.");
                Console.SetCursorPosition(6, 20);
                Console.WriteLine("Press the Space Bar to Continue.");
                while (Console.ReadKey(true).Key != ConsoleKey.Spacebar) ;

                //variables to hold the number of each item in the inventory
                int numOfGold = 0;
                int numOfwater = 0;
                int numOfLiquidSoap = 0;
                int numOfStyrofoam = 0;
                int numOfOatmeal = 0;
                int numOfLightBulbs = 0;

                //get the number of each item in the inventory
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

                //Make sure if the item is 1 in count, it's taken by the pirates, otherwise, take half of the number of that item.
                numOfGold = numOfGold <= 1 ? numOfGold = 1 : numOfGold /= 2;
                numOfwater = numOfwater <= 1 ? numOfwater = 1 : numOfwater /= 2;
                numOfLiquidSoap = numOfLiquidSoap <= 1 ? numOfLiquidSoap = 1 : numOfLiquidSoap /= 2;
                numOfStyrofoam = numOfStyrofoam <= 1 ? numOfStyrofoam = 1 : numOfStyrofoam /= 2;
                numOfOatmeal = numOfOatmeal <= 1 ? numOfOatmeal = 1 : numOfOatmeal /= 2;
                numOfLightBulbs = numOfLightBulbs <= 1 ? numOfLightBulbs = 1 : numOfLightBulbs /= 2;


                //Go from the bottom of the list upward and remove the correct amount of each type
                for (int i = inventories.Count - 1; i >= 0; i--)
                {
                    if (inventories[i].ProductName == "Gold" && numOfGold != 0)
                    {
                        inventories.RemoveAt(i);
                        numOfGold -= 1;
                    }
                }
                for (int i = inventories.Count - 1; i >= 0; i--)
                {
                    if (inventories[i].ProductName == "Water" && numOfwater != 0)
                    {
                        inventories.RemoveAt(i);
                        numOfwater -= 1;
                    }
                }
                for (int i = inventories.Count - 1; i >= 0; i--)
                {
                    if (inventories[i].ProductName == "Liquid Soap" && numOfLiquidSoap != 0)
                    {
                        inventories.RemoveAt(i);
                        numOfLiquidSoap -= 1;
                    }
                }
                for (int i = inventories.Count - 1; i >= 0; i--)
                {
                    if (inventories[i].ProductName == "Styrofoam" && numOfStyrofoam != 0)
                    {
                        inventories.RemoveAt(i);
                        numOfStyrofoam -= 1;
                    }
                }
                for (int i = inventories.Count - 1; i >= 0; i--)
                {
                    if (inventories[i].ProductName == "Oatmeal Pies" && numOfOatmeal != 0)
                    {
                        inventories.RemoveAt(i);
                        numOfOatmeal -= 1;
                    }
                }
                for (int i = inventories.Count - 1; i >= 0; i--)
                {
                    if (inventories[i].ProductName == "Light Bulbs" && numOfLightBulbs != 0)
                    {
                        inventories.RemoveAt(i);
                        numOfLightBulbs -= 1;
                    }
                }
            }
        }
    }
}
