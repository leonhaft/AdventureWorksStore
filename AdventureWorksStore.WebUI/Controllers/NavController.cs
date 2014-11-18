using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AdventureWorksStore.Domain.Concrete;
using AdventureWorksStore.Domain.Abstract;

namespace AdventureWorksStore.WebUI.Controllers
{
    public class NavController : Controller
    {
        private IProductRepository repository;
        public NavController(IProductRepository rep)
        {
            repository = rep;
        }
        // GET: Nav
        public PartialViewResult Menu(string category)
        {
            ViewBag.Category = category;
            return PartialView(repository.Products.Select(c => c.Category).Distinct());
        }
    }
}