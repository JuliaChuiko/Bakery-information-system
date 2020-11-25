using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pryanichek_version_1000.Models
{
    public class ClassClient
    {
        public string ClientName { get; set; }
        public string TelNo { get; set; }
        public int VisitsNumbers { get; set; }

        public int Bonuses { get; set; }
        public int Identifyier { get; set; }
                       
    }
}
