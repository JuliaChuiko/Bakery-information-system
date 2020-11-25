using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pryanichek_version_1000.Models
{
    public class CreateCheck
    {
      

        [Required(ErrorMessage = "* Это поле является обязательным")]
        public string TheDate {get;set;}

        [Required(ErrorMessage = "* Это поле является обязательным")]
        public List<string> products { get; set; }

        [Required(ErrorMessage = "* Это поле является обязательным")]
        public List<int> count { get; set; }
 
    }
}
