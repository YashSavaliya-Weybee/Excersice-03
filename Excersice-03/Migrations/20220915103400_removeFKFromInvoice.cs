using Microsoft.EntityFrameworkCore.Migrations;

namespace Excersice_03.Migrations
{
    public partial class removeFKFromInvoice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblInvoice_tblParty_PartyId",
                table: "tblInvoice");

            migrationBuilder.DropForeignKey(
                name: "FK_tblInvoice_tblProduct_ProductId",
                table: "tblInvoice");

            migrationBuilder.DropIndex(
                name: "IX_tblInvoice_PartyId",
                table: "tblInvoice");

            migrationBuilder.DropIndex(
                name: "IX_tblInvoice_ProductId",
                table: "tblInvoice");

            migrationBuilder.DropColumn(
                name: "PartyId",
                table: "tblInvoice");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "tblInvoice");

            migrationBuilder.AddColumn<string>(
                name: "PartyName",
                table: "tblInvoice",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProductName",
                table: "tblInvoice",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PartyName",
                table: "tblInvoice");

            migrationBuilder.DropColumn(
                name: "ProductName",
                table: "tblInvoice");

            migrationBuilder.AddColumn<int>(
                name: "PartyId",
                table: "tblInvoice",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "tblInvoice",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_tblInvoice_PartyId",
                table: "tblInvoice",
                column: "PartyId");

            migrationBuilder.CreateIndex(
                name: "IX_tblInvoice_ProductId",
                table: "tblInvoice",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_tblInvoice_tblParty_PartyId",
                table: "tblInvoice",
                column: "PartyId",
                principalTable: "tblParty",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tblInvoice_tblProduct_ProductId",
                table: "tblInvoice",
                column: "ProductId",
                principalTable: "tblProduct",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
