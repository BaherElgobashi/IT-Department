using IT.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT.DAL.Repositories.Interfaces
{
    public interface IPropertyItemRepository
    {
        Task<IEnumerable<PropertyItem>> GetAllPropertyItemAsync();
        Task<PropertyItem> GetPropertyItemAsync(int id);
        Task Add(PropertyItem item);
        Task Update (PropertyItem item);
        Task Delete(int id);
    }
}
