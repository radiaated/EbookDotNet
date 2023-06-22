using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ebook.Migrations
{
    /// <inheritdoc />
    public partial class mg6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tbl_Book_Tbl_Category_categoryId",
                table: "Tbl_Book");

            migrationBuilder.DropIndex(
                name: "IX_Tbl_Book_categoryId",
                table: "Tbl_Book");

            migrationBuilder.DropColumn(
                name: "categoryId",
                table: "Tbl_Book");

            migrationBuilder.AddColumn<string>(
                name: "category",
                table: "Tbl_Book",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "category",
                table: "Tbl_Book");

            migrationBuilder.AddColumn<int>(
                name: "categoryId",
                table: "Tbl_Book",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Book_categoryId",
                table: "Tbl_Book",
                column: "categoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tbl_Book_Tbl_Category_categoryId",
                table: "Tbl_Book",
                column: "categoryId",
                principalTable: "Tbl_Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
