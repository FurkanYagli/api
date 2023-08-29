using System;
using System.Collections.Generic;

namespace api.Models;

public partial class SilinmeTurleri
{
    public int Id { get; set; }

    public string? Tur { get; set; }

    public DateTime? KayitTarihi { get; set; }

    public DateTime? GuncellemeTarihi { get; set; }

    public virtual ICollection<Aktiflik> Aktifliks { get; set; } = new List<Aktiflik>();
}
