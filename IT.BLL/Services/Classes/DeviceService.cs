using IT.BLL.Services.Interaces;
using IT.BLL.ViewModels;
using IT.DAL.Entities;
using IT.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace IT.BLL.Services.Classes
{
    public class DeviceService : IDeviceService
    {
        private readonly IDeviceRepository _deviceRepository;
        private readonly IDeviceCategoryRepository _deviceCategoryRepository;
        private readonly ICategoryPropertyRepository _categoryPropertyRepository;
        private readonly IDevicePropertyValueRepository _devicePropertyValueRepository;

        public DeviceService(IDeviceRepository deviceRepository ,
                             IDeviceCategoryRepository deviceCategoryRepository ,
                             ICategoryPropertyRepository categoryPropertyRepository , 
                             IDevicePropertyValueRepository devicePropertyValueRepository)
        {
            _deviceRepository = deviceRepository;
            _deviceCategoryRepository = deviceCategoryRepository;
            _categoryPropertyRepository = categoryPropertyRepository;
            _devicePropertyValueRepository = devicePropertyValueRepository;
        }
        public async Task<IEnumerable<Device>> GetAllDevicesAsync()
        {
            var Devices = await _deviceRepository.GetDevicesAsync();

            return Devices;
        }

        public async Task<IEnumerable<DeviceCategory>> GetCategories()
        {
            var categories = await _deviceCategoryRepository.GetDeviceCategoriesAsync();
            return categories;  
        }
        public async Task AddAsync(DeviceViewModel model)
        {
            var device = new Device()
            {
                Id = model.Id,
                DeviceName = model.Name,
                AcquisitionDate = model.AcquisitionDate,
                Memo = model.Memo,
                DeviceCategoryId = model.DeviceCategoryId
            };
            await _deviceRepository.addDevice(device);

            var values = model.PropertyValues.Select((KeyValuePair<int, string> pv) => new DevicePropertyValue
            {
                DeviceId = device.Id,
                PropertyItemId = pv.Key,
                Value = pv.Value
            }).ToList();

            await _devicePropertyValueRepository.AddRangeAsync(values);
        }

        public async Task DeleteAsync(string id)
        {
            await _devicePropertyValueRepository.DeleteByDeviceIdAsync(id);
            await _deviceRepository.deleteDevice(id);
        }

        

        public async Task<DeviceViewModel> GetDeviceByIdAsync(string id)
        {
            var device = await _deviceRepository.GetDeviceById(id);
            if(device == null)
            {
                return null!;
            }

            var propertyValues = await _devicePropertyValueRepository.GetByDeviceIdAsync(id);

            return new DeviceViewModel
            {
                Id = device.Id,
                Name = device.DeviceName,
                AcquisitionDate = device.AcquisitionDate,
                Memo = device.Memo,
                DeviceCategoryId = device.DeviceCategoryId,
                PropertyValues = propertyValues.ToDictionary(
                    pv => pv.PropertyItemId,
                    pv => pv.Value),

                DisplayPropertyValues = propertyValues.ToDictionary(
                    pv => pv.PropertyItem.Description,
                    pv => pv.Value)
            };
        }

        public async Task<IEnumerable<PropertyItem>> GetPropertiesByCategoryIdAsync(int categoryId)
        {
            var CategoryProperties = await _categoryPropertyRepository.GetPropertiesByCategoryIdAsync(categoryId);  
            return CategoryProperties;
        }

        public async Task updateAsync(DeviceViewModel model)
        {
            var device = await _deviceRepository.GetDeviceById(model.Id);
            if (device == null) return;

            device.DeviceName = model.Name;
            device.AcquisitionDate = model.AcquisitionDate;
            device.Memo = model.Memo;
            device.DeviceCategoryId = model.DeviceCategoryId;

            await _deviceRepository.updateDevice(device);

            await _deviceRepository.deleteDevice(model.Id);

            var newValues = model.PropertyValues.Select(pv => new DevicePropertyValue
            {
                DeviceId = model.Id,
                PropertyItemId = pv.Key,
                Value = pv.Value
            }).ToList();

            await _devicePropertyValueRepository.AddRangeAsync(newValues);
        }
    }
}
