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
    public class DevicePropertyValueRepository : IDevicePropertyValueRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public DevicePropertyValueRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task AddRangeAsync(List<DevicePropertyValue> values)
        {
            await _dbContext.DevicePropertyValues.AddRangeAsync(values);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteByDeviceIdAsync(string deviceId)
        {
            var ValuesToDelete = _dbContext.DevicePropertyValues.Where(D => D.DeviceId == deviceId);

            _dbContext.DevicePropertyValues.RemoveRange(ValuesToDelete);

            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<DevicePropertyValue>> GetByDeviceIdAsync(string deviceId)
        {
            var DevicePropertyValues = await _dbContext.DevicePropertyValues
                                                 .Where(D => D.DeviceId == deviceId)
                                                 .Include(D => D.PropertyItem)
                                                 .ToListAsync();

            return DevicePropertyValues;
        }
    }
}
