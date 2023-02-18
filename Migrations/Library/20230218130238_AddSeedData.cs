using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryManagementSystem.Migrations.Library
{
    public partial class AddSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Add announcements
            migrationBuilder.InsertData(
            table: "Announcement",
            columns: new[] { "ID", "Title", "Content", "CreationDate" },
            values: new object[,]
            {
{ 1, "Library Hours Change", "Starting next week, the library will be open from 10am-8pm on weekdays and 10am-6pm on weekends.", new DateTime(2022, 2, 1) },
{ 2, "Library Closure", "The library will be closed on February 17th for maintenance. We apologize for any inconvenience.", new DateTime(2022, 2, 14) },
{ 3, "New Book Arrival", "Check out our new book, 'The Silent Patient' by Alex Michaelides, available now in the fiction section.", new DateTime(2022, 2, 28) }
            });

            // Add genres
            migrationBuilder.InsertData(
                table: "Genre",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                { 1, "Fiction" },
                { 2, "Non-fiction" },
                { 3, "Mystery" },
                { 4, "Science Fiction" }
                });

            // Add authors
            migrationBuilder.InsertData(
                table: "Author",
                columns: new[] { "ID", "FirstName", "LastName" },
                values: new object[,]
                {
                { 1, "Margaret", "Atwood" },
                { 2, "Stephen", "King" },
                { 3, "Agatha", "Christie" },
                { 4, "Neil", "Gaiman" },
                { 5, "J.K.", "Rowling" },
                { 6, "Michael", "Crichton" }
                });

            // Add books
            migrationBuilder.InsertData(
                table: "Book",
                columns: new[] { "ID", "Title", "ReleaseYear", "IsAvailable", "GenreID", "AuthorID" },
                values: new object[,]
                {
                { 1, "The Handmaid's Tale", 1985, true, 1, 1 },
                { 2, "The Stand", 1978, true, 1, 2 },
                { 3, "Murder on the Orient Express", 1934, true, 3, 3 },
                { 4, "American Gods", 2001, true, 1, 4 },
                { 5, "Harry Potter and the Sorcerer's Stone", 1997, true, 1, 5 },
                { 6, "Jurassic Park", 1990, true, 4, 6 },
                { 7, "The Testaments", 2019, true, 1, 1 },
                { 8, "The Shining", 1977, true, 1, 2 },
                { 9, "Death on the Nile", 1937, true, 3, 3 },
                { 10, "Good Omens", 1990, true, 1, 4 },
                { 11, "Harry Potter and the Chamber of Secrets", 1998, true, 1, 5 },
                { 12, "Prey", 2002, true, 4, 6 }
                });

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Announcement");

            migrationBuilder.DropTable(
                name: "Book");

            migrationBuilder.DropTable(
                name: "Author");

            migrationBuilder.DropTable(
                name: "Genre");
        }
    }
}
