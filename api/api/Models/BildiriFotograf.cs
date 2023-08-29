using System;
using System.Collections.Generic;

namespace api.Models;

public partial class BildiriFotograf
{
    public int Id { get; set; }

    public string? Image { get; set; }

    public DateTime? KayitTarihi { get; set; }

    public DateTime? GuncellemeTarihi { get; set; }

    public virtual ICollection<Bildiris> Bildirises { get; set; } = new List<Bildiris>();
}
