using System;
using System.Collections.Generic;

namespace Pryanichek_version_1000.Models
{
    public partial class ClientPrefer
    {
        public int ClientPreferNo { get; set; }
        public int ClientNo { get; set; }
        public int ProductNo { get; set; }

        public virtual Client ClientNoNavigation { get; set; }
        public virtual Product ProductNoNavigation { get; set; }
    }
}
