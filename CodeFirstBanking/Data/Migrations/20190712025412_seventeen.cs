using Microsoft.EntityFrameworkCore.Migrations;

namespace CodeFirstBanking.Data.Migrations
{
    public partial class seventeen : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccountName",
                table: "Term");

            migrationBuilder.DropColumn(
                name: "MaturityInYears",
                table: "Term");

            migrationBuilder.DropColumn(
                name: "AccountName",
                table: "Loan");

            migrationBuilder.DropColumn(
                name: "AccountName",
                table: "Checking");

            migrationBuilder.DropColumn(
                name: "AccountName",
                table: "Business");

            migrationBuilder.AddColumn<int>(
                name: "AccountBalance",
                table: "Loan",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccountBalance",
                table: "Loan");

            migrationBuilder.AddColumn<string>(
                name: "AccountName",
                table: "Term",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MaturityInYears",
                table: "Term",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "AccountName",
                table: "Loan",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AccountName",
                table: "Checking",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AccountName",
                table: "Business",
                nullable: true);
        }
    }
}
