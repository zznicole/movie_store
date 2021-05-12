namespace movie_store.Migrations
{
    using System;
    using System.Net;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using movie_store.Models;
    using System.Web.Services.Description;
    using movie_store.Models.DB;
    using movie_store.Migrations;

  internal sealed class Configuration : DbMigrationsConfiguration<movie_store.Models.ApplicationDbContext>
  {
    public Configuration()
    {
      AutomaticMigrationsEnabled = false;
    }

    protected override void Seed(movie_store.Models.ApplicationDbContext context)
    {

      context.Movies.AddOrUpdate(
        m => m.Title,
        new Movie() { Title = "Life of Pi", Director = "Ang Lee", ReleaseYear = 2012, ImgUrl = "https://upload.wikimedia.org/wikipedia/en/5/57/Life_of_Pi_2012_Poster.jpg", Price = 169 },
        new Movie() { Title = "12 Years a Slave", Director = "Steve McQueen", ReleaseYear = 2013, ImgUrl = "https://upload.wikimedia.org/wikipedia/en/5/5c/12_Years_a_Slave_film_poster.jpg", Price = 119 },
        new Movie() { Title = "My Octopus Teacher", Director = "Pippa Ehrlich, James Reed", ReleaseYear = 2020, ImgUrl = "https://upload.wikimedia.org/wikipedia/commons/c/ce/My_Octopus_Teacher.jpg", Price = 199 },
        new Movie() { Title = "Forrest Gump", Director = "Robert Zemeckis", ReleaseYear = 1994, ImgUrl = "https://upload.wikimedia.org/wikipedia/en/6/67/Forrest_Gump_poster.jpg", Price = 49 },
        new Movie() { Title = "The Sound of Music", Director = "Robert Wise", ReleaseYear = 1965, ImgUrl = "https://upload.wikimedia.org/wikipedia/en/c/c6/Sound_of_music.jpg", Price = 99 },
        new Movie() { Title = "Frida", Director = "Julie Taymor", ReleaseYear = 2002, ImgUrl = "https://upload.wikimedia.org/wikipedia/en/2/26/Fridaposter.jpg", Price = 119 }
      );

      context.Customers.AddOrUpdate(
        c => c.Email,
        new Customer()
        { FirstName = "Pia", LastName= "Singer",Email="pia.singer@gmail.com", PhoneNo="+61423809889", 
          BillingAddress="24 Sandridge st.",BillingZipCode="28465",BillingCity="Sydney",BillingCountry="Australia",
          DeliveryAddress= "24 Sandridge st.", DeliveryZipCode= "28465",DeliveryCity="Sydney",DeliverCountry ="Australia"
        },
       
        new Customer()
        { FirstName = "Martin", LastName = "Larsson", Email = "Martin@gmail.com", PhoneNo = "+46756489123", 
          BillingAddress = "1 Kungatan", BillingZipCode = "789456", BillingCity = "Stockholm", BillingCountry = "Sweden", 
          DeliveryAddress = "1 Kungatan", DeliveryZipCode = "789456", DeliveryCity = "Stockholm", DeliverCountry = "Sweden"
        });
    }

  }

}
