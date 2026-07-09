using IT.BLL.ViewModels;
using IT.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT.BLL.Services.Interaces
{
    public interface IDeviceService
    {
        Task<IEnumerable<Device>> GetAllDevicesAsync();
        Task<DeviceViewModel> GetDeviceByIdAsync(string id);
        Task AddAsync(DeviceViewModel model);
        Task updateAsync(DeviceViewModel model);
        Task DeleteAsync(string id);
        Task<IEnumerable<PropertyItem>> GetPropertiesByCategoryIdAsync(int categoryId);
        Task<IEnumerable<DeviceCategory>> GetCategories();

    }
}
