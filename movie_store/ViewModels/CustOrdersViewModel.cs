using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using movie_store.Models.DB;

namespace movie_store.ViewModels
{
    public class CustOrdersViewModel
    {
        public List<OrderViewModel> Orders { get; set; }
        public Customer Customer { get; set; }

        public CustOrdersViewModel()
        {
            Orders = new List<OrderViewModel>();
        }
    
    }
}