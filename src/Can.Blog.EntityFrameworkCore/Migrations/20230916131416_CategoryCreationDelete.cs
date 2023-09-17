using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Can.Blog.Migrations
{
    /// <inheritdoc />
    public partial class CategoryCreationDelete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreationTime",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "LastModificationTime",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "LastModifierId",
                table: "Categories");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatorId",
                table: "Categories",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModificationTime",
                table: "Categories",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "LastModifierId",
                table: "Categories",
                type: "uniqueidentifier",
                nullable: true);
        }
    }
}
