using IT.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT.DAL.Repositories.Interfaces
{
    public interface IDeviceCategoryRepository
    {
        Task<IEnumerable<DeviceCategory>> GetDeviceCategoriesAsync();

        Task<DeviceCategory> GetDeviceCategotyById(int id);
        Task Add(DeviceCategory deviceCategory);
        void Update(DeviceCategory deviceCategory);
        Task Delete(DeviceCategory deviceCategory);
    }
}
