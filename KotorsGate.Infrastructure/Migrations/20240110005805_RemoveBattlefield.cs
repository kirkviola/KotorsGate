using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KotorsGate.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemoveBattlefield : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BattlefieldSquares");

            migrationBuilder.DropTable(
                name: "Battlefields");

            migrationBuilder.CreateTable(
                name: "LocationSquares",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LocationId = table.Column<int>(type: "int", nullable: false),
                    XCoordinate = table.Column<int>(type: "int", maxLength: 64, nullable: false),
                    YCoordinate = table.Column<int>(type: "int", maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationSquares", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LocationSquares_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LocationSquares_LocationId",
                table: "LocationSquares",
                column: "LocationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LocationSquares");

            migrationBuilder.CreateTable(
                name: "Battlefields",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LocationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Battlefields", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Battlefields_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BattlefieldSquares",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BattlefieldId = table.Column<int>(type: "int", nullable: false),
                    XCoordinate = table.Column<int>(type: "int", maxLength: 64, nullable: false),
                    YCoordinate = table.Column<int>(type: "int", maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BattlefieldSquares", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BattlefieldSquares_Battlefields_BattlefieldId",
                        column: x => x.BattlefieldId,
                        principalTable: "Battlefields",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Battlefields_LocationId",
                table: "Battlefields",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_BattlefieldSquares_BattlefieldId",
                table: "BattlefieldSquares",
                column: "BattlefieldId");
        }
    }
}
