using Microsoft.AspNetCore.Mvc;
using SportZone.Service.Data;
using SportZone.Service.Core;
using SportZone.Service.Models;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace SportZone.Controllers
{
    public class SportController : ControllerBase
    {
        private readonly SportService _sporService;

        public SportController(SportService sporService)
        {
            _sporService = sporService;
        }
     
        public IActionResult Index()
        {
            var models = _sporService.GetAll();
            return View(models);
        }
        public IActionResult Create()
        {
            var viewModel = _sporService.GetCreateViewModel();
            return View(viewModel);
        }
        public IActionResult Edit(int Id)
        {
            var model = _sporService.GetEditViewModel(Id);

            return View(model);
        }
        public IActionResult Save(SportDTO viewmodel)
        {
            if (ModelState.IsValid)
            {
                _sporService.Save(viewmodel);
                TempData["succes"] = "Bilgiler Kaydedildi";
                return RedirectToAction("Index");
            }
            TempData["error"] = "Bilgiler Kaydedilmedi";

            return View("Create", viewmodel);
        }
        public IActionResult Delete(int Id)
        {
            try
            {
                _sporService.Delete(Id);

            }
            catch (Exception ex)
            {
                TempData["error"] = "Bir Hata ile Karşılaşıldı";
                return RedirectToAction("Index");

            }
            TempData["succes"] = "Kayıt Silindi";
            return RedirectToAction("Index");

        }
    }
}

