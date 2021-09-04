using Microsoft.EntityFrameworkCore.Migrations;

namespace DoNotFret.Migrations
{
    public partial class Categories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Instrument",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Pianos" });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Basses" });

            migrationBuilder.CreateIndex(
                name: "IX_Instrument_CategoryId",
                table: "Instrument",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Instrument_Category_CategoryId",
                table: "Instrument",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Instrument_Category_CategoryId",
                table: "Instrument");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropIndex(
                name: "IX_Instrument_CategoryId",
                table: "Instrument");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Instrument");
        }
    }
}
