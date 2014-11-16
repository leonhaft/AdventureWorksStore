using AdventureWorksStore.Domain.Abstract;
using AdventureWorksStore.WebUI.Models;
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
        private int PageSize = 10;
        public ProductController(IProductRepository iRepository)
        {
            repository = iRepository;
        }
        //
        // GET: /Product/
        public ViewResult List(int page = 1)
        {
            ProductsListViewModel listViewModel = new ProductsListViewModel
            {
                PageInfo = new PageInfo { CurrentPage = page, PageSize = 10, TotalItems = repository.Products.Count() },
                Products = repository.Products.
                OrderBy(p => p.ProductID).
                Skip((page - 1) * PageSize).
                Take(PageSize)
            };
            return View(listViewModel);
        }
    }
}