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
    public class CategoryPropertyRepository : ICategoryPropertyRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public CategoryPropertyRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task AddAsync(CategoryProperty categoryProperty)
        {
            _dbContext.CategoryProperties.Add(categoryProperty);

            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int categoryId, int propertyItemId)
        {
            var item = await _dbContext.CategoryProperties
            .FirstOrDefaultAsync(cp => cp.DeviceCategoryId == categoryId && cp.PropertyItemId == propertyItemId);

            if (item != null)
            {
                _dbContext.CategoryProperties.Remove(item);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<CategoryProperty>> GetAllAsync()
        {
            var CategoriesProperties = await _dbContext.CategoryProperties
                                                 .Include(cp => cp.DeviceCategory)
                                                 .Include(cp => cp.PropertyItem)
                                                 .ToListAsync();
            return CategoriesProperties;
        }

        public async Task<IEnumerable<PropertyItem>> GetPropertiesByCategoryIdAsync(int categoryId)
        {
            var CategoryProperty = await _dbContext.CategoryProperties
                                             .Where(cp => cp.DeviceCategoryId == categoryId)
                                             .Select(cp => cp.PropertyItem)
                                             .ToListAsync();

            return CategoryProperty;
        }
    }
}
