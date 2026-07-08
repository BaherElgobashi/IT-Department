using IT.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT.DAL.Configurations
{
    internal class CategoryPropertyConfiguration : IEntityTypeConfiguration<CategoryProperty>
    {
        public void Configure(EntityTypeBuilder<CategoryProperty> builder)
        {
            builder.HasKey(cp => new { cp.DeviceCategoryId, cp.PropertyItemId });
        }
    }
}
