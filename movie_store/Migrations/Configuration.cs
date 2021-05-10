namespace movie_store.Migrations
{
    using System;
    using System.Net;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using movie_store.Models;
    using System.Web.Services.Description;
    using movie_store.Data_modify_method;
    using movie_store.Models.DB;

  internal sealed class Configuration : DbMigrationsConfiguration<movie_store.Models.ApplicationDbContext>
  {
    public Configuration()
    {
      AutomaticMigrationsEnabled = false;
    }

    protected override void Seed(movie_store.Models.ApplicationDbContext context)
    {

      

    }

    
  }
}
