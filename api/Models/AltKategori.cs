using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models;
[Table("AltKategoriler")]

public partial class AltKategori
{
    public int Id { get; set; }

    public int KategoriId { get; set; }

    public string? Ad { get; set; }

    public DateTime? KayitTarihi { get; set; }

    public DateTime? GuncellemeTarihi { get; set; }

    public virtual ICollection<Bildiri> Bildirises { get; set; } = new List<Bildiri>();

    public virtual Kategori Kategori { get; set; } = null!;
}
