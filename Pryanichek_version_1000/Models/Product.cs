using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pryanichek_version_1000.Models
{
    public class Product
    {
        public static IEnumerable<Product> GetProducts() => new List<Product>
        {

        };
    
    public Product()
        {
            ClientPrefer = new HashSet<ClientPrefer>();
            Details = new HashSet<Details>();
            ProductInclude = new HashSet<ProductInclude>();
            Sale = new HashSet<Sale>();
        }
        public Product(int no,string name,decimal price)
        {
            ProductNo = no;
            ProductName = name;
            Price = price;
        }
        public int ProductNo { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int ProductSort { get; set; }
        public int PreparingTime { get; set; }
        public string Recipe { get; set; }

        public virtual Sort ProductSortNavigation { get; set; }
        public virtual ICollection<ClientPrefer> ClientPrefer { get; set; }
        public virtual ICollection<Details> Details { get; set; }
        public virtual ICollection<ProductInclude> ProductInclude { get; set; }
        public virtual ICollection<Sale> Sale { get; set; }
    }
}
