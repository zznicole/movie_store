using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace movie_store.ViewModels
{
    public class OrderRowViewModel
    {

        public string Title { get; set; }
    
        public decimal Price { get; set; }

        public int Copies { get; set; }

        public decimal SubTotal { get; set; }
    }
}