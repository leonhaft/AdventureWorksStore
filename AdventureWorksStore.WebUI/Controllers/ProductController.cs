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
        public ViewResult List(string category = null, int page = 1)
        {
            ProductsListViewModel listViewModel = new ProductsListViewModel
            {
                PageInfo = new PageInfo { CurrentPage = page, PageSize = 10, TotalItems = category == null ? repository.Products.Count() : repository.Products.Where(s => s.Category == category).Count() },
                CurrentCategory = category,
                Products = repository.Products.Where(p => (category == null && p.Category != null) || p.Category == category).
                OrderBy(p => p.ProductID).
                Skip((page - 1) * PageSize).
                Take(PageSize)
            };
            return View(listViewModel);
        }
    }
}