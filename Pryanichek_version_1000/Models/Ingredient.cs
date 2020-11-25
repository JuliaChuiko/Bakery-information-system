using System;
using System.Collections.Generic;

namespace Pryanichek_version_1000.Models
{
    public partial class Ingredient
    {
        public Ingredient()
        {
            ProductInclude = new HashSet<ProductInclude>();
        }

        public int IngredientNo { get; set; }
        public string IngredientName { get; set; }
        public bool Allergic { get; set; }

        public virtual ICollection<ProductInclude> ProductInclude { get; set; }
    }
}
