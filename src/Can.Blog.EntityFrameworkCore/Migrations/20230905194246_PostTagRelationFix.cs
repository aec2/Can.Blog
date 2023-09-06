using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Can.Blog.Migrations
{
    /// <inheritdoc />
    public partial class PostTagRelationFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostTag_Posts_PostGuid",
                table: "PostTag");

            migrationBuilder.DropForeignKey(
                name: "FK_PostTag_Tags_TagGuid",
                table: "PostTag");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PostTag",
                table: "PostTag");

            migrationBuilder.RenameTable(
                name: "PostTag",
                newName: "PostTags");

            migrationBuilder.RenameIndex(
                name: "IX_PostTag_TagGuid",
                table: "PostTags",
                newName: "IX_PostTags_TagGuid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PostTags",
                table: "PostTags",
                columns: new[] { "PostGuid", "TagGuid" });

            migrationBuilder.AddForeignKey(
                name: "FK_PostTags_Posts_PostGuid",
                table: "PostTags",
                column: "PostGuid",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PostTags_Tags_TagGuid",
                table: "PostTags",
                column: "TagGuid",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostTags_Posts_PostGuid",
                table: "PostTags");

            migrationBuilder.DropForeignKey(
                name: "FK_PostTags_Tags_TagGuid",
                table: "PostTags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PostTags",
                table: "PostTags");

            migrationBuilder.RenameTable(
                name: "PostTags",
                newName: "PostTag");

            migrationBuilder.RenameIndex(
                name: "IX_PostTags_TagGuid",
                table: "PostTag",
                newName: "IX_PostTag_TagGuid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PostTag",
                table: "PostTag",
                columns: new[] { "PostGuid", "TagGuid" });

            migrationBuilder.AddForeignKey(
                name: "FK_PostTag_Posts_PostGuid",
                table: "PostTag",
                column: "PostGuid",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PostTag_Tags_TagGuid",
                table: "PostTag",
                column: "TagGuid",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
