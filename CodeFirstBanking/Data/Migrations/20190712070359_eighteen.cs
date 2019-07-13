using Microsoft.EntityFrameworkCore.Migrations;

namespace CodeFirstBanking.Data.Migrations
{
    public partial class eighteen : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BusinessTrans_Business_BusinessId",
                table: "BusinessTrans");

            migrationBuilder.DropForeignKey(
                name: "FK_CheckingTrans_Checking_CheckingId",
                table: "CheckingTrans");

            migrationBuilder.DropForeignKey(
                name: "FK_LoanTrans_Loan_LoanId",
                table: "LoanTrans");

            migrationBuilder.DropForeignKey(
                name: "FK_TermTrans_Term_TermId",
                table: "TermTrans");

            migrationBuilder.DropIndex(
                name: "IX_TermTrans_TermId",
                table: "TermTrans");

            migrationBuilder.DropIndex(
                name: "IX_LoanTrans_LoanId",
                table: "LoanTrans");

            migrationBuilder.DropIndex(
                name: "IX_CheckingTrans_CheckingId",
                table: "CheckingTrans");

            migrationBuilder.DropIndex(
                name: "IX_BusinessTrans_BusinessId",
                table: "BusinessTrans");

            migrationBuilder.DropColumn(
                name: "TransType",
                table: "TermTrans");

            migrationBuilder.DropColumn(
                name: "TransType",
                table: "LoanTrans");

            migrationBuilder.DropColumn(
                name: "TransType",
                table: "CheckingTrans");

            migrationBuilder.DropColumn(
                name: "TransType",
                table: "BusinessTrans");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TransType",
                table: "TermTrans",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TransType",
                table: "LoanTrans",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TransType",
                table: "CheckingTrans",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TransType",
                table: "BusinessTrans",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TermTrans_TermId",
                table: "TermTrans",
                column: "TermId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanTrans_LoanId",
                table: "LoanTrans",
                column: "LoanId");

            migrationBuilder.CreateIndex(
                name: "IX_CheckingTrans_CheckingId",
                table: "CheckingTrans",
                column: "CheckingId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessTrans_BusinessId",
                table: "BusinessTrans",
                column: "BusinessId");

            migrationBuilder.AddForeignKey(
                name: "FK_BusinessTrans_Business_BusinessId",
                table: "BusinessTrans",
                column: "BusinessId",
                principalTable: "Business",
                principalColumn: "BusinessId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CheckingTrans_Checking_CheckingId",
                table: "CheckingTrans",
                column: "CheckingId",
                principalTable: "Checking",
                principalColumn: "CheckingId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LoanTrans_Loan_LoanId",
                table: "LoanTrans",
                column: "LoanId",
                principalTable: "Loan",
                principalColumn: "LoanId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TermTrans_Term_TermId",
                table: "TermTrans",
                column: "TermId",
                principalTable: "Term",
                principalColumn: "TermId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
