using Microsoft.EntityFrameworkCore.Migrations;

namespace DoNotFret.Migrations
{
    public partial class JoinTablesNew3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Instrument_Cart_CartId",
                table: "Instrument");

            migrationBuilder.DropTable(
                name: "UserCart");

            migrationBuilder.DropIndex(
                name: "IX_Instrument_CartId",
                table: "Instrument");

            migrationBuilder.DropColumn(
                name: "CartId",
                table: "Instrument");

            migrationBuilder.RenameColumn(
                name: "Username",
                table: "Cart",
                newName: "UserId");

            migrationBuilder.UpdateData(
                table: "Cart",
                keyColumn: "Id",
                keyValue: 1,
                column: "UserId",
                value: "1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Cart",
                newName: "Username");

            migrationBuilder.AddColumn<int>(
                name: "CartId",
                table: "Instrument",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "UserCart",
                columns: table => new
                {
                    CartId = table.Column<int>(type: "int", nullable: false),
                    AuthUserId = table.Column<int>(type: "int", nullable: false),
                    AuthUserId1 = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCart", x => new { x.CartId, x.AuthUserId });
                    table.ForeignKey(
                        name: "FK_UserCart_AspNetUsers_AuthUserId1",
                        column: x => x.AuthUserId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserCart_Cart_CartId",
                        column: x => x.CartId,
                        principalTable: "Cart",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Cart",
                keyColumn: "Id",
                keyValue: 1,
                column: "Username",
                value: "SorviusN");

            migrationBuilder.CreateIndex(
                name: "IX_Instrument_CartId",
                table: "Instrument",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCart_AuthUserId1",
                table: "UserCart",
                column: "AuthUserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Instrument_Cart_CartId",
                table: "Instrument",
                column: "CartId",
                principalTable: "Cart",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
