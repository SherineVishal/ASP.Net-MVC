namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveAnnotationGenre : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Genres", "Name", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Genres", "Name", c => c.String(nullable: false));
        }
    }
}
