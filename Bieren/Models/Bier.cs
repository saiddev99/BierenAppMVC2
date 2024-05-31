using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Bieren.Models;

public partial class Bier
{
    [DisplayFormat(DataFormatString = "{0:00#}")]
    public int Id { get; set; }

    [Required]
    [StringLength(100, ErrorMessage = "{0} moet max. {1} characters bevatten.")]
    public string Naam { get; set; } = null!;

    public int BrouwerId { get; set; }

    public int SoortId { get; set; }

    [Required]
    [UIHint("AlcKleuren")]
    [Range(0, 15, ErrorMessage = "Percentage moet min. {1} en max. {2} zijn.")]
    public float? Alcohol { get; set; }

    [DisplayFormat(DataFormatString = "{0:(€#,##0.00)}")]
    public decimal? Prijs { get; set; }

    public virtual Brouwer Brouwer { get; set; } = null!;

    public virtual Soort Soort { get; set; } = null!;
}
