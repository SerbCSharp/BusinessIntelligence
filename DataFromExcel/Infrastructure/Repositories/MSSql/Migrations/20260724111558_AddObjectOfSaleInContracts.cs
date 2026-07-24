using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataFromExcel.Infrastructure.Repositories.MSSql.Migrations
{
    /// <inheritdoc />
    public partial class AddObjectOfSaleInContracts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ObjectOfSaleInContracts",
                columns: table => new
                {
                    ContractId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Property = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CostItem = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ObjectOfSaleInContracts", x => x.ContractId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ObjectOfSaleInContracts");
        }
    }
}
