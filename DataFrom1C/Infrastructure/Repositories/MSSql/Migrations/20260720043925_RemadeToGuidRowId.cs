using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataFrom1C.Infrastructure.Repositories.MSSql.Migrations
{
    /// <inheritdoc />
    public partial class RemadeToGuidRowId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MoreInformations",
                table: "MoreInformations");

            migrationBuilder.DropColumn(
                name: "DocumentId",
                table: "MoreInformations");

            migrationBuilder.AddColumn<Guid>(
                name: "RowId",
                table: "MoreInformations",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_MoreInformations",
                table: "MoreInformations",
                column: "RowId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MoreInformations",
                table: "MoreInformations");

            migrationBuilder.DropColumn(
                name: "RowId",
                table: "MoreInformations");

            migrationBuilder.AddColumn<string>(
                name: "DocumentId",
                table: "MoreInformations",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MoreInformations",
                table: "MoreInformations",
                column: "DocumentId");
        }
    }
}
