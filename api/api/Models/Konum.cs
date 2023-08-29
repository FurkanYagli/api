using System;
using System.Collections.Generic;

namespace api.Models;

public partial class Konum
{
    public int Id { get; set; }

    public string? X { get; set; }

    public string? Y { get; set; }

    public DateTime? KayitTarihi { get; set; }

    public DateTime? GuncellemeTarihi { get; set; }

    public virtual ICollection<Bildiris> Bildirises { get; set; } = new List<Bildiris>();
}
