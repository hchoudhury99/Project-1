using Microsoft.EntityFrameworkCore.Migrations;

namespace CodeFirstBanking.Data.Migrations
{
    public partial class sixteen : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccountBalance",
                table: "Loan");

            migrationBuilder.RenameColumn(
                name: "Maturity",
                table: "Term",
                newName: "MaturityInYears");

            migrationBuilder.AddColumn<string>(
                name: "AccountName",
                table: "Term",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccountName",
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

            migrationBuilder.RenameColumn(
                name: "MaturityInYears",
                table: "Term",
                newName: "Maturity");

            migrationBuilder.AddColumn<int>(
                name: "AccountBalance",
                table: "Loan",
                nullable: false,
                defaultValue: 0);
        }
    }
}
