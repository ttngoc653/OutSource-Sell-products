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
    
    public partial class PROMOTION
    {
        public PROMOTION()
        {
            this.ORDERS = null;
        }
    
        public int id { get; set; }
        public string code { get; set; }
        public string title { get; set; }
        public string detail { get; set; }
        public Nullable<System.DateTime> date_start { get; set; }
        public Nullable<System.DateTime> date_end { get; set; }
        public string type { get; set; }
        public Nullable<decimal> percent_discount { get; set; }
        public Nullable<int> discount { get; set; }
        public bool is_stop { get; set; }
        public bool is_hide { get; set; }
        public Nullable<int> amount { get; set; }
    
        public virtual IList<ORDER> ORDERS { get; set; }

        public override bool Equals(object obj)
        {
            return obj is PROMOTION p &&
                   id == p.id &&
                   code == p.code &&
                   title == p.title &&
                   detail == p.detail &&
                   date_start == p.date_start &&
                   date_end == p.date_end &&
                   type == p.type &&
                   percent_discount == p.percent_discount &&
                   discount == p.discount &&
                   is_stop == p.is_stop &&
                   is_hide == p.is_hide &&
                   amount == p.amount &&
                   EqualityComparer<IList<ORDER>>.Default.Equals(ORDERS, p.ORDERS);
        }

        public override int GetHashCode()
        {
            int hashCode = -280352362;
            hashCode = hashCode * -1521134295 + id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(code);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(title);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(detail);
            hashCode = hashCode * -1521134295 + date_start.GetHashCode();
            hashCode = hashCode * -1521134295 + date_end.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(type);
            hashCode = hashCode * -1521134295 + percent_discount.GetHashCode();
            hashCode = hashCode * -1521134295 + discount.GetHashCode();
            hashCode = hashCode * -1521134295 + is_stop.GetHashCode();
            hashCode = hashCode * -1521134295 + is_hide.GetHashCode();
            hashCode = hashCode * -1521134295 + amount.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<IList<ORDER>>.Default.GetHashCode(ORDERS);
            return hashCode;
        }
    }
}
