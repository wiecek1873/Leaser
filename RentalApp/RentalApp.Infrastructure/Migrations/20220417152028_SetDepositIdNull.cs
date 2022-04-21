using Microsoft.EntityFrameworkCore.Migrations;

namespace RentalApp.Infrastructure.Migrations
{
    public partial class SetDepositIdNull : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Deposits_DepositId",
                table: "Posts");

            migrationBuilder.AlterColumn<int>(
                name: "DepositId",
                table: "Posts",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Deposits_DepositId",
                table: "Posts",
                column: "DepositId",
                principalTable: "Deposits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Deposits_DepositId",
                table: "Posts");

            migrationBuilder.AlterColumn<int>(
                name: "DepositId",
                table: "Posts",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Deposits_DepositId",
                table: "Posts",
                column: "DepositId",
                principalTable: "Deposits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
