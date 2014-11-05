using System;

namespace Catalog1.Models
{
    public class Product
    {
        public Product(int id, string name, int quantity, Decimal price, 
            string description)
        {
            ProductID = id;
            Name = name;
            Quantity = quantity;
            Price = price;
            Description = description;
        }
        public int ProductID { get; set; }

        public string Name { get; set; }

        public int Quantity { get; set; }

        public Decimal Price { get; set; }

        public string Description { get; set; }

        public string ImageSmall
        {
            get
            {
                return "http://placehold.it/320x150";
            }
        }
        public string ImageLarge
        {
            get
            {
                return "http://placehold.it/800x300";
            }
        }
    }
}