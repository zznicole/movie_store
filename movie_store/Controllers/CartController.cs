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
        public ActionResult AddToCart(int? movieId)
        {
            if (movieId != null)
            {
                AddToSession((int)movieId);
            }
            return RedirectToAction("Index","Movies");
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