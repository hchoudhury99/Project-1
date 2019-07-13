using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CodeFirstBanking.Data.Migrations
{
    public partial class eight : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BusinessTrans",
                columns: table => new
                {
                    BusinessTransId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BusinessId = table.Column<int>(nullable: false),
                    Time = table.Column<DateTime>(nullable: false),
                    Amount = table.Column<int>(nullable: false),
                    TransType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessTrans", x => x.BusinessTransId);
                    table.ForeignKey(
                        name: "FK_BusinessTrans_Business_BusinessId",
                        column: x => x.BusinessId,
                        principalTable: "Business",
                        principalColumn: "BusinessId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CheckingTrans",
                columns: table => new
                {
                    CheckingTransId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CheckingId = table.Column<int>(nullable: false),
                    Time = table.Column<DateTime>(nullable: false),
                    Amount = table.Column<int>(nullable: false),
                    TransType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckingTrans", x => x.CheckingTransId);
                    table.ForeignKey(
                        name: "FK_CheckingTrans_Checking_CheckingId",
                        column: x => x.CheckingId,
                        principalTable: "Checking",
                        principalColumn: "CheckingId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LoanTrans",
                columns: table => new
                {
                    LoanTransId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LoanId = table.Column<int>(nullable: false),
                    Time = table.Column<DateTime>(nullable: false),
                    Amount = table.Column<int>(nullable: false),
                    TransType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanTrans", x => x.LoanTransId);
                    table.ForeignKey(
                        name: "FK_LoanTrans_Loan_LoanId",
                        column: x => x.LoanId,
                        principalTable: "Loan",
                        principalColumn: "LoanId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TermTrans",
                columns: table => new
                {
                    TermTransId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TermId = table.Column<int>(nullable: false),
                    Time = table.Column<DateTime>(nullable: false),
                    Amount = table.Column<int>(nullable: false),
                    TransType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TermTrans", x => x.TermTransId);
                    table.ForeignKey(
                        name: "FK_TermTrans_Term_TermId",
                        column: x => x.TermId,
                        principalTable: "Term",
                        principalColumn: "TermId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transfer",
                columns: table => new
                {
                    TransferId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AccOneId = table.Column<int>(nullable: false),
                    AccTwoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transfer", x => x.TransferId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BusinessTrans_BusinessId",
                table: "BusinessTrans",
                column: "BusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_CheckingTrans_CheckingId",
                table: "CheckingTrans",
                column: "CheckingId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanTrans_LoanId",
                table: "LoanTrans",
                column: "LoanId");

            migrationBuilder.CreateIndex(
                name: "IX_TermTrans_TermId",
                table: "TermTrans",
                column: "TermId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BusinessTrans");

            migrationBuilder.DropTable(
                name: "CheckingTrans");

            migrationBuilder.DropTable(
                name: "LoanTrans");

            migrationBuilder.DropTable(
                name: "TermTrans");

            migrationBuilder.DropTable(
                name: "Transfer");
        }
    }
}
