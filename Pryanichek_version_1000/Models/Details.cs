using System;
using System.Collections.Generic;

namespace Pryanichek_version_1000.Models
{
    public partial class Details
    {
        public int DetailsNo { get; set; }
        public int OrderNo { get; set; }
        public int ProductNo { get; set; }
        public int CountProducts { get; set; }
        public int CookNo { get; set; }

        public virtual Staff CookNoNavigation { get; set; }
        public virtual Order OrderNoNavigation { get; set; }
        public virtual Product ProductNoNavigation { get; set; }
    }
}
