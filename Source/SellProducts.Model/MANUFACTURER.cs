//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SellProducts.Model.Demo
{
    using System.Collections.Generic;

    public partial class MANUFACTURER
    {
        public MANUFACTURER()
        {
            this.PRODUCTS = new List<PRODUCT>();
        }
    
        public int id { get; set; }
        public string name { get; set; }
        public string detail { get; set; }
    
        public virtual IList<PRODUCT> PRODUCTS { get; set; }
    }
}
