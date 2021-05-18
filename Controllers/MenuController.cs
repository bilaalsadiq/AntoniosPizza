using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AntoniosPizza.Models;

namespace AntoniosPizza.Controllers
{
    public class MenuController : Controller
    {
        AntoniosPizzaEntities db = new AntoniosPizzaEntities();


        // GET: Menu
        public ActionResult Index()
        {
            List<product> products = db.products.ToList();
            List<category> categories = db.categories.ToList();


            var menuPageTable = from p in products
                                join c in categories
                                on p.ProductCategoryId equals c.CategoryId 
                                select new Menu { productDetails = p, categoryDetails = c };

            return View(menuPageTable);
        }

        public ActionResult ViewProduct(int? id)
        {
            product item = db.products.Find(id);

            if (id == null)
            {
                return HttpNotFound();
            }

            if (item == null)
            {
                return HttpNotFound();
            }

            return View(item);
        }
    }
}