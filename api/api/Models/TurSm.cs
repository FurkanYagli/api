using System;
using System.Collections.Generic;

namespace api.Models;

public partial class TurSm
{
    public int Id { get; set; }

    public string? SmsFlag { get; set; }

    public DateTime? KayitTarihi { get; set; }

    public DateTime? GuncellemeTarihi { get; set; }
}
