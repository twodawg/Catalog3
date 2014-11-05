using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Catalog1.Models
{
    public class Cart
    {
        List<Product> shoppingCartContents;
        List<Product> products;

        // Singleton pattern

        static readonly Cart _instance = new Cart();

        public static Cart Instance
        {
            get
            {
                return _instance;
            }
        }

        private Cart()
        {
            shoppingCartContents = new List<Product>();

            products = new List<Product>()
            {
                {new Product(0,"Widget",10,2.50m,"Normal everyday widget")},
                {new Product(1,"SuperWidget",20,12.99m,"A better widget")},
                {new Product(2,"MegaWidget",25,79.99m,"Mega super better widget")},
                {new Product(3,"iWidget",18,101.99m,"An Apple widget with twice the goodness")},
                {new Product(4,"WidgetKitchen",4,10.98m,"Get the kitchen widget now")},
            };
        }

        public List<Product> ShoppingCartContents
        {
            get
            {
                return shoppingCartContents;
            }
        }
        public List<Product> Products
        {
            get
            {
                return products;
            }
        }
        public Decimal PriceTotal
        {
            get
            {
                Decimal total = 0m;

                foreach( Product productItem in shoppingCartContents)
                {
                    total += productItem.Quantity * productItem.Price;
                }
                return total;
            }
        }
    }
}