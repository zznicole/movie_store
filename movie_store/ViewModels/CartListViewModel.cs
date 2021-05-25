using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace movie_store.ViewModels
{
    public class CartListViewModel
    {
        public List<CartMovieViewModel> CartMovies { get; set; }
        public decimal TotalPriceInCart { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public CartListViewModel()
        {
            CartMovies = new List<CartMovieViewModel>();
        }
    }
}