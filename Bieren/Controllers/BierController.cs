using Bieren.Models;
using Bieren.Services;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Bieren.Controllers
{
    public class BierController : Controller
    {
        private IBierenService _bierService;

        public BierController(IBierenService bierService)
        {
            _bierService = bierService;
        }

        public IActionResult Index()
        {
            var gewist = (string?)TempData["gewist"];
            if (gewist != null)
            {
                ViewBag.Gewist = JsonSerializer.Deserialize<Bier>(gewist);
            }
            return View(_bierService.FindAll());
        }

        public IActionResult Delete(int id)
        {
            Bier? bier = _bierService.Read((id));
            if (bier == null)
            {
                return RedirectToAction("Index");
            }
            TempData["gewist"] = JsonSerializer.Serialize(bier);
            _bierService.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult IncreasePrice(int percent)
        {
            _bierService.IncreasePrice(percent);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Search()
        {
            BierSearchViewModel model = new BierSearchViewModel();
            return View(model);
        }
        [HttpGet]
        public IActionResult Result(BierSearchViewModel model)
        {
            model.Result = _bierService.SearchByAlcohol(model.AlcMin, model.AlcMax);
            return View("Search", model);
        }

        [HttpGet]
        public IActionResult Add()
        {
            Bier bier = new Bier();
            return View(bier);
        }

        [HttpPost]
        public IActionResult Add(Bier bier)
        {
            if (ModelState.IsValid)
            {
                _bierService.Add(bier);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(bier);

            }
        }
    }
}
