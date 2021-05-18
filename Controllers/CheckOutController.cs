using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AntoniosPizza.Models;

namespace AntoniosPizza.Controllers
{
    public class CheckOutController : Controller
    {
        private AntoniosPizzaEntities db = new AntoniosPizzaEntities();

        // GET: CheckOut
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]

        public ActionResult Index(Order order, OrderDetail orderDetail)
        {

            //initialise the cart 

            Cart cart = Session["Cart"] as Cart;

            //add to Order Table

            if (ModelState.IsValid)
            {
                order.OrderDate = DateTime.Now;
                db.Orders.Add(order);
                db.SaveChanges();

                //add to Order Detail Table
                foreach (CartItem item in cart.Items)
                {
                    {

                        orderDetail.OrderId = order.OrderID;
                        orderDetail.ProductId = item.CartProduct.ProductId;
                        orderDetail.Price = item.CartProduct.ProductPrice;
                        orderDetail.Quantity = item.CartQty;

                        //save DB

                        db.OrderDetails.Add(orderDetail);
                        db.SaveChanges();
                    };
                }

                //remove shopping cart session
                Session.Remove("cart");
                return View("OrderConfirmation");
            }

                return View();
        }
    }
}