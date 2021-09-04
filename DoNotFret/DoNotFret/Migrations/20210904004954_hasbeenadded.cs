using Microsoft.EntityFrameworkCore.Migrations;

namespace DoNotFret.Migrations
{
    public partial class hasbeenadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "HasBeenAdded",
                table: "Instrument",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HasBeenAdded",
                table: "Instrument");
        }
    }
}
