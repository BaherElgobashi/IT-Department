using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT.DAL.Entities
{
    public class Device
    {
        public string Id { get; set; } = default!;
        public string DeviceName { get; set; } = default!; // Show the Name of the code only not the relation.
        public string DeviceCategory { get; set; } = default!;
        public DateTime AcquisitionDate { get; set; }
        public string? Memo { get; set; }

    }
}
