using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataFrom1C.Infrastructure.Repositories.MSSql.Migrations
{
    /// <inheritdoc />
    public partial class ReplacedFieldNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UnitsOfMeasurementId",
                table: "SalesGoodsAndServices",
                newName: "UnitId");

            migrationBuilder.RenameColumn(
                name: "NomenclatureId",
                table: "SalesGoodsAndServices",
                newName: "ProductAndServiceId");

            migrationBuilder.RenameColumn(
                name: "UnitsOfMeasurementId",
                table: "PurchaseGoodsAndServices",
                newName: "UnitId");

            migrationBuilder.RenameColumn(
                name: "NomenclatureId",
                table: "PurchaseGoodsAndServices",
                newName: "ProductAndServiceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UnitId",
                table: "SalesGoodsAndServices",
                newName: "UnitsOfMeasurementId");

            migrationBuilder.RenameColumn(
                name: "ProductAndServiceId",
                table: "SalesGoodsAndServices",
                newName: "NomenclatureId");

            migrationBuilder.RenameColumn(
                name: "UnitId",
                table: "PurchaseGoodsAndServices",
                newName: "UnitsOfMeasurementId");

            migrationBuilder.RenameColumn(
                name: "ProductAndServiceId",
                table: "PurchaseGoodsAndServices",
                newName: "NomenclatureId");
        }
    }
}
