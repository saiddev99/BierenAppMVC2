using System;
using System.Collections.Generic;

namespace Bieren.Models;

public partial class Brouwer
{
    public int Id { get; set; }

    public string BrNaam { get; set; } = null!;

    public string Adres { get; set; } = null!;

    public short PostCode { get; set; }

    public string Gemeente { get; set; } = null!;

    public int? Omzet { get; set; }

    public virtual ICollection<Bier> Bieren { get; set; } = new List<Bier>();
}
