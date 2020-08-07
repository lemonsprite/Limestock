using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Limestock.EFramework.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    namaLengkap = table.Column<string>(nullable: true),
                    userEmail = table.Column<string>(nullable: true),
                    userName = table.Column<string>(nullable: true),
                    userPassword = table.Column<string>(nullable: true),
                    createdTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
