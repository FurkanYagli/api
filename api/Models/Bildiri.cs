using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models;
[Table("Bildiriler")]

public partial class Bildiri
{
    public int Id { get; set; }

    public int? AltKategoriId { get; set; }

    public int KullaniciId { get; set; }

    public int? KonumId { get; set; }

    public string? Aciklama { get; set; }

    public int? FotografId { get; set; }

    public bool Aktif { get; set; }

    public DateTime? KayitTarihi { get; set; }

    public DateTime? GuncellemeTarihi { get; set; }

    public virtual AltKategori? AltKategori { get; set; }

    public virtual BildiriFotograf? Fotograf { get; set; }

    public virtual ICollection<Gikom> Gikoms { get; set; } = new List<Gikom>();

    public virtual Konum? Konum { get; set; }

    public virtual Kullanici Kullanici { get; set; } = null!;
}
