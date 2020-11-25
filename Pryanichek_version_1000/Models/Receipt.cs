using System;
using System.Collections.Generic;

namespace Pryanichek_version_1000.Models
{
    public partial class Receipt
    {
        public Receipt()
        {
            Sale = new HashSet<Sale>();
        }

        public int CashierNo { get; set; }
        public DateTime TheDate { get; set; }
        public int ClientNo { get; set; }
        public int ReceiptNo { get; set; }
        public decimal AmountOfDiscount { get; set; }

        public virtual Staff CashierNoNavigation { get; set; }
        public virtual Client ClientNoNavigation { get; set; }
        public virtual ICollection<Sale> Sale { get; set; }
    }
}
