using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AntoniosPizza.Models;

namespace AntoniosPizza.Models
{
    public class CartItem
    {
        public product CartProduct { get; set; }
        public int CartQty { get; set; }
    }

    public class Cart
    {
        List<CartItem> items = new List<CartItem>();

        public IEnumerable<CartItem> Items
        {
            get { return items; }
        }

        public void AddToCart(product _product, int _qty = 1)
        {
            var item = items.FirstOrDefault(s => s.CartProduct.ProductId == _product.ProductId);

            if (item == null)
            {
                items.Add(new CartItem
                {
                    CartProduct = _product,
                    CartQty = _qty

                });
            }

            else
            {
                item.CartQty += _qty;
            }
        }

        public void UpdateCartItem(int id, int _quantity)
        {
            var item = items.Find(s => s.CartProduct.ProductId == id);

            if (item != null)
            {
                item.CartQty = _quantity;
            }

        }

        public double CartTotal()
        {
            var total = items.Sum(s => s.CartProduct.ProductPrice * s.CartQty);
            return (double)total;
        }

        public void RemoveCartItem(int id)
        {
            items.RemoveAll(s => s.CartProduct.ProductId == id);
        }

        public int TotalQty()
        {
            return items.Sum(s => s.CartQty);
        }
    }
}