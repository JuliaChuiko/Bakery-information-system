using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pryanichek_version_1000.Models
{
    public class TakeReceipt
    {
        [Required(ErrorMessage = "* Это поле является обязательным")]
        public string FromPerson { get; set; }
        [Required(ErrorMessage = "* Это поле является обязательным")]
        public string ToPerson { get; set; }
        [Required(ErrorMessage = "* Это поле является обязательным")]
        public string Date { get; set; }
        [Required(ErrorMessage = "* Это поле является обязательным")]
        public string ProductNameWithCount { get; set; }
        [Required(ErrorMessage = "* Это поле является обязательным")]
        public string ReceiptNo{ get; set; }
        [Required(ErrorMessage = "* Это поле является обязательным")]
        public string AmountOfDiscount { get; set; }
        [Required(ErrorMessage = "* Это поле является обязательным")]
        public double Sum { get; set; }
        [Required(ErrorMessage = "* Это поле является обязательным")]
        public double SumWithDiscount { get; set; }
        

    }
}
