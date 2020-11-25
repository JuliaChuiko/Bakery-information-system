using System;
using System.Collections.Generic;

namespace Pryanichek_version_1000.Models
{
    public partial class Staff
    {
        public Staff()
        {
            Details = new HashSet<Details>();
            Order = new HashSet<Order>();
            Receipt = new HashSet<Receipt>();
        }

        public int StaffNo { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string TelNo { get; set; }
        public DateTime DateOfBirth { get; set; }
        public decimal Salary { get; set; }
        public string Characteristic { get; set; }
        public bool IsFired { get; set; }
        public int StaffBakeryNo { get; set; }
        public int PositionNo { get; set; }
        public string FiredCharacteristic { get; set; }

        public virtual Position PositionNoNavigation { get; set; }
        public virtual Bakery StaffBakeryNoNavigation { get; set; }
        public virtual ICollection<Details> Details { get; set; }
        public virtual ICollection<Order> Order { get; set; }
        public virtual ICollection<Receipt> Receipt { get; set; }
    }
}
