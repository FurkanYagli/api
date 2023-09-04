using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class First : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BelBilgileri",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adres = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fax = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KayitTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GuncellemeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BelBilgileri", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BildiriFotograflar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KayitTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GuncellemeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BildiriFotograflar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DuyuruFotograflar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KayitTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GuncellemeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DuyuruFotograflar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Islmler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KayitTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GuncellemeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Islmler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Kategoriler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KayitTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GuncellemeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategoriler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Kisiler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Aktif = table.Column<bool>(type: "bit", nullable: false),
                    Tc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Soyad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KayitTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GuncellemeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kisiler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Konumlar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    X = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Y = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KayitTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GuncellemeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Konumlar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sayfalar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KayitTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GuncellemeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sayfalar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SilinmeTurleri",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tur = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KayitTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GuncellemeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SilinmeTurleri", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SmsTurleri",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SmsFlag = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KayitTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GuncellemeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SmsTurleri", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Duyurular",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Baslik = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FotografId = table.Column<int>(type: "int", nullable: false),
                    KayitTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GuncellemeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Duyurular", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Duyurular_DuyuruFotograflar_FotografId",
                        column: x => x.FotografId,
                        principalTable: "DuyuruFotograflar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AltKategoriler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KategoriId = table.Column<int>(type: "int", nullable: false),
                    Ad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KayitTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GuncellemeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AltKategoriler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AltKategoriler_Kategoriler_KategoriId",
                        column: x => x.KategoriId,
                        principalTable: "Kategoriler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Kullanicilar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Aktif = table.Column<bool>(type: "bit", nullable: false),
                    KisiId = table.Column<int>(type: "int", nullable: false),
                    KayitTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GuncellemeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    KullaniciAdi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KullaniciSifre = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kullanicilar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Kullanicilar_Kisiler_KisiId",
                        column: x => x.KisiId,
                        principalTable: "Kisiler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Smsler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KisiId = table.Column<int>(type: "int", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Kod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GidenTel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GecerlilikTarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    KayitTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GuncellemeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SmsTur = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Smsler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Smsler_Kisiler_KisiId",
                        column: x => x.KisiId,
                        principalTable: "Kisiler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Aktiflikler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PasifTuru = table.Column<int>(type: "int", nullable: false),
                    KisiId = table.Column<int>(type: "int", nullable: false),
                    BitisTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Aktif = table.Column<bool>(type: "bit", nullable: false),
                    KayitTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GuncellemeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PasifTuruNavigationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aktiflikler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Aktiflikler_Kisiler_KisiId",
                        column: x => x.KisiId,
                        principalTable: "Kisiler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Aktiflikler_SilinmeTurleri_PasifTuruNavigationId",
                        column: x => x.PasifTuruNavigationId,
                        principalTable: "SilinmeTurleri",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bildiriler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AltKategoriId = table.Column<int>(type: "int", nullable: true),
                    KullaniciId = table.Column<int>(type: "int", nullable: false),
                    KonumId = table.Column<int>(type: "int", nullable: true),
                    Aciklama = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FotografId = table.Column<int>(type: "int", nullable: true),
                    Aktif = table.Column<bool>(type: "bit", nullable: false),
                    KayitTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GuncellemeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bildiriler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bildiriler_AltKategoriler_AltKategoriId",
                        column: x => x.AltKategoriId,
                        principalTable: "AltKategoriler",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Bildiriler_BildiriFotograflar_FotografId",
                        column: x => x.FotografId,
                        principalTable: "BildiriFotograflar",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Bildiriler_Konumlar_KonumId",
                        column: x => x.KonumId,
                        principalTable: "Konumlar",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Bildiriler_Kullanicilar_KullaniciId",
                        column: x => x.KullaniciId,
                        principalTable: "Kullanicilar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Hareketler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KullaniciId = table.Column<int>(type: "int", nullable: false),
                    SayfaId = table.Column<int>(type: "int", nullable: true),
                    IslemId = table.Column<int>(type: "int", nullable: true),
                    KayitTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GuncellemeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hareketler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hareketler_Islmler_IslemId",
                        column: x => x.IslemId,
                        principalTable: "Islmler",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Hareketler_Kullanicilar_KullaniciId",
                        column: x => x.KullaniciId,
                        principalTable: "Kullanicilar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Hareketler_Sayfalar_SayfaId",
                        column: x => x.SayfaId,
                        principalTable: "Sayfalar",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Gikom",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BildiriId = table.Column<int>(type: "int", nullable: false),
                    KayitTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GuncellemeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gikom", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Gikom_Bildiriler_BildiriId",
                        column: x => x.BildiriId,
                        principalTable: "Bildiriler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Aktiflikler_KisiId",
                table: "Aktiflikler",
                column: "KisiId");

            migrationBuilder.CreateIndex(
                name: "IX_Aktiflikler_PasifTuruNavigationId",
                table: "Aktiflikler",
                column: "PasifTuruNavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_AltKategoriler_KategoriId",
                table: "AltKategoriler",
                column: "KategoriId");

            migrationBuilder.CreateIndex(
                name: "IX_Bildiriler_AltKategoriId",
                table: "Bildiriler",
                column: "AltKategoriId");

            migrationBuilder.CreateIndex(
                name: "IX_Bildiriler_FotografId",
                table: "Bildiriler",
                column: "FotografId");

            migrationBuilder.CreateIndex(
                name: "IX_Bildiriler_KonumId",
                table: "Bildiriler",
                column: "KonumId");

            migrationBuilder.CreateIndex(
                name: "IX_Bildiriler_KullaniciId",
                table: "Bildiriler",
                column: "KullaniciId");

            migrationBuilder.CreateIndex(
                name: "IX_Duyurular_FotografId",
                table: "Duyurular",
                column: "FotografId");

            migrationBuilder.CreateIndex(
                name: "IX_Gikom_BildiriId",
                table: "Gikom",
                column: "BildiriId");

            migrationBuilder.CreateIndex(
                name: "IX_Hareketler_IslemId",
                table: "Hareketler",
                column: "IslemId");

            migrationBuilder.CreateIndex(
                name: "IX_Hareketler_KullaniciId",
                table: "Hareketler",
                column: "KullaniciId");

            migrationBuilder.CreateIndex(
                name: "IX_Hareketler_SayfaId",
                table: "Hareketler",
                column: "SayfaId");

            migrationBuilder.CreateIndex(
                name: "IX_Kullanicilar_KisiId",
                table: "Kullanicilar",
                column: "KisiId");

            migrationBuilder.CreateIndex(
                name: "IX_Smsler_KisiId",
                table: "Smsler",
                column: "KisiId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Aktiflikler");

            migrationBuilder.DropTable(
                name: "BelBilgileri");

            migrationBuilder.DropTable(
                name: "Duyurular");

            migrationBuilder.DropTable(
                name: "Gikom");

            migrationBuilder.DropTable(
                name: "Hareketler");

            migrationBuilder.DropTable(
                name: "Smsler");

            migrationBuilder.DropTable(
                name: "SmsTurleri");

            migrationBuilder.DropTable(
                name: "SilinmeTurleri");

            migrationBuilder.DropTable(
                name: "DuyuruFotograflar");

            migrationBuilder.DropTable(
                name: "Bildiriler");

            migrationBuilder.DropTable(
                name: "Islmler");

            migrationBuilder.DropTable(
                name: "Sayfalar");

            migrationBuilder.DropTable(
                name: "AltKategoriler");

            migrationBuilder.DropTable(
                name: "BildiriFotograflar");

            migrationBuilder.DropTable(
                name: "Konumlar");

            migrationBuilder.DropTable(
                name: "Kullanicilar");

            migrationBuilder.DropTable(
                name: "Kategoriler");

            migrationBuilder.DropTable(
                name: "Kisiler");
        }
    }
}
