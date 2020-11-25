using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pryanichek_version_1000.Models
{
    public class Person
    {
        public int StaffNo { get; set; }
        public string Name { get; set; }
        public string TelNo { get; set; }
        public string DateOfBirth { get; set; }
        public decimal Salary { get; set; }
        public string Characteristic { get; set; }
        [Required]
        public string IsFired { get; set; }
        public int StaffBakeryNo { get; set; }
        public int PositionNo { get; set; }
        public string FiredCharacteristic { get; set; }
        public string Sex { get; set; }
        public string PositionName { get; set; }
    }
}
