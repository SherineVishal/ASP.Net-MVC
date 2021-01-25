namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModificationNameMembershipType : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE MembershipTypes SET Name='Quarterly' WHERE DurationInMonths=3");
        }
        
        public override void Down()
        {
        }
    }
}
