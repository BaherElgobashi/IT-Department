using IT.BLL.Services.Interaces;
using IT.BLL.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace IT_Department.Controllers
{
    public class DeviceController : Controller
    {
        private readonly IDeviceService _deviceService;

        public DeviceController(IDeviceService deviceService)
        {
            _deviceService = deviceService;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var devices = await _deviceService.GetAllDevicesAsync(); 
            return View(devices);
        }

        [HttpGet]
        public async Task<IActionResult> GetPropertiesByCategoryId(int categoryId)
        {
            var props = await _deviceService.GetPropertiesByCategoryIdAsync(categoryId);
            var result = props.Select(p => new { p.Id, p.Description }).ToList();
            return Json(result);
        }

        #region Create.

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.Categories = await _deviceService.GetCategories();
            return View(new DeviceViewModel());
        }


        [HttpPost]
        public async Task<IActionResult> Create(DeviceViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Categories = await _deviceService.GetCategories();
                return View(model);
            }

            await _deviceService.AddAsync(model);
            return RedirectToAction(nameof(Index));
        }
        #endregion

        #region Edit.

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            var device = await _deviceService.GetDeviceByIdAsync(id);
            if (device is null) 
                return NotFound();

            ViewBag.Categories = await _deviceService.GetCategories();
            ViewBag.DeviceId = id;
            return View(device);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id, DeviceViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Categories = await _deviceService.GetCategories();
                ViewBag.DeviceId = id;
                return View(model);
            }

            await _deviceService.updateAsync(model);
            return RedirectToAction(nameof(Index));
        }



        #endregion

        public async Task<IActionResult> Details(string id)
        {
            var model = await _deviceService.GetDeviceByIdAsync(id);
            if (model is null) 
                return NotFound();

            return View(model);
        }


        #region Delete.
        public async Task<IActionResult> Delete(string id)
        {
            var device = await _deviceService.GetDeviceByIdAsync(id);
            if (device == null) return NotFound();

            return View(device);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            await _deviceService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        } 
        #endregion





    }
}
