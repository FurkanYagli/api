using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models;
[Table("Duyurular")]

public partial class Duyuru
{
    public int Id { get; set; }

    public string? Baslik { get; set; }

    public string? Text { get; set; }

    public int FotografId { get; set; }

    public DateTime? KayitTarihi { get; set; }

    public DateTime? GuncellemeTarihi { get; set; }

    public virtual DuyuruFotograf Fotograf { get; set; } = null!;
}
