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
    
    public partial class ACTION
    {
        public ACTION()
        {
            MANAGER1 = null;
        }

        public int id { get; set; }
        public string idref { get; set; }
        public Nullable<System.DateTime> time { get; set; }
        public string detail { get; set; }
        public string manager { get; set; }
    
        public virtual MANAGER MANAGER1 { get; set; }

        public override bool Equals(object obj)
        {
            return obj is ACTION a &&
                   id == a.id &&
                   idref == a.idref &&
                   time == a.time &&
                   detail == a.detail &&
                   manager == a.manager &&
                   EqualityComparer<MANAGER>.Default.Equals(MANAGER1, a.MANAGER1);
        }

        public override int GetHashCode()
        {
            int hashCode = -1509898008;
            hashCode = hashCode * -1521134295 + id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(idref);
            hashCode = hashCode * -1521134295 + time.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(detail);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(manager);
            hashCode = hashCode * -1521134295 + EqualityComparer<MANAGER>.Default.GetHashCode(MANAGER1);
            return hashCode;
        }
    }
}
