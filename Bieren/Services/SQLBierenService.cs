using Bieren.Models;

namespace Bieren.Services;

public class SQLBierenService: IBierenService
{
    private readonly MVCBierenContext _context;
    public SQLBierenService(MVCBierenContext context)
    {
        _context = context;
    }

    public List<Bier> FindAll()
    {
        return _context.Bieren.ToList();
    }

    public Bier Read(int id)
    {
        return _context.Bieren.Find(id);
    }

    public void Delete(int id)
    {
        _context.Bieren.Remove(Read(id));
        _context.SaveChanges();
    }

    public void IncreasePrice(decimal percent)
    {
        foreach (var item in _context.Bieren)
        {
            item.Prijs += item.Prijs * (percent / 100M);
            _context.SaveChanges();
        }
    }

    public List<Bier> SearchByAlcohol(float alcMin, float alcMax)
    {
        return (from b in _context.Bieren
                where alcMin <= b.Alcohol && alcMax >= b.Alcohol
                orderby b.Alcohol
                select b).ToList();
    }

    public void Add(Bier bier)
    {
        _context.Bieren.Add(bier);
        _context.SaveChanges();
    }
}
