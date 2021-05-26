using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using movie_store.Models;
using movie_store.ViewModels;
using static movie_store.Data_modify_method.Repo;

namespace movie_store.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create(int custId)
        {
            List<int> movieIdList = (List<int>)Session["MovieList"];
            if (movieIdList != null)
            {
                CreateOrder(movieIdList, custId);
                Session.Clear();
            }
            return RedirectToAction("OrderConfirm");
            
        }
        public ActionResult OrderConfirm()
        {
            return View();
        }
    }
}