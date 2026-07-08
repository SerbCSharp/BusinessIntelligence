using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataFrom1C.Infrastructure.Repositories.MSSql.Migrations
{
    /// <inheritdoc />
    public partial class AddCashFlowItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CashFlowItemId",
                table: "SalesPayments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CashFlowItemId",
                table: "PurchasePayments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CashFlowItems",
                columns: table => new
                {
                    CashFlowItemId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CashFlowItems", x => x.CashFlowItemId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CashFlowItems");

            migrationBuilder.DropColumn(
                name: "CashFlowItemId",
                table: "SalesPayments");

            migrationBuilder.DropColumn(
                name: "CashFlowItemId",
                table: "PurchasePayments");
        }
    }
}
