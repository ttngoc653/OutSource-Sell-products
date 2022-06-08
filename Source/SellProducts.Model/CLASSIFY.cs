using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellProducts.Model
{   using System;
    using System.Collections.Generic;
    
    public partial class CLASSIFY
    {
        public CLASSIFY()
        {
            this.CATEGORY1 = null;
            this.PRODUCT1 = null;
        }

        public int category { get; set; }
        public int product { get; set; }

        public virtual CATEGORY CATEGORY1 { get; set; }
        public virtual PRODUCT PRODUCT1 { get; set; }

        public override bool Equals(object obj)
        {
            return obj is CLASSIFY c &&
                   category == c.category &&
                   product == c.product &&
                   EqualityComparer<CATEGORY>.Default.Equals(CATEGORY1, c.CATEGORY1) &&
                   EqualityComparer<PRODUCT>.Default.Equals(PRODUCT1, c.PRODUCT1);
        }

        public override int GetHashCode()
        {
            int hashCode = 969812892;
            hashCode = hashCode * -1521134295 + category.GetHashCode();
            hashCode = hashCode * -1521134295 + product.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<CATEGORY>.Default.GetHashCode(CATEGORY1);
            hashCode = hashCode * -1521134295 + EqualityComparer<PRODUCT>.Default.GetHashCode(PRODUCT1);
            return hashCode;
        }
    }
}
