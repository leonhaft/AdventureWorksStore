using AdventureWorksStore.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdventureWorksStore.WebUI.Controllers
{
    public class AdminController : Controller
    {
        private IProductRepository repository;
        public AdminController(IProductRepository iRepository)
        {
            repository = iRepository;
        }
        // GET: Admin
        public ActionResult Index()
        {
            return View(repository.Products);
        }

        public ViewResult Edit()
        {
            return View();
        }
    }
}