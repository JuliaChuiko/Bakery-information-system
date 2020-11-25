using System;
using System.Collections.Generic;

namespace Pryanichek_version_1000.Models
{
    public partial class Sale
    {
        public int SaleNo { get; set; }
        public int ProductNo { get; set; }
        public int ReceiptNo { get; set; }
        public int CountProducts { get; set; }

        public virtual Product ProductNoNavigation { get; set; }
        public virtual Receipt ReceiptNoNavigation { get; set; }
    }
}
