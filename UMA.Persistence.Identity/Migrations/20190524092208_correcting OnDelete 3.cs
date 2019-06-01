using Microsoft.EntityFrameworkCore.Migrations;

namespace UMA.Persistence.Identity.Migrations
{
    public partial class correctingOnDelete3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IdentityRole_Identity_IdentityId",
                table: "IdentityRole");

            migrationBuilder.AddForeignKey(
                name: "FK_IdentityRole_Identity_IdentityId",
                table: "IdentityRole",
                column: "IdentityId",
                principalTable: "Identity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IdentityRole_Identity_IdentityId",
                table: "IdentityRole");

            migrationBuilder.AddForeignKey(
                name: "FK_IdentityRole_Identity_IdentityId",
                table: "IdentityRole",
                column: "IdentityId",
                principalTable: "Identity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
