using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TerraClubHub.Migrations
{
    /// <inheritdoc />
    public partial class AddFilePathToClubActivity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "File",
                table: "ClubActivities");

            migrationBuilder.RenameColumn(
                name: "Image",
                table: "ClubActivities",
                newName: "FilePath");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FilePath",
                table: "ClubActivities",
                newName: "Image");

            migrationBuilder.AddColumn<string>(
                name: "File",
                table: "ClubActivities",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
