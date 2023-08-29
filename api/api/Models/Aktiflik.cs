using System;
using System.Collections.Generic;

namespace api.Models;

public partial class Aktiflik
{
    public int Id { get; set; }

    public int PasifTuru { get; set; }

    public int KisiId { get; set; }

    public DateTime BitisTarihi { get; set; }

    public bool Aktif { get; set; }

    public DateTime? KayitTarihi { get; set; }

    public DateTime? GuncellemeTarihi { get; set; }

    public virtual Kisi Kisi { get; set; } = null!;

    public virtual SilinmeTurleri PasifTuruNavigation { get; set; } = null!;
}
