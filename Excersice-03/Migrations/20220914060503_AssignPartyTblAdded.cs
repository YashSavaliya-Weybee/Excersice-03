using Microsoft.EntityFrameworkCore.Migrations;

namespace Excersice_03.Migrations
{
    public partial class AssignPartyTblAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblAssignParty",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PartyId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblAssignParty", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblAssignParty_tblParty_PartyId",
                        column: x => x.PartyId,
                        principalTable: "tblParty",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblAssignParty_tblProduct_ProductId",
                        column: x => x.ProductId,
                        principalTable: "tblProduct",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblAssignParty_PartyId",
                table: "tblAssignParty",
                column: "PartyId");

            migrationBuilder.CreateIndex(
                name: "IX_tblAssignParty_ProductId",
                table: "tblAssignParty",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblAssignParty");
        }
    }
}
