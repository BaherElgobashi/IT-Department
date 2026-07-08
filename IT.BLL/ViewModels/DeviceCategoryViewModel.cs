using IT.DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT.BLL.ViewModels
{
    public class DeviceCategoryViewModel
    {
        [Required(ErrorMessage = "Category name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "You must select at least one property")]
        public List<int> SelectedPropertyIds { get; set; } = new();

        public List<PropertyItem> AllProperties { get; set; } = new();
    }
}
