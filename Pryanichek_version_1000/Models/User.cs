﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pryanichek_version_1000.Models
{
    public class User
    {
        [Required(ErrorMessage = "Это поле является обязательным")]
        [MaxLength(10)]
        public string Login { get; set; }

        [Required(ErrorMessage = "Это поле является обязательным")]
        [MaxLength(10)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        //[Compare("Password", ErrorMessage = "! Пароли не совпадают !")]
        //[DataType(DataType.Password)]
        //public string PasswordConfirm { get; set; }


        [Required(ErrorMessage = "Это поле является обязательным")]
        [MaxLength(50)]
        public string RoleName { get; set; }

        [Required(ErrorMessage = "Это поле является обязательным")]
        [MaxLength(15)]   
        [RegularExpression(@"^0[356789]{2}[-]{1}[0-9]{3}[-]{1}[0-9]{2}[-]{1}[0-9]{2}$", ErrorMessage = "* Некорректный номер телефона")]
        public string TelNo { get; set; }

        [Required(ErrorMessage = "Это поле является обязательным")]
        [MaxLength(20, ErrorMessage = "* Длина имени не более 20 символов")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Это поле является обязательным")]

        [MaxLength(20,ErrorMessage ="* Длина фамилии не более 20 символов")]
        public string LastName { get; set; } 

    }
}
