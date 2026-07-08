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
    public class DeviceCategoryRepository : IDeviceCategoryRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public DeviceCategoryRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Add(DeviceCategory deviceCategory)
        {
            await _dbContext.DeviceCategories.AddAsync(deviceCategory);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var deviceCategory = await GetDeviceCategotyById(id);
            if (deviceCategory != null)
            {
                _dbContext.DeviceCategories.Remove(deviceCategory);
                await _dbContext.SaveChangesAsync();

            }
        }

        public async Task<IEnumerable<DeviceCategory>> GetDeviceCategoriesAsync()
        {
            var DeviceCategories = await _dbContext.DeviceCategories
                .Include(DC =>DC.CategoryProperties)
                .ThenInclude(DC => DC.PropertyItem)
                .ToListAsync();
            
            return DeviceCategories;
        }

        public Task<DeviceCategory> GetDeviceCategotyById(int id)
        {
            var DeviceCategory = _dbContext.DeviceCategories
                                           .Include( DC =>DC.CategoryProperties)
                                           .ThenInclude(DC => DC.PropertyItem)
                                           .FirstOrDefaultAsync(DC => DC.Id == id);

            return DeviceCategory;
        }

        public async Task Update(DeviceCategory deviceCategory)
        {
             _dbContext.DeviceCategories.Update(deviceCategory);
            await _dbContext.SaveChangesAsync();
        }
    }
}
