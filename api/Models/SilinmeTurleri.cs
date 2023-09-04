using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models;
[Table("SilinmeTurleri")]

public partial class SilinmeTurleri
{
    public int Id { get; set; }

    public string? Tur { get; set; }

    public DateTime? KayitTarihi { get; set; }

    public DateTime? GuncellemeTarihi { get; set; }

    public virtual ICollection<Aktiflik> Aktifliks { get; set; } = new List<Aktiflik>();
}
