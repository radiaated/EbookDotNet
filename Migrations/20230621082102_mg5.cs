using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ebook.Migrations
{
    /// <inheritdoc />
    public partial class mg5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Cover",
                table: "Tbl_Book",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tbl_Book_Tbl_Category_categoryId",
                table: "Tbl_Book");

            migrationBuilder.DropIndex(
                name: "IX_Tbl_Book_categoryId",
                table: "Tbl_Book");

            migrationBuilder.DropColumn(
                name: "Cover",
                table: "Tbl_Book");

            migrationBuilder.DropColumn(
                name: "categoryId",
                table: "Tbl_Book");
        }
    }
}
