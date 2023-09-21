using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCoreMovies.Migrations
{
    /// <inheritdoc />
    public partial class ComputedColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "invoice");

            migrationBuilder.CreateSequence<int>(
                name: "InvoiceNumber",
                schema: "invoice");

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "InvoiceDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "Total",
                table: "InvoiceDetails",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                computedColumnSql: "Quantity * Price");

            migrationBuilder.UpdateData(
                table: "InvoiceDetails",
                keyColumn: "Id",
                keyValue: 3,
                column: "Quantity",
                value: 0);

            migrationBuilder.UpdateData(
                table: "InvoiceDetails",
                keyColumn: "Id",
                keyValue: 4,
                column: "Quantity",
                value: 0);

            migrationBuilder.UpdateData(
                table: "InvoiceDetails",
                keyColumn: "Id",
                keyValue: 5,
                column: "Quantity",
                value: 0);

            migrationBuilder.UpdateData(
                table: "InvoiceDetails",
                keyColumn: "Id",
                keyValue: 6,
                column: "Quantity",
                value: 0);

            migrationBuilder.UpdateData(
                table: "InvoiceDetails",
                keyColumn: "Id",
                keyValue: 7,
                column: "Quantity",
                value: 0);

            migrationBuilder.UpdateData(
                table: "InvoiceDetails",
                keyColumn: "Id",
                keyValue: 8,
                column: "Quantity",
                value: 0);

            migrationBuilder.UpdateData(
                table: "InvoiceDetails",
                keyColumn: "Id",
                keyValue: 9,
                column: "Quantity",
                value: 0);

            migrationBuilder.UpdateData(
                table: "InvoiceDetails",
                keyColumn: "Id",
                keyValue: 10,
                column: "Quantity",
                value: 0);

            migrationBuilder.UpdateData(
                table: "InvoiceDetails",
                keyColumn: "Id",
                keyValue: 11,
                column: "Quantity",
                value: 0);

            migrationBuilder.UpdateData(
                table: "InvoiceDetails",
                keyColumn: "Id",
                keyValue: 12,
                column: "Quantity",
                value: 0);

            migrationBuilder.UpdateData(
                table: "InvoiceDetails",
                keyColumn: "Id",
                keyValue: 13,
                column: "Quantity",
                value: 0);

            migrationBuilder.UpdateData(
                table: "InvoiceDetails",
                keyColumn: "Id",
                keyValue: 14,
                column: "Quantity",
                value: 0);

            migrationBuilder.UpdateData(
                table: "InvoiceDetails",
                keyColumn: "Id",
                keyValue: 15,
                column: "Quantity",
                value: 0);

            migrationBuilder.UpdateData(
                table: "InvoiceDetails",
                keyColumn: "Id",
                keyValue: 16,
                column: "Quantity",
                value: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Total",
                table: "InvoiceDetails");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "InvoiceDetails");

            migrationBuilder.DropSequence(
                name: "InvoiceNumber",
                schema: "invoice");
        }
    }
}
