using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellProducts.Common.ConnectDB
{
    public class Delete
    {
        /// <summary>
        /// Delete the setting record with key as idorder and idproduct
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static int Instance(Model.CART p)
        {
            if (p is null)
            {
                throw new ArgumentNullException(nameof(p));
            }

            SqlCommand command = new SqlCommand("DELETE FROM [CARTS] " +
                "WHERE [idorder] = @idorder " +
                "AND [idproduct] = @idproduct");
            command.Parameters.AddWithValue("@idorder", p.idorder);
            command.Parameters.AddWithValue("@idproduct", p.idproduct);

            return General.ConnectDB.UpdateRecord(command);
        }

        /// <summary>
        /// Delete the setting record with key as id
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static int Instance(Model.CATEGORY p)
        {
            if (p is null)
            {
                throw new ArgumentNullException(nameof(p));
            }

            SqlCommand command = new SqlCommand("DELETE FROM [CATEGORIES] " +
                "WHERE [id] = @id");
            command.Parameters.AddWithValue("@id", p.id);

            return General.ConnectDB.UpdateRecord(command);
        }

        /// <summary>
        /// Delete the setting record with key as phone
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static int Instance(Model.CUSTOMER p)
        {
            if (p is null)
            {
                throw new ArgumentNullException(nameof(p));
            }

            SqlCommand command = new SqlCommand("DELETE FROM [CUSTOMERS] " +
                "WHERE [phone] = @phone");
            command.Parameters.AddWithValue("@address", p.address);

            return General.ConnectDB.UpdateRecord(command);
        }

        /// <summary>
        /// Delete the setting record with key as idorder and datetime
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static int Instance(Model.HISTORY p)
        {
            if (p is null)
            {
                throw new ArgumentNullException(nameof(p));
            }

            SqlCommand command = new SqlCommand("DELETE FROM [HISTORIES] " +
                "WHERE [idorder] = @idorder" +
                "AND [datetime] = @datetime");
            command.Parameters.AddWithValue("@datetime", p.datetime);
            command.Parameters.AddWithValue("@idorder", p.idorder);

            return General.ConnectDB.UpdateRecord(command);
        }

        /// <summary>
        /// Delete the setting record with key as id
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static int Instance(Model.MADEIN p)
        {
            if (p is null)
            {
                throw new ArgumentNullException(nameof(p));
            }

            SqlCommand command = new SqlCommand("DELETE FROM [MADEINS] " +
                "WHERE [id] = @id");
            command.Parameters.AddWithValue("@id", p.id);

            return General.ConnectDB.UpdateRecord(command);
        }

        /// <summary>
        /// Delete the setting record with key as account
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static int Instance(Model.MANAGER p)
        {
            if (p is null)
            {
                throw new ArgumentNullException(nameof(p));
            }

            SqlCommand command = new SqlCommand("DELETE FROM [MANAGERS] " +
                "WHERE [account] = @account");
            command.Parameters.AddWithValue("@account", p.account);

            return General.ConnectDB.UpdateRecord(command);
        }

        /// <summary>
        /// Delete the setting record with key as id
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static int Instance(Model.MANUFACTURER p)
        {
            if (p is null)
            {
                throw new ArgumentNullException(nameof(p));
            }

            SqlCommand command = new SqlCommand("DELETE FROM MANUFACTURERES " +
                "WHERE [id] = @id");
            command.Parameters.AddWithValue("@id", p.id);

            return General.ConnectDB.UpdateRecord(command);
        }

        /// <summary>
        /// Delete the setting record with key as id
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static int Instance(Model.ORDER p)
        {
            if (p is null)
            {
                throw new ArgumentNullException(nameof(p));
            }

            SqlCommand command = new SqlCommand("DELETE FROM [ORDERS] " +
                "WHERE [id] = @id");
            command.Parameters.AddWithValue("@id", p.id);

            return General.ConnectDB.UpdateRecord(command);
        }

        /// <summary>
        /// Delete the setting record with key as id
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static int Instance(Model.PRODUCT p)
        {
            if (p is null)
            {
                throw new ArgumentNullException(nameof(p));
            }

            SqlCommand command = new SqlCommand("DELETE FROM [PRODUCTS] " +
                "WHERE [id] = @id");
            command.Parameters.AddWithValue("@id", p.id);
            
            return General.ConnectDB.UpdateRecord(command);
        }

        /// <summary>
        /// Delete the setting record with key as id
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static int Instance(Model.PROMOTION p)
        {
            if (p is null)
            {
                throw new ArgumentNullException(nameof(p));
            }

            SqlCommand command = new SqlCommand("DELETE FROM [PROMOTIONS] " +
                "WHERE [id] = @id");
            command.Parameters.AddWithValue("@id", p.id);
            
            return General.ConnectDB.UpdateRecord(command);
        }

        /// <summary>
        /// Delete the setting record with key as name and account
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static int Instance(Model.SETTING p)
        {
            if (p is null)
            {
                throw new ArgumentNullException(nameof(p));
            }

            SqlCommand command = new SqlCommand("DELETE FROM [SETTINGS] " +
                "WHERE [name] = @name AND [account] = @account");
            command.Parameters.AddWithValue("@account", p.account);
            command.Parameters.AddWithValue("@name", p.name);
            
            return General.ConnectDB.UpdateRecord(command);
        }
    }
}
