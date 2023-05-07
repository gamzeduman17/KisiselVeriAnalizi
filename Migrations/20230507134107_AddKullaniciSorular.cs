using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VeriAnalizi.Migrations
{
    public partial class AddKullaniciSorular : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           

            migrationBuilder.CreateTable(
                name: "KullaniciSorulars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Soru = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Secenek1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Secenek2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Secenek3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Secenek4 = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KullaniciSorulars", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
        

            migrationBuilder.CreateTable(
                name: "KullaniciSorulars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cevap1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cevap2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cevap3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cevap4 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Soru = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sorular", x => x.Id);
                });
        }
    }
}
