namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatingSophiasBirthDateValue : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Customers SET BirthDate='07/24/2015' WHERE Name='Sophia Mannanal'");
        }
        
        public override void Down()
        {
        }
    }
}
