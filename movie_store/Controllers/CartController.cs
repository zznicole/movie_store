using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace movie_store.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        public ActionResult AddToCart(int? movieId)
        {
            if (movieId != null)
            {
                AddToSession((int)movieId);
            }
            return RedirectToAction("Index","Movies");
        }

        public ActionResult DisplayCart(int custId)
        {
            return View(DisplayCart())
        }
        private void AddToSession(int movieId)
        {
            List<int> movieIdList = new List<int>();
            if (Session["MovieList"] != null)
            {
                movieIdList = (List<int>)Session["MovieList"];
            }
            movieIdList.Add(movieId);
            Session["MovieList"] = movieIdList;
            Session["CartCount"] = movieIdList.Count;
        }
    }
}