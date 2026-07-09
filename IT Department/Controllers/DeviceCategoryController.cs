using IT.BLL.ViewModels;
using IT.DAL.Entities;
using IT.DAL.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace IT_Department.Controllers
{
    public class DeviceCategoryController : Controller
    {
        private readonly IDeviceCategoryRepository _deviceCategoryRepository;
        private readonly IPropertyItemRepository _propertyItemRepository;
        private readonly ICategoryPropertyRepository _categoryPropertyRepository;

        public DeviceCategoryController(IDeviceCategoryRepository deviceCategoryRepository ,
                                        IPropertyItemRepository propertyItemRepository ,
                                        ICategoryPropertyRepository categoryPropertyRepository)
        {
            _deviceCategoryRepository = deviceCategoryRepository;
            _propertyItemRepository = propertyItemRepository;
            _categoryPropertyRepository = categoryPropertyRepository;
        }
        #region Get.

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var categoris = await _deviceCategoryRepository.GetDeviceCategoriesAsync();
            return View(categoris);
        }
        #endregion

        #region Create.
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var viewModel = new DeviceCategoryViewModel
            {
                AllProperties = (await _propertyItemRepository.GetAllPropertyItemAsync()).ToList()
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(DeviceCategoryViewModel model)
        {
            model.AllProperties = (await _propertyItemRepository.GetAllPropertyItemAsync()).ToList();

            if (!ModelState.IsValid)
                return View(model);

            var category = new DeviceCategory { Name = model.Name };
            await _deviceCategoryRepository.Add(category);

            foreach (var propId in model.SelectedPropertyIds)
            {
                var cp = new CategoryProperty
                {
                    DeviceCategoryId = category.Id,
                    PropertyItemId = propId
                };
                await _categoryPropertyRepository.AddAsync(cp);
            }

            return RedirectToAction("Index");
        }



        #endregion


        #region Edit.

        [HttpGet]

        public async Task<IActionResult> Edit(int id)
        {
            var category = await _deviceCategoryRepository.GetDeviceCategotyById(id);
            if (category == null) return NotFound();

            var allProps = (await _propertyItemRepository.GetAllPropertyItemAsync()).ToList();
            var selectedProps = await _categoryPropertyRepository.GetPropertiesByCategoryIdAsync(id);

            var viewModel = new DeviceCategoryViewModel
            {
                Name = category.Name,
                AllProperties  = allProps,
                SelectedPropertyIds = selectedProps.Select(p => p.Id).ToList()
            };

            ViewBag.CategoryId = id;
            return View(viewModel);
        }


        #endregion

        #region Delete.

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var category = await _deviceCategoryRepository.GetDeviceCategotyById(id);
            if (category == null) return NotFound();

            return View(category);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _deviceCategoryRepository.Delete(id);
            return RedirectToAction(nameof(Index));
        }





        #endregion






    }
}
