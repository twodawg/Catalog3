using System;
using System.Web;
using System.Web.Mvc;
using Catalog1.Models;
using System.Collections.Generic;

namespace Catalog1.Controllers
{
    public class ProductController : Controller
    {
        
        // GET: Product
        public ActionResult Index()
        {
            ViewBag.UserName = "Lord User";

            foreach (Product product in Cart.Instance.Products)
            {
                product.Price -= Decimal.Round(product.Price * 0.15m, 2);
            }

            return View(Cart.Instance.Products);
        }
        public ActionResult Detail(int id = 0)
        {
            return View(Cart.Instance.Products[id]);
        }

        public ActionResult ShoppingCart(int productID = 0, int amount = 0)
        {
            var product = Cart.Instance.Products[productID];
            product.Quantity -= amount;

            if (productID == 0 && amount == 0)
            {
                // No change
            }
            else if(Cart.Instance.ShoppingCartContents.Exists(x => x.Name == product.Name))
            {
                Cart.Instance.ShoppingCartContents.Find(x => x.Name == product.Name)
                    .Quantity += amount;
            }
            else
            {
                Cart.Instance.ShoppingCartContents.Add(
                    new Product(product.ProductID, product.Name, amount, product.Price,
                        product.Description));
            }

            ViewBag.PriceTotal = Cart.Instance.PriceTotal;

            return View(Cart.Instance.ShoppingCartContents);
        }
    }
}