using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewComponents;

namespace Bieren.ViewComponents;

public class FooterAdder:ViewComponent
{
    public IViewComponentResult Invoke(string footerTekst)
    {
        return View((object)footerTekst);
    }
}
