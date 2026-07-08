using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataFrom1C.Infrastructure.Repositories.MSSql.Migrations
{
    /// <inheritdoc />
    public partial class AddGoodAndService : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PurchaseGoodsAndServices",
                columns: table => new
                {
                    RowId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DocumentId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NomenclatureId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnitsOfMeasurementId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseGoodsAndServices", x => x.RowId);
                });

            migrationBuilder.CreateTable(
                name: "SalesGoodsAndServices",
                columns: table => new
                {
                    RowId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DocumentId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NomenclatureId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnitsOfMeasurementId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesGoodsAndServices", x => x.RowId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PurchaseGoodsAndServices");

            migrationBuilder.DropTable(
                name: "SalesGoodsAndServices");
        }
    }
}
