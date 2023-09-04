using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models;
[Table("DuyuruFotograflar")]

public partial class DuyuruFotograf
{
    public int Id { get; set; }

    public string? Ad { get; set; }

    public DateTime? KayitTarihi { get; set; }

    public DateTime? GuncellemeTarihi { get; set; }

    public virtual ICollection<Duyuru> Duyurus { get; set; } = new List<Duyuru>();
}
