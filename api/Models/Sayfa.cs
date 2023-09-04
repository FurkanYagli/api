using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models;
[Table("Sayfalar")]

public partial class Sayfa
{
    public int Id { get; set; }

    public string? Ad { get; set; }

    public DateTime? KayitTarihi { get; set; }

    public DateTime? GuncellemeTarihi { get; set; }

    public virtual ICollection<Hareket> Harekets { get; set; } = new List<Hareket>();
}
