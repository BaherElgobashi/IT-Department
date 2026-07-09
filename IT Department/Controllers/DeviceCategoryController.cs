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
    }
}
