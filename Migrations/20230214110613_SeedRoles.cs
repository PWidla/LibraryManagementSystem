using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryManagementSystem.Migrations
{
    public partial class SeedRoles : Migration
    {
        private string UserRoleId = Guid.NewGuid().ToString("N");
        private string AdminRoleId = Guid.NewGuid().ToString("N");

        private string User1Id = Guid.NewGuid().ToString("N");
        private string User2Id = Guid.NewGuid().ToString("N");

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            SeedRolesSQL(migrationBuilder);

            SeedUser(migrationBuilder);

            SeedUserRoles(migrationBuilder);
        }

        private void SeedRolesSQL(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($@"INSERT INTO AspNetRoles (Id, Name, NormalizedName, ConcurrencyStamp)
            VALUES ('{AdminRoleId}', 'Administrator', 'ADMINISTRATOR', '');");

            migrationBuilder.Sql($@"INSERT INTO AspNetRoles (Id, Name, NormalizedName, ConcurrencyStamp)
            VALUES ('{UserRoleId}', 'User', 'USER', '');");
        }

        private void SeedUser(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                $@"INSERT INTO AspNetUsers (Id, FirstName, LastName, UserName, NormalizedUserName, 
Email, NormalizedEmail, EmailConfirmed, PasswordHash, SecurityStamp, ConcurrencyStamp, 
PhoneNumber, PhoneNumberConfirmed, TwoFactorEnabled, LockoutEnd, LockoutEnabled, AccessFailedCount) 
VALUES 
('{User1Id}', 'Patryk', 'Widła', 'test@test.com', 'TEST@TEST.COM', 
'test@test.com', 'TEST@TEST.COM', 0, 
'AQAAAAEAACcQAAAAEAjUX9i/lAt9Cq89I88rV1Pu11TVTHJvdt6sDajU56e85mElz2WI4BhbDWzbjwk8gA==', 
'YP434DY3ETNYRPI2RSLHMLVATVY5JYHF', 'b7503798-574e-4946-a32d-d203d151face', NULL, 0, 0, NULL, 1, 0);");

            migrationBuilder.Sql(
                $@"INSERT INTO AspNetUsers (Id, FirstName, LastName, UserName, NormalizedUserName, 
Email, NormalizedEmail, EmailConfirmed, PasswordHash, SecurityStamp, ConcurrencyStamp, 
PhoneNumber, PhoneNumberConfirmed, TwoFactorEnabled, LockoutEnd, LockoutEnabled, AccessFailedCount) 
VALUES 
('{User2Id}', 'Eryk', 'Drożdżak', 'user@user.com', 'USER@USER.COM', 
'user@user.com', 'USER@USER.COM', 0, 
'AQAAAAEAACcQAAAAECXxGF9ohaxdbA2XbIdaqHqzB63yzBYrScs9zw/33DLaBEjDG3jv7CIR1KvqlIcC6A==',
'MDWEQE3WP2MDRKHDGESXQOF6A3FGLJXI', '528a40bb-871c-4747-a382-f58173b5e893', NULL, 0, 0, NULL, 1, 0);");
        }

            private void SeedUserRoles(MigrationBuilder migrationBuilder)
            {
                migrationBuilder.Sql(
    $@"INSERT INTO AspNetUserRoles (UserId, RoleId) 
            VALUES 
            ('{User1Id}', '{UserRoleId}');");

                migrationBuilder.Sql(
                    $@"INSERT INTO AspNetUserRoles (UserId, RoleId) 
            VALUES 
            ('{User2Id}', '{AdminRoleId}');");
            }






        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.Sql($@"DELETE FROM AspNetUserRoles WHERE UserId = '{User1Id}'");
            //migrationBuilder.Sql($@"DELETE FROM AspNetUserRoles WHERE UserId = '{User2Id}'");

            //migrationBuilder.Sql($@"DELETE FROM AspNetUsers WHERE Id = '{User1Id}'");
            //migrationBuilder.Sql($@"DELETE FROM AspNetUsers WHERE Id = '{User2Id}'");

            //migrationBuilder.Sql($@"DELETE FROM AspNetRoles WHERE Id = '{UserRoleId}'");
            //migrationBuilder.Sql($@"DELETE FROM AspNetRoles WHERE Id = '{AdminRoleId}'");
        }
    }
}
