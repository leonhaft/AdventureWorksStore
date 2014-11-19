using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorksStore.Domain.Entities
{
    public class Cart
    {
        public List<CartItem> CartItems;
        public Cart()
        {
            CartItems = new List<CartItem>();
        }

        public void AddToCart(Product product, Int32 quantity)
        {
            var findedProduct = CartItems.FirstOrDefault(p => p.Product.ProductID == product.ProductID);
            if (findedProduct == null)
            {
                CartItems.Add(new CartItem { Product = product, Quantity = quantity });
            }
            else
            {
                findedProduct.Quantity += quantity;
            }
        }

        public void RemoveFromCart(Product product)
        {
            CartItems.RemoveAll(p => p.Product.ProductID == product.ProductID);
        }
        public decimal ComputeTotalValue()
        {
            return CartItems.Sum(p => p.Product.ListPrice * p.Quantity);
        }

        public void Clear()
        {
            CartItems.Clear();
        }
    }
    public class CartItem
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
