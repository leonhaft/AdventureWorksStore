using AdventureWorksStore.Domain.Abstract;
using AdventureWorksStore.Domain.Entities;
using AdventureWorksStore.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdventureWorksStore.WebUI.Controllers
{
    public class CartController : Controller
    {
        private IProductRepository repository;
        public CartController(IProductRepository iProducRepository)
        {
            repository = iProducRepository;
        }
        // GET: Cart
        public ActionResult Index(string returnUrl)
        {
            var cart = GetCart();
            return View(new CartListViewModel { Cart = cart, ReturnUrl = returnUrl });
        }

        public RedirectToRouteResult AddToCart(Int32 productId, string returnUrl)
        {
            var cart = GetCart();
            var product = repository.Products.FirstOrDefault(s => s.ProductID == productId);
            if (product != null)
            {
                cart.AddToCart(product, 1);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToRouteResult RemoveFromCart(Int32 productId, string returnUrl)
        {
            var product = repository.Products.FirstOrDefault(s => s.ProductID == productId);
            if (product != null)
            {
                var cart = GetCart();
                cart.RemoveFromCart(product);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public Cart GetCart()
        {
            var cart = Session["Cart"];
            if (cart == null)
            {
                var newCart = new Cart();
                Session["Cart"] = newCart;
                return newCart;
            }
            else
            {
                return cart as Cart;
            }
        }
    }
}