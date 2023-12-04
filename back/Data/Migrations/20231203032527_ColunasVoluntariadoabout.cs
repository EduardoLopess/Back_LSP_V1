using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class ColunasVoluntariadoabout : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "About",
                table: "Volunteerings",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "About",
                table: "CampaingnDonations",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "About",
                table: "Volunteerings");

            migrationBuilder.DropColumn(
                name: "About",
                table: "CampaingnDonations");
        }
    }
}
