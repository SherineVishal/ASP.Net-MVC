namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateMembershipTypeName : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE MembershipTypes SET Name='quarterly' WHERE DurationInMonths=3");
        }
        
        public override void Down()
        {
        }
    }
}
