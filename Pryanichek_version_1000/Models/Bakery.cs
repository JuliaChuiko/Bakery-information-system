using System;
using System.Collections.Generic;

namespace Pryanichek_version_1000.Models
{
    public partial class Bakery
    {
        public Bakery()
        {
            Rack = new HashSet<Rack>();
            Staff = new HashSet<Staff>();
        }

        public int BakeryNo { get; set; }
        public string TelNo { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public string BakeryName { get; set; }

        public virtual ICollection<Rack> Rack { get; set; }
        public virtual ICollection<Staff> Staff { get; set; }
    }
}
