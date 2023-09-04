using System;
using System.Collections.Generic;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Context;

public partial class WebApiContext : DbContext
{
    public WebApiContext()
    {
    }

    public WebApiContext(DbContextOptions<WebApiContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Aktiflik> Aktiflikler { get; set; }

    public virtual DbSet<AltKategori> AltKategoriler { get; set; }

    public virtual DbSet<BelBilgi> BelBilgiler { get; set; }

    public virtual DbSet<BildiriFotograf> BildiriFotograflar { get; set; }

    public virtual DbSet<Bildiri> Bildiriler { get; set; }

    public virtual DbSet<Duyuru> Duyurular { get; set; }

    public virtual DbSet<DuyuruFotograf> DuyuruFotograflar { get; set; }

    public virtual DbSet<Gikom> Gikom { get; set; }

    public virtual DbSet<Hareket> Hareketler { get; set; }

    public virtual DbSet<Islem> Islemler { get; set; }

    public virtual DbSet<Kategori> Kategoriler { get; set; }

    public virtual DbSet<Kisi> Kisiler { get; set; }

    public virtual DbSet<Konum> Konumlar { get; set; }

    public virtual DbSet<Kullanici> Kullanicilar { get; set; }

    public virtual DbSet<Sayfa> Sayfalar { get; set; }

    public virtual DbSet<SilinmeTurleri> SilinmeTurleri { get; set; }

    public virtual DbSet<Sms> Smsler { get; set; }

    public virtual DbSet<TurSms> TurSmsler { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS; Database=Api; Integrated Security=True; TrustServerCertificate=True;");
    }

    //    protected override void OnModelCreating(ModelBuilder modelBuilder)
    //    {
    //        modelBuilder.Entity<Aktiflik>(entity =>
    //        {
    //            entity.HasKey(e => e.Id).HasName("PK_dbo.Aktifliks");

    //            entity.HasIndex(e => e.KisiId, "IX_KisiId");

    //            entity.HasIndex(e => e.PasifTuru, "IX_PasifTuru");

    //            entity.Property(e => e.BitisTarihi).HasColumnType("datetime");
    //            entity.Property(e => e.GuncellemeTarihi).HasColumnType("datetime");
    //            entity.Property(e => e.KayitTarihi).HasColumnType("datetime");

    //            entity.HasOne(d => d.Kisi).WithMany(p => p.Aktifliks)
    //                .HasForeignKey(d => d.KisiId)
    //                .HasConstraintName("FK_dbo.Aktifliks_dbo.Kisis_KisiId");

    //            entity.HasOne(d => d.PasifTuruNavigation).WithMany(p => p.Aktifliks)
    //                .HasForeignKey(d => d.PasifTuru)
    //                .HasConstraintName("FK_dbo.Aktifliks_dbo.SilinmeTurleris_PasifTuru");
    //        });

    //        modelBuilder.Entity<AltKategori>(entity =>
    //        {
    //            entity.HasKey(e => e.Id).HasName("PK_dbo.AltKategoris");

    //            entity.HasIndex(e => e.KategoriId, "IX_KategoriId");

    //            entity.Property(e => e.GuncellemeTarihi).HasColumnType("datetime");
    //            entity.Property(e => e.KayitTarihi).HasColumnType("datetime");

    //            entity.HasOne(d => d.Kategori).WithMany(p => p.AltKategoris)
    //                .HasForeignKey(d => d.KategoriId)
    //                .HasConstraintName("FK_dbo.AltKategoris_dbo.Kategoris_KategoriId");
    //        });

    //        modelBuilder.Entity<BelBilgi>(entity =>
    //        {
    //            entity.HasKey(e => e.Id).HasName("PK_dbo.BelBilgis");

    //            entity.Property(e => e.GuncellemeTarihi).HasColumnType("datetime");
    //            entity.Property(e => e.KayitTarihi).HasColumnType("datetime");
    //        });

    //        modelBuilder.Entity<BildiriFotograf>(entity =>
    //        {
    //            entity.HasKey(e => e.Id).HasName("PK_dbo.BildiriFotografs");

    //            entity.Property(e => e.GuncellemeTarihi).HasColumnType("datetime");
    //            entity.Property(e => e.KayitTarihi).HasColumnType("datetime");
    //        });

    //        modelBuilder.Entity<Bildiri>(entity =>
    //        {
    //            entity.HasKey(e => e.Id).HasName("PK_dbo.Bildiris");

    //            entity.ToTable("Bildiris");

    //            entity.HasIndex(e => e.AltKategoriId, "IX_AltKategoriId");

    //            entity.HasIndex(e => e.FotografId, "IX_FotografId");

    //            entity.HasIndex(e => e.KonumId, "IX_KonumId");

    //            entity.HasIndex(e => e.KullaniciId, "IX_KullaniciId");

    //            entity.Property(e => e.GuncellemeTarihi).HasColumnType("datetime");
    //            entity.Property(e => e.KayitTarihi).HasColumnType("datetime");

    //            entity.HasOne(d => d.AltKategori).WithMany(p => p.Bildirises)
    //                .HasForeignKey(d => d.AltKategoriId)
    //                .HasConstraintName("FK_dbo.Bildiris_dbo.AltKategoris_AltKategoriId");

    //            entity.HasOne(d => d.Fotograf).WithMany(p => p.Bildirises)
    //                .HasForeignKey(d => d.FotografId)
    //                .HasConstraintName("FK_dbo.Bildiris_dbo.BildiriFotografs_FotografId");

    //            entity.HasOne(d => d.Konum).WithMany(p => p.Bildirises)
    //                .HasForeignKey(d => d.KonumId)
    //                .HasConstraintName("FK_dbo.Bildiris_dbo.Konums_KonumId");

    //            entity.HasOne(d => d.Kullanici).WithMany(p => p.Bildirises)
    //                .HasForeignKey(d => d.KullaniciId)
    //                .HasConstraintName("FK_dbo.Bildiris_dbo.Kullanicis_KullaniciId");
    //        });

    //        modelBuilder.Entity<Duyuru>(entity =>
    //        {
    //            entity.HasKey(e => e.Id).HasName("PK_dbo.Duyurus");

    //            entity.HasIndex(e => e.FotografId, "IX_FotografId");

    //            entity.Property(e => e.GuncellemeTarihi).HasColumnType("datetime");
    //            entity.Property(e => e.KayitTarihi).HasColumnType("datetime");

    //            entity.HasOne(d => d.Fotograf).WithMany(p => p.Duyurus)
    //                .HasForeignKey(d => d.FotografId)
    //                .HasConstraintName("FK_dbo.Duyurus_dbo.DuyuruFotografs_FotografId");
    //        });

    //        modelBuilder.Entity<DuyuruFotograf>(entity =>
    //        {
    //            entity.HasKey(e => e.Id).HasName("PK_dbo.DuyuruFotografs");

    //            entity.Property(e => e.GuncellemeTarihi).HasColumnType("datetime");
    //            entity.Property(e => e.KayitTarihi).HasColumnType("datetime");
    //        });

    //        modelBuilder.Entity<Gikom>(entity =>
    //        {
    //            entity.HasKey(e => e.Id).HasName("PK_dbo.Gikoms");

    //            entity.HasIndex(e => e.BildiriId, "IX_BildiriId");

    //            entity.Property(e => e.GuncellemeTarihi).HasColumnType("datetime");
    //            entity.Property(e => e.KayitTarihi).HasColumnType("datetime");

    //            entity.HasOne(d => d.Bildiri).WithMany(p => p.Gikoms)
    //                .HasForeignKey(d => d.BildiriId)
    //                .HasConstraintName("FK_dbo.Gikoms_dbo.Bildiris_BildiriId");
    //        });

    //        modelBuilder.Entity<Hareket>(entity =>
    //        {
    //            entity.HasKey(e => e.Id).HasName("PK_dbo.Harekets");

    //            entity.HasIndex(e => e.IslemId, "IX_IslemId");

    //            entity.HasIndex(e => e.KullaniciId, "IX_KullaniciId");

    //            entity.HasIndex(e => e.SayfaId, "IX_SayfaId");

    //            entity.Property(e => e.GuncellemeTarihi).HasColumnType("datetime");
    //            entity.Property(e => e.KayitTarihi).HasColumnType("datetime");

    //            entity.HasOne(d => d.Islem).WithMany(p => p.Harekets)
    //                .HasForeignKey(d => d.IslemId)
    //                .HasConstraintName("FK_dbo.Harekets_dbo.Islems_IslemId");

    //            entity.HasOne(d => d.Kullanici).WithMany(p => p.Harekets)
    //                .HasForeignKey(d => d.KullaniciId)
    //                .HasConstraintName("FK_dbo.Harekets_dbo.Kullanicis_KullaniciId");

    //            entity.HasOne(d => d.Sayfa).WithMany(p => p.Harekets)
    //                .HasForeignKey(d => d.SayfaId)
    //                .HasConstraintName("FK_dbo.Harekets_dbo.Sayfas_SayfaId");
    //        });

    //        modelBuilder.Entity<Islem>(entity =>
    //        {
    //            entity.HasKey(e => e.Id).HasName("PK_dbo.Islems");

    //            entity.Property(e => e.GuncellemeTarihi).HasColumnType("datetime");
    //            entity.Property(e => e.KayitTarihi).HasColumnType("datetime");
    //        });

    //        modelBuilder.Entity<Kategori>(entity =>
    //        {
    //            entity.HasKey(e => e.Id).HasName("PK_dbo.Kategoris");

    //            entity.Property(e => e.GuncellemeTarihi).HasColumnType("datetime");
    //            entity.Property(e => e.KayitTarihi).HasColumnType("datetime");
    //        });

    //        modelBuilder.Entity<Kisi>(entity =>
    //        {
    //            entity.HasKey(e => e.Id).HasName("PK_dbo.Kisis");

    //            entity.ToTable("Kisis");

    //            entity.Property(e => e.GuncellemeTarihi).HasColumnType("datetime");
    //            entity.Property(e => e.KayitTarihi).HasColumnType("datetime");
    //        });

    //        modelBuilder.Entity<Konum>(entity =>
    //        {
    //            entity.HasKey(e => e.Id).HasName("PK_dbo.Konums");

    //            entity.Property(e => e.GuncellemeTarihi).HasColumnType("datetime");
    //            entity.Property(e => e.KayitTarihi).HasColumnType("datetime");
    //            entity.Property(e => e.X).HasColumnName("x");
    //            entity.Property(e => e.Y).HasColumnName("y");
    //        });

    //        modelBuilder.Entity<Kullanici>(entity =>
    //        {
    //            entity.HasKey(e => e.Id).HasName("PK_dbo.Kullanicis");

    //            entity.HasIndex(e => e.KisiId, "IX_KisiId");

    //            entity.Property(e => e.GuncellemeTarihi).HasColumnType("datetime");
    //            entity.Property(e => e.KayitTarihi).HasColumnType("datetime");

    //            entity.HasOne(d => d.Kisi).WithMany(p => p.Kullanicis)
    //                .HasForeignKey(d => d.KisiId)
    //                .HasConstraintName("FK_dbo.Kullanicis_dbo.Kisis_KisiId");
    //        });

    //        modelBuilder.Entity<Sayfa>(entity =>
    //        {
    //            entity.HasKey(e => e.Id).HasName("PK_dbo.Sayfas");

    //            entity.Property(e => e.GuncellemeTarihi).HasColumnType("datetime");
    //            entity.Property(e => e.KayitTarihi).HasColumnType("datetime");
    //        });

    //        modelBuilder.Entity<SilinmeTurleri>(entity =>
    //        {
    //            entity.HasKey(e => e.Id).HasName("PK_dbo.SilinmeTurleris");

    //            entity.Property(e => e.GuncellemeTarihi).HasColumnType("datetime");
    //            entity.Property(e => e.KayitTarihi).HasColumnType("datetime");
    //        });

    //        modelBuilder.Entity<Sms>(entity =>
    //        {
    //            entity.HasKey(e => e.Id).HasName("PK_dbo.Sms");

    //            entity.HasIndex(e => e.KisiId, "IX_KisiId");

    //            entity.Property(e => e.GecerlilikTarih).HasColumnType("datetime");
    //            entity.Property(e => e.GuncellemeTarihi).HasColumnType("datetime");
    //            entity.Property(e => e.KayitTarihi).HasColumnType("datetime");

    //            entity.HasOne(d => d.Kisi).WithMany(p => p.Sms)
    //                .HasForeignKey(d => d.KisiId)
    //                .HasConstraintName("FK_dbo.Sms_dbo.Kisis_KisiId");
    //        });

    //        modelBuilder.Entity<TurSms>(entity =>
    //        {
    //            entity.HasKey(e => e.Id).HasName("PK_dbo.TurSms");

    //            entity.Property(e => e.GuncellemeTarihi).HasColumnType("datetime");
    //            entity.Property(e => e.KayitTarihi).HasColumnType("datetime");
    //        });

    //        OnModelCreatingPartial(modelBuilder);
    //    }

    //    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}