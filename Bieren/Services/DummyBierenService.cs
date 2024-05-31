using Bieren.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Bieren.Services;

public class DummyBierenService: IBierenService
{
    List<Bier> bieren = new()
            {
                new Bier {Id=1 ,Naam = "Romy pils", Alcohol=5F, Prijs = 1.00M},
                new Bier {Id=2 ,Naam = "Kasteelbier", Alcohol=12F, Prijs = 1.50M},
                new Bier {Id=3 ,Naam = "Maes radler", Alcohol=0.75F, Prijs = 2.00M},
                new Bier {Id=4 ,Naam = "Maes upgrade", Alcohol=8F, Prijs = 4.75M}
            };

    public List<Bier> FindAll()
    {
        return bieren;
    }

    public Bier Read(int id)
    {
        return bieren.SingleOrDefault(x => x.Id == id);
    }

    public void Delete(int id)
    {
        bieren.Remove(Read(id));
    }

    public void IncreasePrice(decimal percent)
    {
        foreach (var item in bieren)
        {
            item.Prijs += item.Prijs * (percent / 100M);
        }
    }

    public List<Bier> SearchByAlcohol(float alcMin, float alcMax)
    {
        return (from b in bieren
               where alcMin <= b.Alcohol && alcMax >= b.Alcohol
               select b).ToList();
    }

    public void Add(Bier bier)
    {
        bier.Id = bieren.Max(x => x.Id) + 1;
        bieren.Add(bier);
    }
}
