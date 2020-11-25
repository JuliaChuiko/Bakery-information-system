using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pryanichek_version_1000.Models
{
    public class ClassPeriodReceipt
    {
        [Required(ErrorMessage ="* Это поле является обязательным")]
        public string StartDate { get; set; }
        [Required(ErrorMessage = "* Это поле является обязательным")]
        public string EndDate { get; set; }
    }
}
