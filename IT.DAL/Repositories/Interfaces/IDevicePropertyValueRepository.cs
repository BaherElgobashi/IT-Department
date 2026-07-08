using IT.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT.DAL.Repositories.Interfaces
{
    public interface IDevicePropertyValueRepository
    {
        Task<List<DevicePropertyValue>> GetByDeviceIdAsync(string deviceId);
        Task AddRangeAsync(List<DevicePropertyValue> values);
        Task DeleteByDeviceIdAsync(string deviceId);
    }
}
