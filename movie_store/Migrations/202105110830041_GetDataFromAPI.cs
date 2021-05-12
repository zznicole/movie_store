namespace movie_store.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GetDataFromAPI : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "ImdbRating", c => c.Double(nullable: false));
            AddColumn("dbo.Movies", "ImdbId", c => c.String());
            AddColumn("dbo.Movies", "ImdbRated", c => c.String());
            AddColumn("dbo.Movies", "Plot", c => c.String());
            AddColumn("dbo.Movies", "ImgUrl", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "ImgUrl");
            DropColumn("dbo.Movies", "Plot");
            DropColumn("dbo.Movies", "ImdbRated");
            DropColumn("dbo.Movies", "ImdbId");
            DropColumn("dbo.Movies", "ImdbRating");
        }
    }
}
