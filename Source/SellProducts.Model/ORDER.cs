//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SellProducts.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class ORDER
    {
        public ORDER()
        {
            this.CARTS = new List<CART>();
            this.HISTORIES = new List<HISTORY>();
        }
    
        public int id { get; set; }
        public System.DateTime time { get; set; }
        public string customer { get; set; }
        public Nullable<int> promotion { get; set; }
        public Nullable<int> total { get; set; }
        public string comment { get; set; }
    
        public virtual IList<CART> CARTS { get; set; }
        public virtual CUSTOMER CUSTOMER1 { get; set; }
        public virtual IList<HISTORY> HISTORIES { get; set; }
        public virtual PROMOTION PROMOTION1 { get; set; }
    }
}
