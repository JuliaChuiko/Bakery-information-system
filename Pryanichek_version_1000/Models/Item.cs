using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pryanichek_version_1000.Models
{
    public class Item
    {
        public int ProductNo { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int count { get; set; }
        public string Message { get; set; }
        public int ProductSort { get; set; }
    }
}
