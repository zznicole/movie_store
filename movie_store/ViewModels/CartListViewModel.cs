using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace movie_store.ViewModels
{
    public class CartListViewModel
    {
        public List<CartMovieViewModel> CartMovies { get; set; }
        public decimal TotalPriceInCart { get; set; }

        public CartListViewModel()
        {
            CartMovies = new List<CartMovieViewModel>();
        }
    }
}