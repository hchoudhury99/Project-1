using Microsoft.EntityFrameworkCore.Migrations;

namespace CodeFirstBanking.Data.Migrations
{
    public partial class nineteen : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "TermTrans",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "LoanTrans",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "CheckingTrans",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "BusinessTrans",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "TermTrans");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "LoanTrans");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "CheckingTrans");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "BusinessTrans");
        }
    }
}
