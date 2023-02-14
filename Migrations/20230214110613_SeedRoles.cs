using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

//namespace LibraryManagementSystem.Migrations
//{
//    public partial class SeedRoles : Migration
//    {
//        protected override void Up(MigrationBuilder migrationBuilder)
//        {

//        }

//        protected override void Down(MigrationBuilder migrationBuilder)
//        {

//        }
//    }
//}


namespace LibraryManagementSystem.Migrations
{
    public partial class SeedRoles : Migration
    {
        private string UserRoleId = Guid.NewGuid().ToString();
        private string AdminRoleId = Guid.NewGuid().ToString();

        private string User1Id = Guid.NewGuid().ToString();
        private string User2Id = Guid.NewGuid().ToString();

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            SeedRolesSQL(migrationBuilder);

            SeedUser(migrationBuilder);

            SeedUserRoles(migrationBuilder);
        }

        private void SeedRolesSQL(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@$"INSERT INTO [dbo].[AspNetRoles] ([Id],[Name],[NormalizedName],[ConcurrencyStamp])
            VALUES ('{AdminRoleId}', 'Administrator', 'ADMINISTRATOR', null);");
            migrationBuilder.Sql(@$"INSERT INTO [dbo].[AspNetRoles] ([Id],[Name],[NormalizedName],[ConcurrencyStamp])
            VALUES ('{UserRoleId}', 'User', 'USER', null);");
        }

        private void SeedUser(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                @$"INSERT [dbo].[AspNetUsers] ([Id], [FirstName], [LastName], [UserName], [NormalizedUserName], 
[Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], 
[PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) 
VALUES 
(N'{User1Id}', N'Patryk', N'Widła', N'test@test.com', N'TEST@TEST.COM', 
N'test@test.com', N'TEST@TEST.COM', 0, 
N'AQAAAAEAACcQAAAAEAjUX9i/lAt9Cq89I88rV1Pu11TVTHJvdt6sDajU56e85mElz2WI4BhbDWzbjwk8gA==', 
N'YP434DY3ETNYRPI2RSLHMLVATVY5JYHF', N'b7503798-574e-4946-a32d-d203d151face', NULL, 0, 0, NULL, 1, 0)");


            migrationBuilder.Sql(
                @$"INSERT [dbo].[AspNetUsers] ([Id], [FirstName], [LastName], [UserName], [NormalizedUserName], 
[Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], 
[PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) 
VALUES 
(N'{User2Id}', N'Eryk 3', N'Drożdżak', N'user@user.com', N'USER@USER.COM', 
N'user@user.com', N'USER@USER.COM', 0, 
N'AQAAAAEAACcQAAAAECXxGF9ohaxdbA2XbIdaqHqzB63yzBYrScs9zw/33DLaBEjDG3jv7CIR1KvqlIcC6A==', 
N'MDWEQE3WP2MDRKHDGESXQOF6A3FGLJXI', N'528a40bb-871c-4747-a382-f58173b5e893', NULL, 0, 0, NULL, 1, 0)");
        }

        private void SeedUserRoles(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@$"
        INSERT INTO [dbo].[AspNetUserRoles]
           ([UserId]
           ,[RoleId])
        VALUES
           ('{User1Id}', '{UserRoleId}');");

            migrationBuilder.Sql(@$"
        INSERT INTO [dbo].[AspNetUserRoles]
           ([UserId]
           ,[RoleId])
        VALUES
           ('{User2Id}', '{AdminRoleId}');");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}

