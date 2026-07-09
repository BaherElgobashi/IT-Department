using IT.BLL.ViewModels;
using IT.DAL.Entities;
using IT.DAL.Repositories.Interfaces;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace IT_Department.Controllers
{
    public class PropertyItemController : Controller
    {
        private readonly IPropertyItemRepository _propertyItemRepository;

        public PropertyItemController(IPropertyItemRepository propertyItemRepository)
        {
            _propertyItemRepository = propertyItemRepository;
        }
        #region Get.
        public async Task<IActionResult> Index()
        {
            var properties = await _propertyItemRepository.GetAllPropertyItemAsync();
            return View(properties);
        }
        #endregion

        #region Create.
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View(new PropertyItemViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(PropertyItemViewModel model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }   

            var item = new PropertyItem
            {
                Description = model.Description,
                
            };

            await _propertyItemRepository.Add(item);
            return RedirectToAction(nameof(Index));
        }



        #endregion


        #region Edit.


        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var property = await _propertyItemRepository.GetPropertyItemAsync(id);

            if(property is null)
            {
                return NotFound();
            }

            

            return View(
                new PropertyItem
                {
                    Id = property.Id,
                    Description = property.Description

                }
                
       
                );

        }

        [HttpPost]
        public async Task<IActionResult> Edit(PropertyItem item)
        {
            if(!ModelState.IsValid)
            {
                return View(item);
            }

            await _propertyItemRepository.Update(item);

            return RedirectToAction(nameof(Index));
        }




        #endregion

        #region Delete.

        [HttpGet]

        public async Task<IActionResult> Delete(int id)
        {
            var item = await _propertyItemRepository.GetPropertyItemAsync(id);

            if(item is null)
            {
                return NotFound();
            }

            return View(item);
        }

        [HttpPost , ActionName("Delete")]

        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _propertyItemRepository.Delete(id);
            return RedirectToAction(nameof(Index));
        }






        #endregion


    }
}
