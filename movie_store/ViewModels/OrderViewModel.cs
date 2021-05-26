using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace movie_store.ViewModels
{
    public class OrderViewModel
    {
        public List<OrderRowViewModel> OrderItems { get; set; }
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }

        public OrderViewModel()
        {
            OrderItems = new List<OrderRowViewModel>();
        }
    }
}