using AdventureWorksStore.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdventureWorksStore.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository repository;
        public ProductController(IProductRepository iRepository)
        {
            repository = iRepository;
        }
        //
        // GET: /Product/
        public ActionResult List()
        {
            return View(repository.Products);
        }
    }
}