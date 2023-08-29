using System;
using System.Collections.Generic;

namespace api.Models;

public partial class Gikom
{
    public int Id { get; set; }

    public int BildiriId { get; set; }

    public DateTime? KayitTarihi { get; set; }

    public DateTime? GuncellemeTarihi { get; set; }

    public virtual Bildiris Bildiri { get; set; } = null!;
}
