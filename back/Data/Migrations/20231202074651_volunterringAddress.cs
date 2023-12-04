using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class volunterringAddress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AddressId",
                table: "Volunteerings",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Volunteerings_AddressId",
                table: "Volunteerings",
                column: "AddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Volunteerings_Addresses_AddressId",
                table: "Volunteerings",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Volunteerings_Addresses_AddressId",
                table: "Volunteerings");

            migrationBuilder.DropIndex(
                name: "IX_Volunteerings_AddressId",
                table: "Volunteerings");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "Volunteerings");
        }
    }
}
