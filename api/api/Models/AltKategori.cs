using System;
using System.Collections.Generic;

namespace api.Models;

public partial class AltKategori
{
    public int Id { get; set; }

    public int KategoriId { get; set; }

    public string? Ad { get; set; }

    public DateTime? KayitTarihi { get; set; }

    public DateTime? GuncellemeTarihi { get; set; }

    public virtual ICollection<Bildiris> Bildirises { get; set; } = new List<Bildiris>();

    public virtual Kategori Kategori { get; set; } = null!;
}
