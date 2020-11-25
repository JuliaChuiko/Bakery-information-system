using System;
using System.Collections.Generic;

namespace Pryanichek_version_1000.Models
{
    public partial class ProductInclude
    {
        public int ProductIncludeNo { get; set; }
        public int ProductNo { get; set; }
        public int IngredientNo { get; set; }
        public string Measure { get; set; }

        public virtual Ingredient IngredientNoNavigation { get; set; }
        public virtual Product ProductNoNavigation { get; set; }
    }
}
