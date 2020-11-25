using System;
using System.Collections.Generic;

namespace Pryanichek_version_1000.Models
{
    public partial class Position
    {
        public Position()
        {
            Staff = new HashSet<Staff>();
        }

        public int PositionNo { get; set; }
        public string PositionName { get; set; }

        public virtual ICollection<Staff> Staff { get; set; }
    }
}
