using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using movie_store.Models.DB;
using movie_store.Models;
using movie_store.ViewModels;


namespace movie_store.Controllers
{
    
    public class OrdersController : Controller
    {
        public List<Movie> cartItems = new List<Movie>();
        // GET: Orders
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DisplayCart()
        {
            ViewBag.Message = "Shopping Cart";
            
            if (Session["cart"] != null)
            {
                cartItems = (List<Movie>)Session["cart"];
            }
            //decimal total = 0;
            //foreach (var item in cartItems)
            //{
            //    total += item.Price;
            //}
            decimal total = cartItems.Sum(c => c.Price);

            var orderQueryResult = from c in cartItems
                                   group c by c.Id into g
                                   select new CartItemViewModels
                                   {
                                       Id = g.Key,
                                       Title = g.FirstOrDefault().Title,
                                       Qty = g.Count(),
                                       Price = g.FirstOrDefault().Price,
                                       TotalPrice = total
                                   };


            return View(orderQueryResult);
        }
    }
}