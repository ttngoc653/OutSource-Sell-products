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
    
    public partial class CUSTOMER
    {
        public CUSTOMER()
        {
            this.ORDERS = new List<ORDER>();
        }
    
        public string phone { get; set; }
        public string name { get; set; }
        public string address { get; set; }
    
        public virtual IList<ORDER> ORDERS { get; set; }
    }
}
