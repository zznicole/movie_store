using System;
using System.Net;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using movie_store.Models;
using movie_store.Models.DB;
using movie_store.Migrations;
using Newtonsoft.Json;
using System.Web.Providers.Entities;
using System.Data.Entity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace movie_store.Data_modify_method
{
  public class Repo
  {
    private ApplicationDbContext _db = new ApplicationDbContext();
    //Get json object from  api
    //public static String ApiGetJson(string url)
    //{
    //  HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url); // Create a request to get server info
    //  try
    //  {
    //    WebResponse response = webRequest.GetResponse();

    //    using (Stream responseStream = response.GetResponseStream())
    //    {
    //      StreamReader reader = new StreamReader(responseStream, System.Text.Encoding.UTF8);
    //      return reader.ReadToEnd();
    //    }

    //  }
    //  catch (WebException ex)
    //  {
    //    WebResponse errorResponse = ex.Response;
    //    using (Stream responseStream = errorResponse.GetResponseStream())
    //    {
    //      StreamReader reader = new StreamReader(responseStream, System.Text.Encoding.GetEncoding("utf-8"));
    //      string errorText = reader.ReadToEnd();
    //    }
    //    throw;
    //  }
    //}
    ////Deserialize json and pass into Movie
    //public static void GetMovieData(Movie movy)
    //{
    //  ApiData obj = JsonConvert.DeserializeObject<ApiData>(ApiGetJson($"http://www.omdbapi.com/?t={movy.Title}&apikey=171b1b73"));
    //  obj.ImgUrl = obj.ImgUrl.Replace("_SX300", "_SX600");

    //  movy.Title = obj.Title;
    //  movy.Director = obj.Director;
    //  movy.ReleaseYear = obj.ReleaseYear;
    //  movy.ImgUrl = obj.ImgUrl;
    //  movy.ImdbRated = obj.ImdbRated;
    //  movy.ImdbRating = obj.ImdbRating;
    //}

    //METHODS FOR MoviesController-------------------------------------------------------------------------
    //Get all movies
    public static List<Movie> GetMovies()
    {
      using(var _db = new ApplicationDbContext())
      {
        var allDbMovies = _db.Movies.OrderByDescending(m => m.ReleaseYear);
        return allDbMovies.ToList();
      }
    }
    
    //Save the new movie to db
    public static void SaveMovie(Movie movie)
    {
      using(var _db = new ApplicationDbContext())
      {
        _db.Movies.Add(movie);
        _db.SaveChanges();
      }
    }
    
    //Get movie by title
    public static Movie GetMovieByTitle(string title)
        {
            using(var _db= new ApplicationDbContext())
            {
                Movie foundMovie = _db.Movies.Where(m => m.Title == title).FirstOrDefault();
                return foundMovie;
            }
        }

    //Get five most popular movies 
    public static List<Movie> GetFiveMostPopularMovies()
    {
        using (var _db = new ApplicationDbContext())
        {
                
            List<Movie> fiveMostPopular = _db.OrderRows.GroupBy(m => m.MovieId)
                                                       .OrderByDescending(g => g.Count())
                                                       .Take(5)
                                                       .Select(g=>g.FirstOrDefault().Movie)
                                                       .ToList();
                
                return fiveMostPopular;
        }
    }

    //Get top five newest movies
    public static List<Movie> GetFiveNewestMovies()
    {
      using (var _db = new ApplicationDbContext())
      {
        List<Movie> fiveNewest = _db.Movies.OrderByDescending(m => m.ReleaseYear).Take(5).ToList();
        return fiveNewest;
      }
    }

    //Get top five oldest movies
    public static List<Movie> GetFiveOldestMovies()
    {
      using (var _db = new ApplicationDbContext())
      {
        List<Movie> fiveNewest = _db.Movies.OrderBy(m => m.ReleaseYear).Take(5).ToList();
        return fiveNewest;
      }
    }

    //Get top five cheapest movies
    public static List<Movie> GetFiveCheapestMovies()
    {
      using (var _db = new ApplicationDbContext())
      {
        List<Movie> fiveCheapest = _db.Movies.OrderBy(m => m.Price).Take(5).ToList();
        return fiveCheapest;
      }
    }

    //Add moive to the cart
    public static void AddToCart(int id)
    {
        using (var _db = new ApplicationDbContext())
        {

            List<Movie> cartItems = new List<Movie>();
            var cartItem = _db.Movies.FirstOrDefault(m => m.Id == id);
            cartItems.Add(cartItem);
          

            //var cartItem = db.Movies.FirstOrDefault(m => m.Id == id);
            //if (Session.IsNewSession && cartItems != null || Session["cart"] == null && cartItems != null)
            //{
            //    cartItems.Add(cartItem);
            //    Session["cart"] = cartItems;
            //}
            //else
            //{
            //    cartItems = (List<Movie>)Session["cart"];
            //    cartItems.Add(cartItem);
            //    Session["cart"] = cartItems;
            //}
        }
    }

    //METHODS FOR CustomersController-------------------------------------------------------------------------
    //Get all customers
    public static List<Customer> GetCustomers()
        {
      using(var _db = new ApplicationDbContext())
      {
        var allDbComputer = _db.Customers.OrderBy(c => c.LastName);
        return allDbComputer.ToList();
      }
    }

    //Save the new customers
    public static void SaveCustomers(Customer customer)
    {
        using (var _db = new ApplicationDbContext())
        {
            _db.Customers.Add(customer);
            _db.SaveChanges();
        }
    }

    //Check for if there is duplicate Email
    public static bool CheckDuplicateEmail(Customer customer)
    {
      using(var _db = new ApplicationDbContext())
      {
        bool emailExists = _db.Customers.Any(c => c.Email == customer.Email);
        //var cust = _db.Customers.Where(c => c.Email == customer.Email).FirstOrDefault();
        //if(emailExists && _db.Customers.Find(customer.Id) == cust)
        //{
        //            emailExists = false;     
        //}
        return emailExists;
      }
    }

    //Check if a customer exists
    public static int CheckCustExists(string email)
    {
      using(var _db = new ApplicationDbContext())
      {
         bool custExists = _db.Customers.Any(c => c.Email == email);
                if (custExists)
                {
                    return _db.Customers.Where(c => c.Email == email).FirstOrDefault().Id;
                }
                else
                    return 0;
        
      }
    }

    //Find a customer
    public static Customer FindCustomer(int custId)
    {
      using(var _db = new ApplicationDbContext())
      {
        return _db.Customers.Find(custId);
      }
    }

    //Get a customer's orders
    public static List<Order> GetOrders(int custId)
    {
            var _db2 = new ApplicationDbContext();
        {
          List<Order> orderList = _db2.Orders.Include(o => o.OrderRows).Where(c => c.CustomerId == custId).ToList();
          return orderList;
        }

    }

    //Click 
    //public static void SaveOrder(OrderRow newOrder)
    //{
    //  using (var _db = new ApplicationDbContext())
    //  {
    //    _db.OrderRows.Add(newOrder.);
    //    _db.SaveChanges();
    //  }
    //}

    //METHODS FOR Admin-------------------------------------------------------------------------
    //Add role
    public static void AddRole()
    {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));
            roleManager.Create(new IdentityRole("Admin"));
    }

    //METHODS FOR CartController-------------------------------------------------------------------------
    //Display orders
    public static List<Movie> GetCartMovies(List<int> movieIdList)
    {
        using(var _db =new ApplicationDbContext())
        {
            List<Movie> cartMovies = new List<Movie>();
            foreach(var item in movieIdList)
            {
                cartMovies.Add(_db.Movies.Find(item));
            }
            return cartMovies;
        }

    }
    //METHODS FOR OrderController-------------------------------------------------------------------------
     public static void CreateOrder(List<int> movieIdList, int custId)
    {
        using (var _db = new ApplicationDbContext())
        {
            Order newOrder = new Order();
            newOrder.OrderDate = DateTime.Now;
            newOrder.Customer = _db.Customers.Find(custId);
            foreach(var item in movieIdList)
            {
                Movie orderRowMovie = _db.Movies.Find(item);
                newOrder.OrderRows.Add(new OrderRow()
                {
                    Movie = orderRowMovie,
                    Price = orderRowMovie.Price,
                    MovieId = orderRowMovie.Id,
                });
            }
                _db.Orders.Add(newOrder);
                _db.SaveChanges();
            
        }
     }
  }
}