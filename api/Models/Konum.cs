using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models;
[Table("Konumlar")]

public partial class Konum
{
    public int Id { get; set; }

    public string? X { get; set; }

    public string? Y { get; set; }

    public DateTime? KayitTarihi { get; set; }

    public DateTime? GuncellemeTarihi { get; set; }

    public virtual ICollection<Bildiri> Bildirises { get; set; } = new List<Bildiri>();
}
