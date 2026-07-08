using IT.DAL.Data;
using IT.DAL.Entities;
using IT.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT.DAL.Repositories.Classes
{
    public class DeviceRepository : IDeviceRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public DeviceRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Device?> GetDeviceById(string id)
        {
            var Device = await _dbContext.Devices.FindAsync(id);
            if (Device is null)
                return null;
            return Device;
        }

        public async Task<IEnumerable<Device>> GetDevicesAsync()
        {
            var Devices = await _dbContext.Devices.ToListAsync();
            return Devices;
        }
        public async Task addDevice(Device device)
        {
            await _dbContext.Devices.AddAsync(device);
            await _dbContext.SaveChangesAsync();
        }

        

        

        public void  updateDevice(Device device)
        {
             _dbContext.Devices.Update(device);
             _dbContext.SaveChanges();
        }

        public async Task deleteDevice(string id)
        {
            var device = await GetDeviceById(id);
            if (device is not null)
            {
                _dbContext.Devices.Remove(device);
                await _dbContext.SaveChangesAsync();
            }
                
             

        }
    }
}
