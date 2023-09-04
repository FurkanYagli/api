using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models;
[Table("SmsTurleri")]

public partial class TurSms
{
    public int Id { get; set; }

    public string? SmsFlag { get; set; }

    public DateTime? KayitTarihi { get; set; }

    public DateTime? GuncellemeTarihi { get; set; }
}
