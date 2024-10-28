using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Dogshouseservice.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Dogs",
                columns: new[] { "Name", "Color", "TailLength", "Weight" },
                values: new object[,]
                {
                    { "Ace", "blue", 16, 26 },
                    { "Bailey", "blue & white", 14, 22 },
                    { "Bandit", "tan", 9, 18 },
                    { "Bella", "white", 9, 17 },
                    { "Bentley", "brown", 8, 18 },
                    { "Boomer", "white", 8, 16 },
                    { "Bruce", "chocolate", 22, 33 },
                    { "Bruno", "black", 7, 15 },
                    { "Buddy", "brown", 10, 20 },
                    { "Buster", "white", 9, 16 },
                    { "Charlie", "golden", 15, 25 },
                    { "Chase", "cream", 11, 21 },
                    { "Chloe", "brindle", 19, 31 },
                    { "Cooper", "gray", 15, 28 },
                    { "Daisy", "black & tan", 16, 26 },
                    { "Dexter", "golden", 15, 24 },
                    { "Finn", "gray", 10, 20 },
                    { "Gus", "blue & white", 18, 27 },
                    { "Hank", "chocolate", 11, 21 },
                    { "Harley", "black & tan", 12, 22 },
                    { "Jack", "golden", 13, 23 },
                    { "Jasper", "black & white", 17, 28 },
                    { "Jessy", "black & white", 7, 14 },
                    { "Koda", "golden", 18, 28 },
                    { "Leo", "black", 9, 17 },
                    { "Lola", "golden", 20, 30 },
                    { "Lucy", "cream", 13, 23 },
                    { "Luna", "red & white", 21, 32 },
                    { "Maggie", "brindle", 18, 27 },
                    { "Marley", "white & red", 10, 19 },
                    { "Max", "black", 8, 18 },
                    { "Molly", "chocolate", 11, 19 },
                    { "Neo", "red & amber", 22, 32 },
                    { "Oliver", "black", 20, 30 },
                    { "Oscar", "cream", 14, 24 },
                    { "Riley", "black & red", 14, 22 },
                    { "Rocky", "gray", 12, 24 },
                    { "Roxy", "blue", 11, 21 },
                    { "Rusty", "brindle", 10, 20 },
                    { "Sadie", "black", 7, 15 },
                    { "Sam", "gray", 7, 14 },
                    { "Scout", "tan & white", 12, 19 },
                    { "Simba", "black & tan", 19, 29 },
                    { "Sophie", "red", 10, 20 },
                    { "Tank", "red", 13, 23 },
                    { "Teddy", "black & white", 17, 29 },
                    { "Thor", "gray", 14, 24 },
                    { "Zeus", "white & tan", 16, 25 },
                    { "Zoe", "tan", 12, 22 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "Name",
                keyValue: "Ace");

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "Name",
                keyValue: "Bailey");

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "Name",
                keyValue: "Bandit");

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "Name",
                keyValue: "Bella");

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "Name",
                keyValue: "Bentley");

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "Name",
                keyValue: "Boomer");

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "Name",
                keyValue: "Bruce");

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "Name",
                keyValue: "Bruno");

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "Name",
                keyValue: "Buddy");

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "Name",
                keyValue: "Buster");

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "Name",
                keyValue: "Charlie");

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "Name",
                keyValue: "Chase");

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "Name",
                keyValue: "Chloe");

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "Name",
                keyValue: "Cooper");

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "Name",
                keyValue: "Daisy");

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "Name",
                keyValue: "Dexter");

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "Name",
                keyValue: "Finn");

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "Name",
                keyValue: "Gus");

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "Name",
                keyValue: "Hank");

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "Name",
                keyValue: "Harley");

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "Name",
                keyValue: "Jack");

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "Name",
                keyValue: "Jasper");

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "Name",
                keyValue: "Jessy");

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "Name",
                keyValue: "Koda");

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "Name",
                keyValue: "Leo");

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "Name",
                keyValue: "Lola");

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "Name",
                keyValue: "Lucy");

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "Name",
                keyValue: "Luna");

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "Name",
                keyValue: "Maggie");

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "Name",
                keyValue: "Marley");

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "Name",
                keyValue: "Max");

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "Name",
                keyValue: "Molly");

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "Name",
                keyValue: "Neo");

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "Name",
                keyValue: "Oliver");

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "Name",
                keyValue: "Oscar");

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "Name",
                keyValue: "Riley");

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "Name",
                keyValue: "Rocky");

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "Name",
                keyValue: "Roxy");

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "Name",
                keyValue: "Rusty");

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "Name",
                keyValue: "Sadie");

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "Name",
                keyValue: "Sam");

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "Name",
                keyValue: "Scout");

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "Name",
                keyValue: "Simba");

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "Name",
                keyValue: "Sophie");

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "Name",
                keyValue: "Tank");

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "Name",
                keyValue: "Teddy");

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "Name",
                keyValue: "Thor");

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "Name",
                keyValue: "Zeus");

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "Name",
                keyValue: "Zoe");
        }
    }
}
