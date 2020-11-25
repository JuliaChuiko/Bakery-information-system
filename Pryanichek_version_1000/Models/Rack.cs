using System;
using System.Collections.Generic;

namespace Pryanichek_version_1000.Models
{
    public partial class Rack
    {
        public int RackNo { get; set; }
        public int RackInBakeryNo { get; set; }
        public int SortRack { get; set; }
        public int CountProducts { get; set; }
        public int RackBakeryNo { get; set; }

        public virtual Bakery RackBakeryNoNavigation { get; set; }
        public virtual Sort SortRackNavigation { get; set; }
    }
}
