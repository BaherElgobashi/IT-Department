using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT.DAL.Entities
{
    public class DeviceCategory
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;

        public ICollection<Device> Devices { get; set; }

    }
}
