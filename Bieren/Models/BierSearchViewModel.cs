using System.ComponentModel.DataAnnotations;

namespace Bieren.Models;
public class BierSearchViewModel
{
    [Display(Name = "Alcohol % min.")]
    public float AlcMin { get; set; }

    [Display(Name = "Alcohol % max.")]
    public float AlcMax { get; set; }
    public List<Bier> Result { get; set; } = new();
}
