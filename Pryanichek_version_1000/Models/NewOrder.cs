using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pryanichek_version_1000.Models
{
    public class NewOrder
    {
        [Required(ErrorMessage = "* Это поле является обязательным")]
        public string FromPerson { get; set; } //пекарь
        [Required(ErrorMessage = "* Это поле является обязательным")]
        public string ToPerson { get; set; }

        [Required(ErrorMessage = "* Это поле является обязательным")]
        public string Cashier { get; set; }

        [Required(ErrorMessage = "* Это поле является обязательным")]
         public string ProductNameWithCount { get; set; }
        [Required(ErrorMessage = "* Это поле является обязательным")]
        public string OrderNo { get; set; }
        [Required(ErrorMessage = "* Это поле является обязательным")]
        public double Sum { get; set; }
        [Required(ErrorMessage = "* Это поле является обязательным")]
        public string StartDate { get; set; }
        [Required(ErrorMessage = "* Это поле является обязательным")]
        public string EndDate { get; set;}
        [Required(ErrorMessage = "* Это поле является обязательным")]
        public string Status { get; set; }
    }
}
