using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models;
[Table("Smsler")]

public partial class Sms
{
    public int Id { get; set; }

    public int KisiId { get; set; }

    public string? Text { get; set; }

    public string? Kod { get; set; }

    public string? GidenTel { get; set; }

    public DateTime GecerlilikTarih { get; set; }

    public DateTime? KayitTarihi { get; set; }

    public DateTime? GuncellemeTarihi { get; set; }

    public int SmsTur { get; set; }

    public virtual Kisi Kisi { get; set; } = null!;
}
