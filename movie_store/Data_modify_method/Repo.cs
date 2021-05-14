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

namespace movie_store.Data_modify_method
{
  public class Repo
  {
    private ApplicationDbContext _db = new ApplicationDbContext();
    //Get json object from  api
    public static String ApiGetJson(string url)
    {
      HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url); // Create a request to get server info
      try
      {
        WebResponse response = webRequest.GetResponse();

        using (Stream responseStream = response.GetResponseStream())
        {
          StreamReader reader = new StreamReader(responseStream, System.Text.Encoding.UTF8);
          return reader.ReadToEnd();
        }

      }
      catch (WebException ex)
      {
        WebResponse errorResponse = ex.Response;
        using (Stream responseStream = errorResponse.GetResponseStream())
        {
          StreamReader reader = new StreamReader(responseStream, System.Text.Encoding.GetEncoding("utf-8"));
          string errorText = reader.ReadToEnd();
        }
        throw;
      }
    }
    //Deserialize json and pass into Movie
    public static void GetMovieData(Movie movy)
    {
      ApiData obj = JsonConvert.DeserializeObject<ApiData>(ApiGetJson($"http://www.omdbapi.com/?t={movy.Title}&apikey=171b1b73"));
      obj.ImgUrl = obj.ImgUrl.Replace("_SX300", "_SX600");

      movy.Title = obj.Title;
      movy.Director = obj.Director;
      movy.ReleaseYear = obj.ReleaseYear;
      movy.ImgUrl = obj.ImgUrl;
      movy.ImdbRated = obj.ImdbRated;
      movy.ImdbRating = obj.ImdbRating;
    }

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

    //Get top 5 newest movies
    public static List<Movie> GetFiveNewestMovies()
    {
      using (var _db = new ApplicationDbContext())
      {
        List<Movie> fiveNewest = _db.Movies.OrderByDescending(m => m.ReleaseYear).Take(5).ToList();
        return fiveNewest;
      }
    }

    //Get top 5 oldest movies
    public static List<Movie> GetFiveOldestMovies()
    {
      using (var _db = new ApplicationDbContext())
      {
        List<Movie> fiveNewest = _db.Movies.OrderBy(m => m.ReleaseYear).Take(5).ToList();
        return fiveNewest;
      }
    }

    //Get top 5 cheapest movies
    public static List<Movie> GetFiveCheapestMovies()
    {
      using (var _db = new ApplicationDbContext())
      {
        List<Movie> fiveNewest = _db.Movies.OrderBy(m => m.Price).Take(5).ToList();
        return fiveNewest;
      }
    }

    //Get all customers
    public static List<Customer> GetCustomers()
    {
      using(var _db = new ApplicationDbContext())
      {
        var allDbComputer = _db.Customers.OrderBy(c => c.LastName);
        return allDbComputer.ToList();
      }
    }

    //Unique Email
    public static bool CheckDuplicateEmail(Customer customer)
    {
      using(var _db = new ApplicationDbContext())
      {
        bool emailExists = _db.Customers.Any(c => c.Email == customer.Email);
        return emailExists;
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

    //Click 
    //public static void SaveOrder(OrderRow newOrder)
    //{
    //  using (var _db = new ApplicationDbContext())
    //  {
    //    _db.OrderRows.Add(newOrder.);
    //    _db.SaveChanges();
    //  }
    //}

  }
}