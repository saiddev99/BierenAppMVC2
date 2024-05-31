using Bieren.Models;

namespace Bieren.Services;

public interface IBierenService
{
    List<Bier> FindAll();
    Bier Read(int id);
    void Delete(int id);
    void Add (Bier bier);
    void IncreasePrice(decimal percent);
    List<Bier> SearchByAlcohol(float alcMin, float alcMax);



}
