using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pryanichek_version_1000.Models
{
    public class NewProduct
    {
        public int ProductNo { get; set; }
        public string ProductName { get; set; }
        public string SortName { get; set; }
        [Required(ErrorMessage="* Это поле является обязательным")]
        [Range(20,4320,ErrorMessage = "* Время приготовления не менее 20 минут и не более 3-х дней")]
        public int PreparingTime { get; set; }
        public string Recipe { get; set; }
    }
}
