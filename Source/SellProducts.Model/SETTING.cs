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
    
    public partial class SETTING
    {
        public SETTING()
        {
            this.MANAGER1 = null;
        }

        public string name { get; set; }
        public string value { get; set; }
        public string account { get; set; }
    
        public virtual MANAGER MANAGER1 { get; set; }

        public override bool Equals(object obj)
        {
            return obj is SETTING s &&
                   name == s.name &&
                   value == s.value &&
                   account == s.account &&
                   EqualityComparer<MANAGER>.Default.Equals(MANAGER1, s.MANAGER1);
        }

        public override int GetHashCode()
        {
            int hashCode = 787316227;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(value);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(account);
            hashCode = hashCode * -1521134295 + EqualityComparer<MANAGER>.Default.GetHashCode(MANAGER1);
            return hashCode;
        }
    }
}
