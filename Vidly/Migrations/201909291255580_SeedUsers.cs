namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'a1954c47-ed80-4a21-85b9-b2d943e39688', N'guest@vidly.com', 0, N'AE/ebhhurBRRfEpZ0hmHGzt1b8G6dxxmmStCIBxiTv6Whc/zmTgqs36QBnP5NBxfgA==', N'f8808b5e-3837-4cbf-8de1-fac1f2ac21d9', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'b0b05562-d0ad-4613-b7c4-6c592e099ae8', N'admin@vidly.com', 0, N'AEPOOUZf4tloq6iBhuA80dSYRWylsocrhNTYvuAw8K8z7bdDDGVUz3+xE4gauucBtw==', N'5f95d3c2-56f8-4ce9-8d5f-252177436293', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'4f3ba3b5-5664-4698-ab5f-f015c6542339', N'CanManageMovies')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'b0b05562-d0ad-4613-b7c4-6c592e099ae8', N'4f3ba3b5-5664-4698-ab5f-f015c6542339')


                 ");
        }
        
        public override void Down()
        {
        }
    }
}
