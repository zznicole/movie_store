using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using movie_store.Models.DB;

namespace movie_store.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Movie> fiveMostPopularMovies { get; set; }
        public IEnumerable<Movie> fiveNewestMovies { get; set; }
        public IEnumerable<Movie> fiveOldestMovies { get; set; }
        public IEnumerable<Movie> fiveCheapestMovies { get; set; }
        
        public Customer topCustomer { get; set;}

    }
}