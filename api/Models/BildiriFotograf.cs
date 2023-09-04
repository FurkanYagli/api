using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models;
[Table("BildiriFotograflar")]

public partial class BildiriFotograf
{
    public int Id { get; set; }

    public string? Image { get; set; }

    public DateTime? KayitTarihi { get; set; }

    public DateTime? GuncellemeTarihi { get; set; }

    public virtual ICollection<Bildiri> Bildirises { get; set; } = new List<Bildiri>();
}
