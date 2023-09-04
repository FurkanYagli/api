using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models;
[Table("Hareketler")]

public partial class Hareket
{
    public int Id { get; set; }

    public int KullaniciId { get; set; }

    public int? SayfaId { get; set; }

    public int? IslemId { get; set; }

    public DateTime? KayitTarihi { get; set; }

    public DateTime? GuncellemeTarihi { get; set; }

    public virtual Islem? Islem { get; set; }

    public virtual Kullanici Kullanici { get; set; } = null!;

    public virtual Sayfa? Sayfa { get; set; }
}
