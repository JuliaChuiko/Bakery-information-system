using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pryanichek_version_1000.Models
{
    public class NewBakery
    {
        public string BakeryName { get; set; }
        public int BakeryNo { get; set; }
        public string Adress { get; set; }
        public string TelNo { get; set; }
        public int CountWorkers { get; set; }
        public List<string> OnEachPosition { get; set; }

    }
}
