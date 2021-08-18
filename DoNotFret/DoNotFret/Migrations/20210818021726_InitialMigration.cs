using Microsoft.EntityFrameworkCore.Migrations;

namespace DoNotFret.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Instrument",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Material = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InstrumentType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instrument", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Instrument",
                columns: new[] { "Id", "Brand", "Description", "InstrumentType", "Material", "Name" },
                values: new object[] { 1, "Ibanez", "Natural Wood Finish, 6 string electric guitar", 0, "Basswood", "Guitar" });

            migrationBuilder.InsertData(
                table: "Instrument",
                columns: new[] { "Id", "Brand", "Description", "InstrumentType", "Material", "Name" },
                values: new object[] { 2, "Rickenbacker", "Cherry Red, 4 string electric bass", 0, "Eastern hardrock Maple", "Bass" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Instrument");
        }
    }
}
