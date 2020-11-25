using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pryanichek_version_1000.Models
{
    public class ClasssReceipt
    {
        [Required(ErrorMessage = "* Это поле является обязательным")]
        public string Date { get; set; }
       

    }
}
