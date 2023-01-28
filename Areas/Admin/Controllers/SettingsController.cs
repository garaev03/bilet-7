using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Studio.Business.Services.Interfaces;
using Studio.Entities.Concrets;

namespace Studio.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class SettingsController : Controller
    {
        private readonly ISettingService _service;

        public SettingsController(ISettingService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _service.Get());
        }
        public async Task<IActionResult> Update()
        => View(await _service.Get());
        [HttpPost]
        public async Task<IActionResult> Update(Setting NewSetting)
        {
            if (!ModelState.IsValid) return View(NewSetting);
            await  _service.Update(NewSetting);
            return RedirectToAction("Index");
        }
}
}
