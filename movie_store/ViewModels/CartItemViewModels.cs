using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace movie_store.ViewModels
{
    public class CartItemViewModels
    {
        public int Id { get; set; }
        public string Title { get; set; }
    
        public decimal Price { get; set; }
        public int Qty { get; set; }
        [Display(Name ="Total Price")]
       
        public decimal TotalPrice { get; set; }
    }
}