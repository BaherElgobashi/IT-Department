using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT.DAL.Entities
{
    public class PropertyItem
    {
        public int Id { get; set; }
        public string Description { get; set; } = default!;
        public virtual ICollection<CategoryProperty> CategoryProperties { get; set; }

       
        public virtual ICollection<DevicePropertyValue> DevicePropertyValues { get; set; }

    }
}
