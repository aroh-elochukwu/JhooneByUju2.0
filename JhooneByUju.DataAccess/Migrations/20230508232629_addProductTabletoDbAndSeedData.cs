using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace JhooneByUju.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addProductTabletoDbAndSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Categories",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StoreCode = table.Column<int>(type: "int", nullable: false),
                    Designer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ListPrice = table.Column<double>(type: "float", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Price15 = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "Designer", "ListPrice", "Price", "Price15", "StoreCode", "Title" },
                values: new object[,]
                {
                    { 1, "Second Hand bag created by Igboayaka Uju", "Obianuju Igboayaka", 14.0, 13.199999999999999, 11.0, 102, "Hand Bags 2" },
                    { 2, "First Hand bag created by Igboayaka Uju", "Obianuju Igboayaka", 35.0, 32.0, 27.0, 101, "Hand Bag  1" },
                    { 3, "First around the waist belt created by Igboayaka Uju", "Obianuju Igboayaka", 27.0, 25.0, 22.0, 201, "Belts 1" },
                    { 4, "First Art painting created by Igboayaka Uju", "Obianuju Igboayaka", 200.0, 187.0, 160.0, 301, "Arts 1" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);
        }
    }
}
