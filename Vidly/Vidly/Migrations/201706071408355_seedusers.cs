namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seedusers : DbMigration
    {
        public override void Up()
        {
            Sql(    @"INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'5db7159e-b5d4-4c1b-bd91-cf4897ccb9f3', N'guest@vidly.com', 0, N'AMwWgPtsfMbiEb59TuVt0M9USos2hJn6ctIquhwPv1C5z9OVshnq5zQlZ0viIqpLWw==', N'a575f357-6e3a-4567-ac59-9baadd78011d', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')
                    INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'9c44b7d5-718f-4b72-9585-5bbdeaf9864f', N'admin@vidly.com', 0, N'APkMJ5wLXReGY3YA1RJRmORdraR7BqTqXKazIzD1BsSGZzcKRTm9sGtY/d7LTBjJgw==', N'f0ee42a4-8523-40f2-adbf-af7aeef47b87', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
                    INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'5c433f40-086f-4574-a7f2-0b80526b0607', N'CanManageMovies')
                    INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'9c44b7d5-718f-4b72-9585-5bbdeaf9864f', N'5c433f40-086f-4574-a7f2-0b80526b0607')

                ");
        }
        
        public override void Down()
        {
        }
    }
}
