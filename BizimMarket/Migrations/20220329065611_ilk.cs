using Microsoft.EntityFrameworkCore.Migrations;

namespace BizimMarket.Migrations
{
    public partial class ilk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kategoriler",
                columns: table => new
                {
                    KategoriId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KategoriAdi = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategoriler", x => x.KategoriId);
                });

            migrationBuilder.CreateTable(
                name: "Urunler",
                columns: table => new
                {
                    UrunId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UrunAdi = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Fiyat = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ResimYolu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KategoriId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Urunler", x => x.UrunId);
                    table.ForeignKey(
                        name: "FK_Urunler_Kategoriler_KategoriId",
                        column: x => x.KategoriId,
                        principalTable: "Kategoriler",
                        principalColumn: "KategoriId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Kategoriler",
                columns: new[] { "KategoriId", "KategoriAdi" },
                values: new object[] { 1, "Fırın,Pastane" });

            migrationBuilder.InsertData(
                table: "Kategoriler",
                columns: new[] { "KategoriId", "KategoriAdi" },
                values: new object[] { 2, "Meze,Hazır Yemek" });

            migrationBuilder.InsertData(
                table: "Kategoriler",
                columns: new[] { "KategoriId", "KategoriAdi" },
                values: new object[] { 3, "Meyve,Sebze" });

            migrationBuilder.InsertData(
                table: "Urunler",
                columns: new[] { "UrunId", "Fiyat", "KategoriId", "ResimYolu", "UrunAdi" },
                values: new object[,]
                {
                    { 1, 22.90m, 1, "minikSandvic.jpg", "Minik Sandviç 10'Lu" },
                    { 2, 9.90m, 1, "papatyaEkmek.jpg", "Papatya Ekmek 300 G (Küçük) ( Yeni )" },
                    { 3, 24.95m, 2, "simit.jpg", "Superfresh 7/24 Fırından Simit 400 G" },
                    { 4, 44.90m, 2, "comboSogan.jpg", "Feast Combo Soğan Halkalı 740 G" },
                    { 5, 19.90m, 3, "domates.jpg", "Domates Kokteyl Kg" },
                    { 6, 24.95m, 3, "karnabahar.jpg", "Karnabahar Kg" },
                    { 7, 43.90m, 3, "biber.jpg", "Biber Acı Şili Kırmızı Kg" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Urunler_KategoriId",
                table: "Urunler",
                column: "KategoriId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Urunler");

            migrationBuilder.DropTable(
                name: "Kategoriler");
        }
    }
}
