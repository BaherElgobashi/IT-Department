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
    public class PropertyItemRepository : IPropertyItemRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public PropertyItemRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<PropertyItem>> GetAllPropertyItemAsync()
        {
            var Items = await _dbContext.PropertyItems
                                        .Include(x => x.DevicePropertyValues)
                                        .ToListAsync();
            return Items;
        }

        public async Task<PropertyItem> GetPropertyItemAsync(int id)
        {
            var Item = await _dbContext.PropertyItems
                                 .Include(x => x.DevicePropertyValues)
                                 .FirstOrDefaultAsync(x => x.Id == id);
            return Item;
        }
        public async Task Update(PropertyItem item)
        {
            _dbContext.PropertyItems.Update(item);
            await _dbContext.SaveChangesAsync();
        }
        public async Task Add(PropertyItem item)
        {
            await _dbContext.PropertyItems.AddAsync(item);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var item = await GetPropertyItemAsync(id);
            if(item is not null)
            {
                _dbContext.PropertyItems.Remove(item);
                await _dbContext.SaveChangesAsync();
            }
        }

        

        
    }
}
