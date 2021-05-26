using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using movie_store.ViewModels;
using movie_store.Models.DB;
using movie_store.Models;
using static movie_store.Data_modify_method.Repo;

namespace movie_store.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        public ActionResult AddToCart(int? movieId, string title = "")
        {
            List<int> movieIdList;
            int addOrSubstract =1;
            if (movieId == null)
            {
                movieId = GetMovieByTitle(title).Id;
                ChangeSession((int)movieId, addOrSubstract);
                return RedirectToAction("DisplayCart");
            }

            ChangeSession((int)movieId, addOrSubstract);
            return RedirectToAction("Index","Movies");
        }

        public ActionResult RemoveFromCart(int? movieId, string title="")
        {
            if(movieId == null)
            {
                movieId = GetMovieByTitle(title).Id;
            }
            int addOrSubstract = -1;
            List<int> movieIdList = ChangeSession((int)movieId, addOrSubstract);
            if(movieIdList.Count == 0)
            {
                return RedirectToAction("Index", "Movies");
            }
            return RedirectToAction("DisplayCart");
        }

        public ActionResult DisplayCart()
        {
            if (Session["MovieList"] != null)
            {
                List<int> movieIdList = (List<int>)Session["MovieList"];
                List<Movie> movieList = GetCartMovies(movieIdList);
                CartListViewModel displayedCart = new CartListViewModel();

                return View(ArrangeCart(movieList, displayedCart));
            }
            return RedirectToAction("Index","Movies");
        }

        public ActionResult Checkout()
        {
            if(Session["MovieList"] != null)
            {
                List<int> movieIdList = (List<int>)Session["MovieList"];
                List<Movie> movieList = GetCartMovies(movieIdList);
                CartListViewModel displayedCart = new CartListViewModel();

                return View(ArrangeCart(movieList, displayedCart));
            }
            return RedirectToAction("Index", "Movies");

        }

        [HttpPost]
        public ActionResult Checkout(CartListViewModel vwCartList)
        {
            int custIdExists = CheckCustExists(vwCartList.Email);
            if(custIdExists == 0)
            {
                ViewBag.Message = "Email is not registered, Please try again.";
                List<int> movieIdList = (List<int>)Session["MovieList"];
                List<Movie> movieList = GetCartMovies(movieIdList);
                CartListViewModel displayedCart = new CartListViewModel();

                return View(ArrangeCart(movieList, displayedCart));
            }
            else
            {
                return RedirectToAction("Create", "Order", new { custId = custIdExists});
            }
            
        }

        private object ArrangeCart(List<Movie> movieList, CartListViewModel displayedCart)
        {
            bool foundMovie = false;
           
                displayedCart.CartMovies.Add(new CartMovieViewModel()
                {
                    Title = movieList[0].Title,
                    Price = movieList[0].Price,
                    CopyAmount = 1,
                    TotalPriceOfMovie = movieList[0].Price,
                });
                displayedCart.TotalPriceInCart = movieList[0].Price;
           
            for (int i = 1; i < movieList.Count; i++ ) {
                foreach (var item in displayedCart.CartMovies)
                {
                    if(item.Title == movieList[i].Title && foundMovie == false)
                    {
                        item.CopyAmount += 1;
                        item.TotalPriceOfMovie += item.Price;
                        displayedCart.TotalPriceInCart += item.Price;
                        foundMovie = true;
                    }
                }
                if (foundMovie == false)
                {
                    displayedCart.CartMovies.Add(new CartMovieViewModel()
                    {
                        Title = movieList[i].Title,
                        Price = movieList[i].Price,
                        CopyAmount = 1,
                        TotalPriceOfMovie =  movieList[i].Price
                    });
                    displayedCart.TotalPriceInCart += movieList[i].Price;
                }
                foundMovie = false;
            }
            return displayedCart;
        }

        //private void AddToSession(int movieId)
        //{
        //    List<int> movieIdList = new List<int>();
        //    if (Session["MovieList"] != null)
        //    {
        //        movieIdList = (List<int>)Session["MovieList"];
        //    }
        //    movieIdList.Add(movieId);
        //    Session["MovieList"] = movieIdList;
        //    Session["CartCount"] = movieIdList.Count;
        //}

        private List<int> ChangeSession(int movieId, int addOrSubstract)
        {
            List<int> movieIdList = new List<int>();
            if (Session["MovieList"] != null)
            {
                movieIdList = (List<int>)Session["MovieList"];
            } if (addOrSubstract == 1)
            {
                movieIdList.Add(movieId);
            } else
                movieIdList.Remove(movieId);
            Session["MovieList"] = movieIdList;
            Session["CartCount"] = movieIdList.Count;
            return movieIdList;
        }
    }
}