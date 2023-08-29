using System;
using System.Collections.Generic;

namespace api.Models;

public partial class BelBilgi
{
    public int Id { get; set; }

    public string? Adres { get; set; }

    public string? Telefon { get; set; }

    public string? Fax { get; set; }

    public string? Mail { get; set; }

    public DateTime? KayitTarihi { get; set; }

    public DateTime? GuncellemeTarihi { get; set; }
}
