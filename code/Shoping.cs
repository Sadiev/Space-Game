using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Space_Game
{
    class Shoping
    {
        List<Product> market = new List<Product>();
        List<Product> menuList = new List<Product>();
        public Shoping(List<Product> products)
        {
            market = products;
        }
        public Product FindPrice(Product item)
        {
            return market.Find(x => x.ProductName == item.ProductName && x.Planet == Global.currentPlanet);
        }

        public bool Buy(List<Product> inventory, Product item)
        {
            if (item != null && item.Price <= Global.money)
            {
                Global.money -= item.Price;
                inventory.Add(item);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Sell(List<Product> inventory, Product item)
        {
            if(item!=null)
            {
                inventory.Remove(item);
                Global.money += item.Price;
                return true;
            }
            return false;
            
        }

        public bool PrintSellList(List<Product> inventory)
        {          
            if (inventory.Count <= 0)
            {
                return false;
            }
            else
            {
                menuList.Clear();
                
                Menu.ClearMenuArea();
                Menu.PrintMenu(true);
                Console.SetCursorPosition(0, 0);
                foreach (var item in inventory)
                {
                    item.Price = FindPrice(item).Price;
                    Console.WriteLine($"{item.ProductName} {item.Price}");
                    menuList.Add(item);
                }
                return Sell(inventory, Navigation(inventory));               
            }
            
        }

        public bool PrintBuyList(List<Product> inventory)
        {
            menuList.Clear();
            
            Menu.ClearMenuArea();
            Menu.PrintMenu(true);
            Console.SetCursorPosition(0, 0);
            foreach (var item in market)
            {
                    if (item.Planet==Global.currentPlanet)
                    {
                        Console.WriteLine($"{item.ProductName} {item.Price}");
                        menuList.Add(item);
                    }                   
            }               
            return Buy(inventory, Navigation(inventory));
        }

        Product Navigation(List<Product> inventory)
        {
            int index = 0;
            bool exit = false;

            Console.SetCursorPosition(0, index);
            Console.ResetColor();
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.Write($"{menuList[index].ProductName} {menuList[index].Price}".PadRight(119, ' ')); // Rewrite it with matching index array item

            while (!exit )
            {                
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.DownArrow:
                    index++;
                    if (index >= 0 && index < menuList.Count)
                    {
                        Console.SetCursorPosition(0, index - 1);
                        Console.ResetColor();    
                        Console.Write($"{menuList[index - 1].ProductName} {menuList[index - 1].Price}".PadRight(119, ' '));
                        Console.SetCursorPosition(0, index);
                        Console.ResetColor();
                        Console.BackgroundColor = ConsoleColor.Blue;
                        Console.Write($"{menuList[index].ProductName} {menuList[index].Price}".PadRight(119, ' '));
                    }
                    else if(index >= menuList.Count)
                    {
                        Console.SetCursorPosition(0, index-1 );
                        Console.ResetColor();
                        Console.Write($"{menuList[index - 1].ProductName} {menuList[index - 1].Price}".PadRight(119, ' '));
                        index = 0;
                        Console.SetCursorPosition(0, index);
                        Console.ResetColor();
                        Console.BackgroundColor = ConsoleColor.Blue;
                        Console.Write($"{menuList[index].ProductName} {menuList[index].Price}".PadRight(119, ' '));
                    }
                        break;
                    case ConsoleKey.UpArrow:
                        index--;
                        if (index >= 0 && index < menuList.Count)
                        {
                            Console.SetCursorPosition(0, index + 1);
                            Console.ResetColor();
                            Console.Write($"{menuList[index + 1].ProductName} {menuList[index + 1].Price}".PadRight(119, ' '));
                            Console.SetCursorPosition(0, index);
                            Console.ResetColor();
                            Console.BackgroundColor = ConsoleColor.Blue;
                            Console.Write($"{menuList[index].ProductName} {menuList[index].Price}".PadRight(119, ' '));
                        }
                        else if (index < 0)
                        {
                            Console.SetCursorPosition(0, index+1 );
                            Console.ResetColor();
                            Console.Write($"{menuList[index+1].ProductName} {menuList[index+1].Price}".PadRight(119, ' '));
                            index = menuList.Count-1;
                            Console.SetCursorPosition(0, index);
                            Console.ResetColor();
                            Console.BackgroundColor = ConsoleColor.Blue;
                            Console.Write($"{menuList[index].ProductName} {menuList[index].Price}".PadRight(119, ' '));
                        }
                        break;
                    case ConsoleKey.Escape:
                        exit = true;                       
                        break;
                    case ConsoleKey.Enter:
                        exit = true;
                        Console.ResetColor();
                        return menuList[index];
                    default:
                        Console.Write("\b \b");
                        break;
                }              
            }
            Console.ResetColor();
            return null;

        }

    }
}
