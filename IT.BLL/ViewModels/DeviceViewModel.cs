using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT.BLL.ViewModels
{
    public class DeviceViewModel
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        public string Name { get; set; }

        [Required]
        public DateTime AcquisitionDate { get; set; }

        public string Memo { get; set; }

        [Required]
        public int DeviceCategoryId { get; set; }

        // Update.
        public Dictionary<int, string> PropertyValues { get; set; } = new();

        // Read.
        public Dictionary<string, string> DisplayPropertyValues { get; set; } = new();
    }
}
