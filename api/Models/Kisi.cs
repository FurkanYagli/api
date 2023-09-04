using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models;
[Table("Kisiler")]

public partial class Kisi
{
    public int Id { get; set; }

    public bool Aktif { get; set; }

    public string? Tc { get; set; }

    public string? Tel { get; set; }

    public string? Ad { get; set; }

    public string? Soyad { get; set; }

    public string? Mail { get; set; }

    public DateTime? KayitTarihi { get; set; }

    public DateTime? GuncellemeTarihi { get; set; }

    public virtual ICollection<Aktiflik> Aktifliks { get; set; } = new List<Aktiflik>();

    public virtual ICollection<Kullanici> Kullanicis { get; set; } = new List<Kullanici>();

    public virtual ICollection<Sms> Sms { get; set; } = new List<Sms>();
}
