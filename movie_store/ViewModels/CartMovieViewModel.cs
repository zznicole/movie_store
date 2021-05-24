using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace movie_store.ViewModels
{
    public class CartMovieViewModel
    {
        public string Title { get; set; }
        public decimal Price { get; set; }
        public int CopyAmount { get; set; }
        [Display(Name ="Total Price :")]
        public decimal TotalPriceOfMovie { get; set; }
    }
}