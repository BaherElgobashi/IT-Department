using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT.DAL.Entities
{
    public class DevicePropertyValue
    {
        public int Id { get; set; }

        public string DeviceId { get; set; }
        public virtual Device Device { get; set; }

        public int PropertyItemId { get; set; }
        public virtual PropertyItem PropertyItem { get; set; }

        public string Value { get; set; }
    }
}
