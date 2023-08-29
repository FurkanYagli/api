using System;
using System.Collections.Generic;

namespace api.Models;

public partial class Kategori
{
    public int Id { get; set; }

    public string? Ad { get; set; }

    public DateTime? KayitTarihi { get; set; }

    public DateTime? GuncellemeTarihi { get; set; }

    public virtual ICollection<AltKategori> AltKategoris { get; set; } = new List<AltKategori>();
}
