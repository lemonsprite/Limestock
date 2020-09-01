using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Limestock.EFramework.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Konsumen",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NamaKonsumen = table.Column<string>(maxLength: 64, nullable: true),
                    AlamatKonsumen = table.Column<string>(maxLength: 150, nullable: true),
                    TelpKonsumen = table.Column<int>(maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Konsumen", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Produk",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NamaProduk = table.Column<string>(maxLength: 100, nullable: true),
                    StokBarang = table.Column<int>(maxLength: 10, nullable: false),
                    SatuanBarang = table.Column<string>(maxLength: 10, nullable: true),
                    SimbolSatuan = table.Column<string>(maxLength: 5, nullable: true),
                    HargaProduk = table.Column<double>(maxLength: 10, nullable: false),
                    KetersediaanBarang = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produk", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NamaLengkap = table.Column<string>(maxLength: 150, nullable: false),
                    UserName = table.Column<string>(maxLength: 100, nullable: false),
                    UserMail = table.Column<string>(maxLength: 50, nullable: false),
                    UserPass = table.Column<string>(maxLength: 16, nullable: false),
                    TanggalBerubah = table.Column<DateTime>(nullable: false),
                    TanggalDibuat = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NamaKonsumen = table.Column<string>(nullable: true),
                    TglOrder = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<int>(nullable: true),
                    KonsumenId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Order_Konsumen_KonsumenId",
                        column: x => x.KonsumenId,
                        principalTable: "Konsumen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Order_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Order_KonsumenId",
                table: "Order",
                column: "KonsumenId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_UserId",
                table: "Order",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Produk");

            migrationBuilder.DropTable(
                name: "Konsumen");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
