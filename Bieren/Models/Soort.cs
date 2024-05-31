using System;
using System.Collections.Generic;

namespace Bieren.Models;

public partial class Soort
{
    public int Id { get; set; }

    public string Naam { get; set; } = null!;

    public virtual ICollection<Bier> Bieren { get; set; } = new List<Bier>();
}
