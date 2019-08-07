using System;
using System.Collections.Generic;
using System.Text;

namespace Space_Game
{
    class Planet
    {
        public byte PlanetNum { get; set; }
        public string PlanetName { get; set; }
        public static string GetPlanetName(byte PlanetNum)
        {
            string PlanetName = "Earth";
            switch (PlanetNum)
            {
                case 1:
                    PlanetName = "Earth";
                    break;
                case 2:
                    PlanetName = "Proxima Centauri 1";
                    break;
                case 3:
                    PlanetName = "Bernard's Star 1";
                    break;
            }
            return PlanetName;
        }
        public static int GetFuel(int PlanetNum)
        {
            int price = 0;
            switch (PlanetNum)
            {
                case 1:
                    price = 1;
                    break;
                case 2:
                    price = 3;
                    break;
                case 3:
                    price = 2;
                    break;
            }
            return price;
        }
    }
}

