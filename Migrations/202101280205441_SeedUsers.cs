namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
            INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'25f1295f-fceb-4e20-a336-fcea46c07a3b', N'guest@Vidly.com', 0, N'AFPT3FeC/J2oECjRcaNy+bU1uHWdTTQXA17jFj3bd7NWYdsBiIBUmrIxon3IH/Kttg==', N'609eddde-c668-4782-8b79-18fe4bcf20aa', NULL, 0, 0, NULL, 1, 0, N'guest@Vidly.com')
            INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'648151ea-af3a-4d8c-a235-37ca056e416f', N'admin@Vidly.com', 0, N'AF7+8DuMyLqYGcebTISTmq+hHO/Mjj1VObuw9Qa3fQaXL6acnsyWGruxYLJqypQ9mw==', N'5c87a522-2386-4899-af88-28bfa4842530', NULL, 0, 0, NULL, 1, 0, N'admin@Vidly.com')
            INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'a845d95d-0f82-489d-a67e-50e52261a7c2', N'sherinethachil@gmail.com', 0, N'APu+Zf5bovVEEfmUxkS07Hgdi9z+2/fPuzDjLkaDHx9vQ8yc7uUp7jr+UgAdmXPpaQ==', N'03d77cfe-5873-4884-9dc5-6c4b09111f6f', NULL, 0, 0, NULL, 1, 0, N'sherinethachil@gmail.com')
            INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'08a28332-a724-40e8-ac17-75a1826a7874', N'CanManageMovies')
            INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'648151ea-af3a-4d8c-a235-37ca056e416f', N'08a28332-a724-40e8-ac17-75a1826a7874')

            ");
        }
        
        public override void Down()
        {
        }
    }
}
