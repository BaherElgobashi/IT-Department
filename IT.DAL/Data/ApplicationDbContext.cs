using IT.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT.DAL.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options)
        {
            
        }

        public DbSet<Device> Devices { get; set; }
        public DbSet<CategoryProperty> CategoryProperties { get; set; }
        public DbSet<DeviceCategory> DeviceCategories { get; set; }
        public DbSet<DevicePropertyValue> DevicePropertyValues { get; set; }
        public DbSet<PropertyItem> PropertyItems { get; set; }
    }
}
