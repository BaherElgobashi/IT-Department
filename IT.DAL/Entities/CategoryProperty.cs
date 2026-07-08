using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT.DAL.Entities
{
    public class CategoryProperty
    {
        public int DeviceCategoryId { get; set; }
        public virtual DeviceCategory DeviceCategory { get; set; }
        public int PropertyItemId { get; set; }
        public virtual PropertyItem PropertyItem { get; set; }
    }
}
