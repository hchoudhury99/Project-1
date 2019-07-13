using Microsoft.EntityFrameworkCore.Migrations;

namespace CodeFirstBanking.Data.Migrations
{
    public partial class ninth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BusinessId",
                table: "Checking",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Checking_BusinessId",
                table: "Checking",
                column: "BusinessId");

            migrationBuilder.AddForeignKey(
                name: "FK_Checking_Business_BusinessId",
                table: "Checking",
                column: "BusinessId",
                principalTable: "Business",
                principalColumn: "BusinessId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Checking_Business_BusinessId",
                table: "Checking");

            migrationBuilder.DropIndex(
                name: "IX_Checking_BusinessId",
                table: "Checking");

            migrationBuilder.DropColumn(
                name: "BusinessId",
                table: "Checking");
        }
    }
}
