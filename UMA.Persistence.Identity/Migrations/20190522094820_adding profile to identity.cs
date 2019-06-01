using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UMA.Persistence.Identity.Migrations
{
    public partial class addingprofiletoidentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IdentityRole_Identity_IdentityId",
                table: "IdentityRole");

            migrationBuilder.DropForeignKey(
                name: "FK_IdentityRole_Role_RoleId",
                table: "IdentityRole");

            migrationBuilder.AlterColumn<Guid>(
                name: "RoleId",
                table: "IdentityRole",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "IdentityId",
                table: "IdentityRole",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Profile",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Locale = table.Column<string>(maxLength: 6, nullable: true, defaultValue: "en-US"),
                    IdentityId = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profile", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Profile_Identity_IdentityId",
                        column: x => x.IdentityId,
                        principalTable: "Identity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Profile_IdentityId",
                table: "Profile",
                column: "IdentityId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_IdentityRole_Identity_IdentityId",
                table: "IdentityRole",
                column: "IdentityId",
                principalTable: "Identity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
                name: "FK_IdentityRole_Identity_IdentityId",
                table: "IdentityRole");

            migrationBuilder.DropForeignKey(
                name: "FK_IdentityRole_Role_RoleId",
                table: "IdentityRole");

            migrationBuilder.DropTable(
                name: "Profile");

            migrationBuilder.AlterColumn<Guid>(
                name: "RoleId",
                table: "IdentityRole",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<Guid>(
                name: "IdentityId",
                table: "IdentityRole",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddForeignKey(
                name: "FK_IdentityRole_Identity_IdentityId",
                table: "IdentityRole",
                column: "IdentityId",
                principalTable: "Identity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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
