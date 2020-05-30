namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO[dbo].[AspNetUsers]([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES(N'b077e3ce-abf7-45ad-b3ba-9e09a41514b7', N'be37be@gmail.com', 0, N'ADtqgZLygPL6BYd6v1N7ftp5I5Gla8EAgObhxhOJNso+A5d0mIMs3BPK3N99cR1gFQ==', N'1c64b01e-5c2c-4e24-b7d7-7fe85e0661e1', NULL, 0, 0, NULL, 1, 0, N'be37be@gmail.com')
                INSERT INTO[dbo].[AspNetUsers]([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES(N'ee02e841-f581-40ec-9d77-8e9f0210babb', N'admin@vidly.com', 0, N'AOsg99RWaGLTv9WyLO0FQF3m3ZgfWIfbgioomyIumt7/IDKtHPuiKSfepRKQMp7/9A==', N'c5d6ac7b-4bb5-46fc-9601-a2ac0e1a07b3', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
                
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'9589bd61-72eb-40fb-8fca-bd28c6095109', N'CanManageMovies')
                
                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'ee02e841-f581-40ec-9d77-8e9f0210babb', N'9589bd61-72eb-40fb-8fca-bd28c6095109')

                ");
        }

        public override void Down()
        {
        }
    }
}
