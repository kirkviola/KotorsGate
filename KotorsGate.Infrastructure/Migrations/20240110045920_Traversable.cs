using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KotorsGate.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Traversable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "YCoordinate",
                table: "LocationSquares",
                type: "int",
                maxLength: 200,
                nullable: false,
                defaultValue: 1,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 64);

            migrationBuilder.AlterColumn<int>(
                name: "XCoordinate",
                table: "LocationSquares",
                type: "int",
                maxLength: 200,
                nullable: false,
                defaultValue: 1,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 64);

            migrationBuilder.AddColumn<bool>(
                name: "IsTraversable",
                table: "LocationSquares",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsTraversable",
                table: "LocationSquares");

            migrationBuilder.AlterColumn<int>(
                name: "YCoordinate",
                table: "LocationSquares",
                type: "int",
                maxLength: 64,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 200,
                oldDefaultValue: 1);

            migrationBuilder.AlterColumn<int>(
                name: "XCoordinate",
                table: "LocationSquares",
                type: "int",
                maxLength: 64,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 200,
                oldDefaultValue: 1);
        }
    }
}
