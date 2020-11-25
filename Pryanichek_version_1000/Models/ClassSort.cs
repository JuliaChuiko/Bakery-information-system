using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pryanichek_version_1000.Models
{
    public class ClassSort
    {
        [Required(ErrorMessage ="* Это поле обязательное для сортировки")]
        public string NameSort { get; set; }
    }
}
