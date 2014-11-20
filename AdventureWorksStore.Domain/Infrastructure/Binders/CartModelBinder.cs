using AdventureWorksStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AdventureWorksStore.Domain.Infrastructure.Binders
{
    public class CartModelBinder : IModelBinder
    {
        private const string session_key = "cart";
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            Cart cart = null;
            if (controllerContext.HttpContext.Session[session_key] != null)
            {
                return controllerContext.HttpContext.Session[session_key] as Cart;
            }
            else
            {
                cart = new Cart();
                controllerContext.HttpContext.Session[session_key] = cart;
                return cart;
            }
        }
    }
}
