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
        private IOrderProcess order;
        public CartController(IProductRepository iProducRepository, IOrderProcess iOrder)
        {
            repository = iProducRepository;
            order = iOrder;
        }
        // GET: Cart
        public ActionResult Index(Cart cart, string returnUrl)
        {
            return View(new CartListViewModel { Cart = cart, ReturnUrl = returnUrl });
        }

        public PartialViewResult Summary(Cart cart)
        {
            return PartialView(cart);
        }
        public RedirectToRouteResult AddToCart(Cart cart, Int32 productId, string returnUrl)
        {
            var product = repository.Products.FirstOrDefault(s => s.ProductID == productId);
            if (product != null)
            {
                cart.AddToCart(product, 1);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToRouteResult RemoveFromCart(Cart cart, Int32 productId, string returnUrl)
        {
            var product = repository.Products.FirstOrDefault(s => s.ProductID == productId);
            if (product != null)
            {
                cart.RemoveFromCart(product);
            }
            return RedirectToAction("Index", new { returnUrl });
        }
        public ViewResult Checkout()
        {
            return View(new ShippingDetails());
        }
        [HttpPost]
        public ViewResult Checkout(Cart cart, ShippingDetails shippingInfo)
        {
            if (cart.CartItems.Any() == false)
            {
                ModelState.AddModelError("empty", "No Item In Cart");
            }
            if (ModelState.IsValid)
            {
                order.ProcessOrder(cart, shippingInfo);
                cart.Clear();
                return View("Completed");
            }
            else
            {
                return View(shippingInfo);
            }
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