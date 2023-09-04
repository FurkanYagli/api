using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models;
[Table("Kullanicilar")]

public partial class Kullanici
{
    public int Id { get; set; }

    public bool Aktif { get; set; }

    public int KisiId { get; set; }

    public DateTime? KayitTarihi { get; set; }

    public DateTime? GuncellemeTarihi { get; set; }

    public string? KullaniciAdi { get; set; }

    public string? KullaniciSifre { get; set; }

    public virtual ICollection<Bildiri> Bildirises { get; set; } = new List<Bildiri>();

    public virtual ICollection<Hareket> Harekets { get; set; } = new List<Hareket>();

    public virtual Kisi Kisi { get; set; } = null!;
}
