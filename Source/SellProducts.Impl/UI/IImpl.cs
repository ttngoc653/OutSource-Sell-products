using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellProducts.Impl.UI
{
    public abstract class IImpl
    {
        /// <summary>
        /// Insert the record
        /// </summary>
        /// <returns>Record inserted</returns>
        public abstract bool Insert();

        /// <summary>
        /// Update this record
        /// </summary>
        /// <returns>This changed</returns>
        public abstract bool Update();

        /// <summary>
        /// Remove this record
        /// </summary>
        /// <returns>Record find and deleted</returns>
        public abstract bool Remove();
    }
}
