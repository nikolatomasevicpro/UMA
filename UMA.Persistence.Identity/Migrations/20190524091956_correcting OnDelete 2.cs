using Microsoft.EntityFrameworkCore.Migrations;

namespace UMA.Persistence.Identity.Migrations
{
    public partial class correctingOnDelete2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IdentityRole_Role_RoleId",
                table: "IdentityRole");

            migrationBuilder.AddForeignKey(
                name: "FK_IdentityRole_Role_RoleId",
                table: "IdentityRole",
                column: "RoleId",
                principalTable: "Role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IdentityRole_Role_RoleId",
                table: "IdentityRole");

            migrationBuilder.AddForeignKey(
                name: "FK_IdentityRole_Role_RoleId",
                table: "IdentityRole",
                column: "RoleId",
                principalTable: "Role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
