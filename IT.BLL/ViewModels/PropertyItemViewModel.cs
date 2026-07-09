using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT.BLL.ViewModels
{
    public class PropertyItemViewModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
