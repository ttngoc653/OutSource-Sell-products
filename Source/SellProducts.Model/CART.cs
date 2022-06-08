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
    
    public partial class CART
    {
        public CART()
        {
            this.ORDER1 = null;
            this.PRODUCT1 = null;
        }

        public int idorder { get; set; }
        public int idproduct { get; set; }
        public int amount { get; set; }
        public int price { get; set; }
    
        public virtual ORDER ORDER1 { get; set; }
        public virtual PRODUCT PRODUCT1 { get; set; }

        public override bool Equals(object obj)
        {
            return obj is CART c &&
                   idorder == c.idorder &&
                   idproduct == c.idproduct &&
                   amount == c.amount &&
                   price == c.price &&
                   EqualityComparer<ORDER>.Default.Equals(ORDER1, c.ORDER1) &&
                   EqualityComparer<PRODUCT>.Default.Equals(PRODUCT1, c.PRODUCT1);
        }

        public override int GetHashCode()
        {
            int hashCode = 586198363;
            hashCode = hashCode * -1521134295 + idorder.GetHashCode();
            hashCode = hashCode * -1521134295 + idproduct.GetHashCode();
            hashCode = hashCode * -1521134295 + amount.GetHashCode();
            hashCode = hashCode * -1521134295 + price.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<ORDER>.Default.GetHashCode(ORDER1);
            hashCode = hashCode * -1521134295 + EqualityComparer<PRODUCT>.Default.GetHashCode(PRODUCT1);
            return hashCode;
        }
    }
}
