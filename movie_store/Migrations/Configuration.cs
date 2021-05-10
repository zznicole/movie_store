namespace movie_store.Migrations
{
    using System;
    using System.Net;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using movie_store.Models;
    using System.Web.Services.Description;

  internal sealed class Configuration : DbMigrationsConfiguration<movie_store.Models.ApplicationDbContext>
  {
    public Configuration()
    {
      AutomaticMigrationsEnabled = false;
    }

    protected override void Seed(movie_store.Models.ApplicationDbContext context)
    {

      /*Context.Movies.AddOrUpdate(GetResponseText("The Social Dilemma", 119));*/


      //  You can use the DbSet<T>.AddOrUpdate() helper extension method
      //  to avoid creating duplicate seed data.
    }
   
  }
}
