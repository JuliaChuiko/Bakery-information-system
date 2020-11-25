using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pryanichek_version_1000.Models
{
    public class Loginn
    {

        [Required(ErrorMessage = "* Это поле является обязательным")]
        [MaxLength(12, ErrorMessage = "* Длина логина не более 10 символов")]
        public string Login { get; set; }

        [Required(ErrorMessage = "* Это поле является обязательным")]
        [MaxLength(10, ErrorMessage ="* Длина пароля не более 10 символов")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }

        
    }
