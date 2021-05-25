using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using movie_store.Models;
using movie_store.Models.DB;
using movie_store.ViewModels;
using static movie_store.Data_modify_method.Repo;

namespace movie_store.Controllers
{
  public class HomeController : Controller
  {
    
    public ActionResult Index()
    {
        HomeViewModel homeVW= new HomeViewModel();
            //homeVW.fiveMostPopularMovies = GetFiveMostPopularMovies();
        homeVW.fiveNewestMovies = GetFiveNewestMovies();
        homeVW.fiveOldestMovies = GetFiveOldestMovies();
        homeVW.fiveCheapestMovies = GetFiveCheapestMovies();
            
      return View(homeVW);
    }

    public ActionResult About()
    {
      ViewBag.Message = "Your application description page.";

      return View();
    }

    public ActionResult Contact()
    {
      ViewBag.Message = "Your contact page.";

      return View();
    }
  }
}