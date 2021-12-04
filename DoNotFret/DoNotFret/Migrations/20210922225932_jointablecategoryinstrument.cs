using Microsoft.EntityFrameworkCore.Migrations;

namespace DoNotFret.Migrations
{
    public partial class jointablecategoryinstrument : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Instrument");

            migrationBuilder.CreateTable(
                name: "InstrumentCategory",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    InstrumentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstrumentCategory", x => new { x.InstrumentId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_InstrumentCategory_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InstrumentCategory_Instrument_InstrumentId",
                        column: x => x.InstrumentId,
                        principalTable: "Instrument",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InstrumentCategory_CategoryId",
                table: "InstrumentCategory",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InstrumentCategory");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Instrument",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Instrument",
                keyColumn: "Id",
                keyValue: 1,
                column: "CategoryId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Instrument",
                keyColumn: "Id",
                keyValue: 2,
                column: "CategoryId",
                value: 2);
        }
    }
}
