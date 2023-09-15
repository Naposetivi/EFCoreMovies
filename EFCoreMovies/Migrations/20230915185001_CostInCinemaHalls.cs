using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCoreMovies.Migrations
{
    /// <inheritdoc />
    public partial class CostInCinemaHalls : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Cost",
                table: "CinemaHalls",
                type: "nvarchar(150)",
                maxLength: 150,
                precision: 9,
                scale: 2,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldPrecision: 9,
                oldScale: 2,
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Cost",
                table: "CinemaHalls",
                type: "nvarchar(max)",
                precision: 9,
                scale: 2,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150,
                oldPrecision: 9,
                oldScale: 2,
                oldNullable: true);
        }
    }
}
