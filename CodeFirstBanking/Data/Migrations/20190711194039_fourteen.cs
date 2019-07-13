using Microsoft.EntityFrameworkCore.Migrations;

namespace CodeFirstBanking.Data.Migrations
{
    public partial class fourteen : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "businessId",
                table: "Loan",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "checkingId",
                table: "Loan",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "businessId",
                table: "Loan");

            migrationBuilder.DropColumn(
                name: "checkingId",
                table: "Loan");
        }
    }
}
