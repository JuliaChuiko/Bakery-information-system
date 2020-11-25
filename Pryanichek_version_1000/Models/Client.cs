using System;
using System.Collections.Generic;

namespace Pryanichek_version_1000.Models
{
    public partial class Client
    {
        public Client()
        {
            ClientPrefer = new HashSet<ClientPrefer>();
            Order = new HashSet<Order>();
            Receipt = new HashSet<Receipt>();
        }

        public int ClientNo { get; set; }
        public string FirstName { get; set; }
        public string TelNo { get; set; }
        public int VisitsNumbers { get; set; }
        public int? Bonuses { get; set; }
        public string LastName { get; set; }

        public virtual ICollection<ClientPrefer> ClientPrefer { get; set; }
        public virtual ICollection<Order> Order { get; set; }
        public virtual ICollection<Receipt> Receipt { get; set; }
    }
}
