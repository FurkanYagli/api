using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models;
[Table("Kategoriler")]

public partial class Kategori
{
    public int Id { get; set; }

    public string? Ad { get; set; }

    public DateTime? KayitTarihi { get; set; }

    public DateTime? GuncellemeTarihi { get; set; }

    public virtual ICollection<AltKategori> AltKategoris { get; set; } = new List<AltKategori>();
}
