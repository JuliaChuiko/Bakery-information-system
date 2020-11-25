using System;
using System.Collections.Generic;

namespace Pryanichek_version_1000.Models
{
    public partial class Order
    {
        public Order()
        {
            Details = new HashSet<Details>();
        }

        public int OrderNo { get; set; }
        public DateTime DateOfReceipt { get; set; }
        public DateTime Deadline { get; set; }
        public string Status { get; set; }
        public int ClientNo { get; set; }
        public int CashierNo { get; set; }
        public string Comments { get; set; }

        public virtual Staff CashierNoNavigation { get; set; }
        public virtual Client ClientNoNavigation { get; set; }
        public virtual ICollection<Details> Details { get; set; }
    }
}
