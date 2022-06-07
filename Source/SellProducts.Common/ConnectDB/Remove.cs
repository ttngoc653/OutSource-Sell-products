using SellProducts.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellProducts.Common.ConnectDB
{
    class Remove
    {
        public int Classify(CLASSIFY p)
        {
            if (p is null)
            {
                throw new ArgumentNullException(nameof(p));
            }

            SqlCommand command = new SqlCommand("DELETE [CLASSIFIES] " +
                "WHERE [category] = @category " +
                "AND [product] = @product");
            command.Parameters.AddWithValue("@category", p.category);
            command.Parameters.AddWithValue("@product", p.product);

            return General.ConnectDB.UpdateRecord(command);
        }

        public int Cart(CART p)
        {
            if (p is null)
            {
                throw new ArgumentNullException(nameof(p));
            }

            SqlCommand command = new SqlCommand("DELETE [CARTS] " +
                "WHERE [idorder] = @idorder " +
                "AND [idproduct] = @idproduct");
            command.Parameters.AddWithValue("@idorder", p.idorder);
            command.Parameters.AddWithValue("@idproduct", p.idproduct);

            return General.ConnectDB.UpdateRecord(command);
        }
    }
}
