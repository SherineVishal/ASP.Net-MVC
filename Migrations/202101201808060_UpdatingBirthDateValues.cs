namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatingBirthDateValues : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Customers SET BirthDate='11/30/2007' WHERE Name='Johaan Mannanal'");
            Sql("UPDATE Customers SET BirthDate='08/06/2009' WHERE Name='Ishaan Mannanal'");
            Sql("UPDATE Customers SET BirthDate='07/24/2015' WHERE Name='Ishaan Mannanal'");
        }
        
        public override void Down()
        {
        }
    }
}
