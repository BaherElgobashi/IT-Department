using IT.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT.DAL.Repositories.Interfaces
{
    public interface IDeviceRepository
    {
        Task<IEnumerable<Device>> GetDevicesAsync();
        Task<Device?> GetDeviceById(string id);

        Task addDevice(Device device);
        Task updateDevice(Device device);
        Task deleteDevice(string id);
    }
}
