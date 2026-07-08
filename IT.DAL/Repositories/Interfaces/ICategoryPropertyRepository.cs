using IT.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT.DAL.Repositories.Interfaces
{
    public interface ICategoryPropertyRepository
    {
        Task<List<CategoryProperty>> GetAllAsync();
        Task<List<PropertyItem>> GetPropertiesByCategoryIdAsync(int categoryId);
        Task AddAsync(CategoryProperty categoryProperty);
        Task DeleteAsync(int categoryId, int propertyItemId);
    }
}
