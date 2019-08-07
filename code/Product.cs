using System;
using System.Collections.Generic;
using System.Text;

namespace Space_Game
{
    class Product
    {
        public string ProductName { get; set; }
        public int Price { get; set; }
        public byte Planet { get; set; }
        public void AddProducts(List<Product> products)
        {
            products.Add(new Product() { ProductName = "Gold", Price = 100, Planet = 1 });
            products.Add(new Product() { ProductName = "Gold", Price = 50, Planet = 2 });
            products.Add(new Product() { ProductName = "Gold", Price = 5, Planet = 3 });
            products.Add(new Product() { ProductName = "Water", Price = 100, Planet = 1 });
            products.Add(new Product() { ProductName = "Water", Price = 5, Planet = 2 });
            products.Add(new Product() { ProductName = "Water", Price = 50, Planet = 3 });
            products.Add(new Product() { ProductName = "Liquid Soap", Price = 5, Planet = 1 });
            products.Add(new Product() { ProductName = "Liquid Soap", Price = 100, Planet = 2 });
            products.Add(new Product() { ProductName = "Liquid Soap", Price = 20, Planet = 3 });
            products.Add(new Product() { ProductName = "Styrofoam", Price = 5, Planet = 1 });
            products.Add(new Product() { ProductName = "Styrofoam", Price = 20, Planet = 2 });
            products.Add(new Product() { ProductName = "Styrofoam", Price = 100, Planet = 3 });
            products.Add(new Product() { ProductName = "Oatmeal Pies", Price = 50, Planet = 1 });
            products.Add(new Product() { ProductName = "Oatmeal Pies", Price = 100, Planet = 2 });
            products.Add(new Product() { ProductName = "Oatmeal Pies", Price = 5, Planet = 3 });
            products.Add(new Product() { ProductName = "Light Bulbs", Price = 20, Planet = 1 });
            products.Add(new Product() { ProductName = "Light Bulbs", Price = 5, Planet = 2 });
            products.Add(new Product() { ProductName = "Light Bulbs", Price = 100, Planet = 3 });
            products.Add(new Product() { ProductName = "The Heart of Gold Spaceship", Price = 5000, Planet = 1 });
        }
    }
}
