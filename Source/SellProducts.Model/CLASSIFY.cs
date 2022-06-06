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
        }

        public int category { get; set; }
        public int product { get; set; }

        public virtual CATEGORY CATEGORY1 { get; set; }
        public virtual PRODUCT PRODUCT1 { get; set; }
    }
}
