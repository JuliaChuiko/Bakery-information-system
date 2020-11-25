using System;
using System.Collections.Generic;

namespace Pryanichek_version_1000.Models
{
    public partial class Sort
    {
        public Sort()
        {
            Product = new HashSet<Product>();
            Rack = new HashSet<Rack>();
        }

        public int SortNo { get; set; }
        public string SortName { get; set; }

        public virtual ICollection<Product> Product { get; set; }
        public virtual ICollection<Rack> Rack { get; set; }
    }
}
