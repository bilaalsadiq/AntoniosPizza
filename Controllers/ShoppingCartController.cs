using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AntoniosPizza.Models;

namespace AntoniosPizza.Controllers
{
    public class ShoppingCartController : Controller
    {
        // GET: ShoppingCart

        private AntoniosPizzaEntities db = new AntoniosPizzaEntities();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult EmptyCart()
        {
            return View();
        }

        public Cart GetCart()
        {
            Cart cart = Session["Cart"] as Cart;
            if (cart == null || Session["Cart"] == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }

            return cart;
        }

        public ActionResult AddToCart (int id)
        {
            var product = db.products.SingleOrDefault(s => s.ProductId == id);
            if (product != null)
            {
                GetCart().AddToCart(product);
            }

            return RedirectToAction("ViewCart", "ShoppingCart");

        }

        public ActionResult ViewCart()
        {
            if (Session["Cart"] == null)
            {
                return RedirectToAction("EmptyCart", "ShoppingCart");
            }

            else
            {
                Cart cart = Session["Cart"] as Cart;
                return View(cart);
            }

        }

        public ActionResult UpdateCartItem(FormCollection form)
        {
            Cart cart = Session["Cart"] as Cart;
            int productID = int.Parse(form["productID"]);
            int quantity = int.Parse(form["qty"]);
            cart.UpdateCartItem(productID, quantity);
            return RedirectToAction("ViewCart", "ShoppingCart");
        }

        public ActionResult RemoveItem(int id)
        {
            Cart cart = Session["Cart"] as Cart;
            cart.RemoveCartItem(id);

            if (cart.TotalQty() == 0)
            {
                ClearCart();
                return View("EmptyCart");
            }

            else
            {
                return RedirectToAction("ViewCart", "ShoppingCart");
            }

        }

        public void ClearCart()
        {
            Session.Clear();
        }

        public PartialViewResult BagCart()
        {
            int cartItem = 0;
            Cart cart = Session["Cart"] as Cart;
            if (cart != null)
            {
                cartItem = cart.TotalQty();
            }

            ViewBag.cartInfo = cartItem;
            return PartialView("BagCart");
        }

    }
}