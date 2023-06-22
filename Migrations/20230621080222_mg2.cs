using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ebook.Migrations
{
    /// <inheritdoc />
    public partial class mg2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AvailableStatus",
                table: "Tbl_Book");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Tbl_Book",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Tbl_Book",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Isbn",
                table: "Tbl_Book",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Language",
                table: "Tbl_Book",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "Published",
                table: "Tbl_Book",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

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
                name: "Isbn",
                table: "Tbl_Book");

            migrationBuilder.DropColumn(
                name: "Language",
                table: "Tbl_Book");

            migrationBuilder.DropColumn(
                name: "Published",
                table: "Tbl_Book");

            migrationBuilder.DropColumn(
                name: "categoryId",
                table: "Tbl_Book");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Tbl_Book",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Tbl_Book",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<bool>(
                name: "AvailableStatus",
                table: "Tbl_Book",
                type: "bit",
                nullable: true);
        }
    }
}
