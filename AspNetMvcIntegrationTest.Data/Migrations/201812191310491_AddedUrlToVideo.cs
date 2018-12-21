using System.Data.Entity.Migrations;

namespace AspNetMvcIntegrationTest.Data.Migrations
{
    public partial class AddedUrlToVideo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Videos", "Url", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Videos", "Url");
        }
    }
}
