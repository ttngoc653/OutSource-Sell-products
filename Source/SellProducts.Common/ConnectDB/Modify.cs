using SellProducts.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellProducts.Common.ConnectDB
{
    public class Update
    {
        public static int ChangePassword(string username, string oldPassword, string newPassword)
        {
            SqlCommand command = new SqlCommand("UPDATE [MANAGERS] SET " +
                "[password] = @newPa " +
                "WHERE [account] like @ac " +
                "AND [password] like @oldPa");
            command.Parameters.AddWithValue("@newPa", newPassword);
            command.Parameters.AddWithValue("@ac", username);
            command.Parameters.AddWithValue("@oldPa", oldPassword);

            return General.ConnectDB.UpdateRecord(command);
        }

        /// <summary>
        /// Update the setting record with key as idorder and idproduct
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static int Instance(CART p)
        {
            if (p is null)
            {
                throw new ArgumentNullException(nameof(p));
            }

            SqlCommand command = new SqlCommand("UPDATE [CARTS] SET " +
                "[amount] = @amount, " +
                "[price] = @price " +
                "WHERE [idorder] = @idorder " +
                "AND [idproduct] = @idproduct");
            command.Parameters.AddWithValue("@amount", p.amount);
            command.Parameters.AddWithValue("@price", p.price);
            command.Parameters.AddWithValue("@idorder", p.idorder);
            command.Parameters.AddWithValue("@idproduct", p.idproduct);

            return General.ConnectDB.UpdateRecord(command);
        }

        /// <summary>
        /// Update the setting record with key as id
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static int Instance(CATEGORY p)
        {
            if (p is null)
            {
                throw new ArgumentNullException(nameof(p));
            }

            SqlCommand command = new SqlCommand("UPDATE [CATEGORIES] SET " +
                "[name] = @name, " +
                "[cat_parent] = @cat_parent, " +
                "[detail] = @detail " +
                "WHERE [id] = @id");
            command.Parameters.AddWithValue("@id", p.id);

            if (string.IsNullOrEmpty(p.name))
                command.Parameters.AddWithValue("@name", DBNull.Value);
            else
                command.Parameters.AddWithValue("@name", p.name);
            
            if (p.cat_parent.HasValue)
                command.Parameters.AddWithValue("@cat_parent", p.cat_parent);
            else
                command.Parameters.AddWithValue("@cat_parent", DBNull.Value);

            if (string.IsNullOrEmpty(p.detail))
                command.Parameters.AddWithValue("@detail", DBNull.Value);
            else
                command.Parameters.AddWithValue("@detail", p.detail);

            return General.ConnectDB.UpdateRecord(command);
        }

        /// <summary>
        /// Update the setting record with key as phone
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static int Instance(CUSTOMER p)
        {
            if (p is null)
            {
                throw new ArgumentNullException(nameof(p));
            }

            SqlCommand command = new SqlCommand("UPDATE [CUSTOMERS] SET " +
                "[name] = @name, " +
                "[address] = @address " +
                "WHERE [phone] = @phone");
            command.Parameters.AddWithValue("@phone", p.phone);

            if (string.IsNullOrEmpty(p.name))
                command.Parameters.AddWithValue("@name", DBNull.Value);
            else
                command.Parameters.AddWithValue("@name", p.name);

            if (string.IsNullOrEmpty(p.address))
                command.Parameters.AddWithValue("@address", DBNull.Value);
            else
                command.Parameters.AddWithValue("@address", p.address);

            return General.ConnectDB.UpdateRecord(command);
        }

        /// <summary>
        /// Update the setting record with key as idorder and datetime
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static int Instance(HISTORY p)
        {
            if (p is null)
            {
                throw new ArgumentNullException(nameof(p));
            }

            SqlCommand command = new SqlCommand("UPDATE [HISTORIES] SET " +
                "[detail] = @detail, " +
                "[act] = @act " +
                "WHERE [idorder] = @idorder" +
                "AND [datetime] = @datetime");
            command.Parameters.AddWithValue("@datetime", p.datetime);

            if (string.IsNullOrEmpty(p.act))
                command.Parameters.AddWithValue("@act", DBNull.Value);
            else
                command.Parameters.AddWithValue("@act", p.act);

            if (string.IsNullOrEmpty(p.detail))
                command.Parameters.AddWithValue("@detail", DBNull.Value);
            else
                command.Parameters.AddWithValue("@detail", p.detail);
            
            command.Parameters.AddWithValue("@idorder", p.idorder);

            return General.ConnectDB.UpdateRecord(command);
        }

        /// <summary>
        /// Update the setting record with key as id
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static int Instance(MADEIN p)
        {
            if (p is null)
            {
                throw new ArgumentNullException(nameof(p));
            }

            SqlCommand command = new SqlCommand("UPDATE [MADEINS] SET " +
                "[location] = @location, " +
                "[detail] = @detail " +
                "WHERE [id] = @id");
            command.Parameters.AddWithValue("@id", p.id);

            if (string.IsNullOrEmpty(p.location))
                command.Parameters.AddWithValue("@location", DBNull.Value);
            else
                command.Parameters.AddWithValue("@location", p.location);

            if (string.IsNullOrEmpty(p.detail))
                command.Parameters.AddWithValue("@detail", DBNull.Value);
            else
                command.Parameters.AddWithValue("@detail", p.detail);

            return General.ConnectDB.UpdateRecord(command);
        }

        /// <summary>
        /// Update the setting record with key as account
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static int Instance(MANAGER p)
        {
            if (p is null)
            {
                throw new ArgumentNullException(nameof(p));
            }

            SqlCommand command = new SqlCommand("UPDATE [MANAGERS] SET " +
                "[account] = @account, " +
                "[name] = @name, " +
                "[password] = @password, " +
                "[phone] = @phone, " +
                "[email] = @email, " +
                "[address] = @address, " +
                "[type] = @type, " +
                "[is_disable] = @is_disable, " +
                "[comment] = @comment " +
                "WHERE [account] = @account");
            command.Parameters.AddWithValue("@account", p.account);

            if (string.IsNullOrEmpty(p.address))
                command.Parameters.AddWithValue("@address", DBNull.Value);
            else
                command.Parameters.AddWithValue("@address", p.address);

            if (string.IsNullOrEmpty(p.comment))
                command.Parameters.AddWithValue("@comment", DBNull.Value);
            else
                command.Parameters.AddWithValue("@comment", p.comment);

            if(string.IsNullOrEmpty(p.email))
                command.Parameters.AddWithValue("@email", DBNull.Value);
            else
                command.Parameters.AddWithValue("@email", p.email);

            command.Parameters.AddWithValue("@is_disable", p.is_disable);

            if (string.IsNullOrEmpty(p.name))
                command.Parameters.AddWithValue("@name", DBNull.Value);
            else
                command.Parameters.AddWithValue("@name", p.name);

            command.Parameters.AddWithValue("@password", p.password);

            if (string.IsNullOrEmpty(p.phone))
                command.Parameters.AddWithValue("@phone", DBNull.Value);
            else
                command.Parameters.AddWithValue("@phone", p.phone);

            if (string.IsNullOrEmpty(p.type))
                command.Parameters.AddWithValue("@type", DBNull.Value);
            else
                command.Parameters.AddWithValue("@type", p.type);

            return General.ConnectDB.UpdateRecord(command);
        }

        /// <summary>
        /// Update the setting record with key as id
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static int Instance(MANUFACTURER p)
        {
            if (p is null)
            {
                throw new ArgumentNullException(nameof(p));
            }

            SqlCommand command = new SqlCommand("UPDATE MANUFACTURERES SET " +
                "[name] = @name, " +
                "[detail] = @detail " +
                "WHERE [id] = @id");
            command.Parameters.AddWithValue("@id", p.id);

            if (string.IsNullOrEmpty(p.name))
                command.Parameters.AddWithValue("@name", DBNull.Value);
            else
                command.Parameters.AddWithValue("@name", p.name);

            if (string.IsNullOrEmpty(p.detail))
                command.Parameters.AddWithValue("@detail", DBNull.Value);
            else
                command.Parameters.AddWithValue("@detail", p.detail);

            return General.ConnectDB.UpdateRecord(command);
        }

        /// <summary>
        /// Update the setting record with key as id
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static int Instance(ORDER p)
        {
            if (p is null)
            {
                throw new ArgumentNullException(nameof(p));
            }

            SqlCommand command = new SqlCommand("UPDATE [ORDERS] SET " +
                "[time] = @time, " +
                "[customer] = @customer, " +
                "[promotion] = @promotion, " +
                "[total] = @total, " +
                "[comment] = @comment " +
                "WHERE [id] = @id");
            command.Parameters.AddWithValue("@id", p.id);
            
            if (string.IsNullOrEmpty(p.comment))
                command.Parameters.AddWithValue("@comment", DBNull.Value);
            else
                command.Parameters.AddWithValue("@comment", p.comment);

            if (string.IsNullOrEmpty(p.customer))
                command.Parameters.AddWithValue("@customer", DBNull.Value);
            else
                command.Parameters.AddWithValue("@customer", p.customer);

            if (p.promotion.HasValue)
                command.Parameters.AddWithValue("@promotion", p.promotion);
            else
                command.Parameters.AddWithValue("@promotion", DBNull.Value);

            command.Parameters.AddWithValue("@time", p.time);

            if (p.total.HasValue)
                command.Parameters.AddWithValue("@total", p.total);
            else
                command.Parameters.AddWithValue("@total", DBNull.Value);

            return General.ConnectDB.UpdateRecord(command);
        }

        /// <summary>
        /// Update the setting record with key as id
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static int Instance(PRODUCT p)
        {
            if (p is null)
            {
                throw new ArgumentNullException(nameof(p));
            }

            SqlCommand command = new SqlCommand("UPDATE [PRODUCTS] SET " +
                "[code] = @code, " +
                "[name] = @name, " +
                "[price] = @price, " +
                "[price_sale] = @price_sale, " +
                "[describe] = @describe, " +
                "[detail] = @detail, " +
                "[amount_current] = @amount_current, " +
                "[madein] = @madein, " +
                "[manufacturer] = @manufacturer, " +
                "[is_hide] = @is_hide " +
                "WHERE [id] = @id");

            command.Parameters.AddWithValue("@id", p.id);

            if (p.amount_current == null)
                command.Parameters.AddWithValue("@amount_current", DBNull.Value);
            else
                command.Parameters.AddWithValue("@amount_current", p.amount_current);

            if (string.IsNullOrEmpty(p.code))
                command.Parameters.AddWithValue("@code", DBNull.Value);
            else
                command.Parameters.AddWithValue("@code", p.code);

            if (string.IsNullOrEmpty(p.describe))
                command.Parameters.AddWithValue("@describe", DBNull.Value);
            else
                command.Parameters.AddWithValue("@describe", p.describe);

            if (string.IsNullOrEmpty(p.detail))
                command.Parameters.AddWithValue("@detail", DBNull.Value);
            else
                command.Parameters.AddWithValue("@detail", p.detail);

            command.Parameters.AddWithValue("@is_hide", p.is_hide);

            if (p.madein.HasValue)
                command.Parameters.AddWithValue("@madein", p.madein);
            else
                command.Parameters.AddWithValue("@madein", DBNull.Value);

            if (p.manufacturer.HasValue)
                command.Parameters.AddWithValue("@manufacturer", p.manufacturer);
            else
                command.Parameters.AddWithValue("@manufacturer", DBNull.Value);

            if (string.IsNullOrEmpty(p.name))
                command.Parameters.AddWithValue("@name", DBNull.Value);
            else
                command.Parameters.AddWithValue("@name", p.name);

            if (p.price.HasValue)
                command.Parameters.AddWithValue("@price", p.price);
            else
                command.Parameters.AddWithValue("@price", DBNull.Value);

            if (p.price_sale.HasValue)
                command.Parameters.AddWithValue("@price_sale", p.price_sale);
            else
                command.Parameters.AddWithValue("@price_sale", DBNull.Value);

            return General.ConnectDB.UpdateRecord(command);
        }

        /// <summary>
        /// Update the setting record with key as id
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static int Instance(PROMOTION p)
        {
            if (p is null)
            {
                throw new ArgumentNullException(nameof(p));
            }

            SqlCommand command = new SqlCommand("UPDATE [PROMOTIONS] SET " +
                "[code] = @code, " +
                "[title] = @title, " +
                "[detail] = @detail, " +
                "[date_start] = @date_start, " +
                "[date_end] = @date_end, " +
                "[type] = @type, " +
                "[percent_discount] = @percent_discount, " +
                "[discount] = @discount, " +
                "[is_stop] = @is_stop, " +
                "[is_hide] = @is_hide, " +
                "[amount] = @amount " +
                "WHERE [id] = @id");
            command.Parameters.AddWithValue("@id", p.id);

            if (p.amount.HasValue)
                command.Parameters.AddWithValue("@amount", p.amount);
            else
                command.Parameters.AddWithValue("@amount", DBNull.Value);

            if (string.IsNullOrEmpty(p.code))
                command.Parameters.AddWithValue("@code", DBNull.Value);
            else
                command.Parameters.AddWithValue("@code", p.code);

            if (p.date_end.HasValue)
                command.Parameters.AddWithValue("@date_end", p.date_end);
            else
                command.Parameters.AddWithValue("@date_end", DBNull.Value);

            if(p.date_start.HasValue)
                command.Parameters.AddWithValue("@date_start", p.date_start);
            else
                command.Parameters.AddWithValue("@date_start", DBNull.Value);

            if (string.IsNullOrEmpty(p.detail))
                command.Parameters.AddWithValue("@detail", DBNull.Value);
            else
                command.Parameters.AddWithValue("@detail", p.detail);

            if (p.discount.HasValue)
                command.Parameters.AddWithValue("@discount", p.discount);
            else
                command.Parameters.AddWithValue("@discount", DBNull.Value);

            command.Parameters.AddWithValue("@is_hide", p.is_hide);
            command.Parameters.AddWithValue("@is_stop", p.is_stop);

            if (p.percent_discount.HasValue)
                command.Parameters.AddWithValue("@percent_discount", p.percent_discount);
            else
                command.Parameters.AddWithValue("@percent_discount", DBNull.Value);

            if (string.IsNullOrEmpty(p.title))
                command.Parameters.AddWithValue("@title", DBNull.Value);
            else
                command.Parameters.AddWithValue("@title", p.title);

            if (string.IsNullOrEmpty(p.type))
                command.Parameters.AddWithValue("@type", DBNull.Value);
            else
                command.Parameters.AddWithValue("@type", p.type);

            return General.ConnectDB.UpdateRecord(command);
        }

        /// <summary>
        /// Update the setting record with key as name and account
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static int Instance(SETTING p)
        {
            if (p is null)
            {
                throw new ArgumentNullException(nameof(p));
            }

            SqlCommand command = new SqlCommand("UPDATE [SETTINGS] SET [value] = @value WHERE [name] = @name AND [account] = @account");
            command.Parameters.AddWithValue("@account", p.account);
            command.Parameters.AddWithValue("@name", p.name);

            if (string.IsNullOrEmpty(p.value))
                command.Parameters.AddWithValue("@value", DBNull.Value);
            else
                command.Parameters.AddWithValue("@value", p.value);

            return General.ConnectDB.UpdateRecord(command);
        }
    }
}
