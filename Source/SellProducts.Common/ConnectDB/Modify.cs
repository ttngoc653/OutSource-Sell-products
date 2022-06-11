using SellProducts.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellProducts.Common.ConnectDB
{
    public class Modify
    {
        public int ChangePassword(string username, string oldPassword, string newPassword)
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

        public int UpdateCart(CART p)
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

        public int UpdateCategory(CATEGORY p)
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
            command.Parameters.AddWithValue("@name", p.name);
            command.Parameters.AddWithValue("@cat_parent", p.cat_parent);
            command.Parameters.AddWithValue("@detail", p.detail);

            return General.ConnectDB.UpdateRecord(command);
        }

        public int UpdateCustomer(CUSTOMER p)
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
            command.Parameters.AddWithValue("@name", p.name);
            command.Parameters.AddWithValue("@address", p.address);

            return General.ConnectDB.UpdateRecord(command);
        }

        public int UpdateHistory(HISTORY p)
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
            command.Parameters.AddWithValue("@act", p.act);
            command.Parameters.AddWithValue("@detail", p.detail);
            command.Parameters.AddWithValue("@idorder", p.idorder);

            return General.ConnectDB.UpdateRecord(command);
        }

        public int UpdateMadeIn(MADEIN p)
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
            command.Parameters.AddWithValue("@location", p.location);
            command.Parameters.AddWithValue("@detail", p.detail);

            return General.ConnectDB.UpdateRecord(command);
        }

        public int UpdateManager(MANAGER p)
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
            command.Parameters.AddWithValue("@address", p.address);
            command.Parameters.AddWithValue("@comment", p.comment);
            command.Parameters.AddWithValue("@email", p.email);
            command.Parameters.AddWithValue("@is_disable", p.is_disable);
            command.Parameters.AddWithValue("@name", p.name);
            command.Parameters.AddWithValue("@password", p.password);
            command.Parameters.AddWithValue("@phone", p.phone);
            command.Parameters.AddWithValue("@type", p.type);

            return General.ConnectDB.UpdateRecord(command);
        }

        public int UpdateManufacturer(MANUFACTURER p)
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
            command.Parameters.AddWithValue("@name", p.name);
            command.Parameters.AddWithValue("@detail", p.detail);

            return General.ConnectDB.UpdateRecord(command);
        }

        public int UpdateOrder(ORDER p)
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
            command.Parameters.AddWithValue("@comment", p.comment);
            command.Parameters.AddWithValue("@customer", p.customer);
            command.Parameters.AddWithValue("@promotion", p.promotion);
            command.Parameters.AddWithValue("@time", p.time);
            command.Parameters.AddWithValue("@total", p.total);

            return General.ConnectDB.UpdateRecord(command);
        }

        public int UpdateProduct(PRODUCT p)
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
            command.Parameters.AddWithValue("@amount_current", p.amount_current);
            command.Parameters.AddWithValue("@code", p.code);
            command.Parameters.AddWithValue("@describe", p.describe);
            command.Parameters.AddWithValue("@detail", p.detail);
            command.Parameters.AddWithValue("@is_hide", p.is_hide);
            command.Parameters.AddWithValue("@madein", p.madein);
            command.Parameters.AddWithValue("@manufacturer", p.manufacturer);
            command.Parameters.AddWithValue("@name", p.name);
            command.Parameters.AddWithValue("@price", p.price);
            command.Parameters.AddWithValue("@price_sale", p.price_sale);

            return General.ConnectDB.UpdateRecord(command);
        }

        public int UpdatePromotion(PROMOTION p)
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
            command.Parameters.AddWithValue("@amount", p.amount);
            command.Parameters.AddWithValue("@code", p.code);
            command.Parameters.AddWithValue("@date_end", p.date_end);
            command.Parameters.AddWithValue("@date_start", p.date_start);
            command.Parameters.AddWithValue("@detail", p.detail);
            command.Parameters.AddWithValue("@discount", p.discount);
            command.Parameters.AddWithValue("@is_hide", p.is_hide);
            command.Parameters.AddWithValue("@is_stop", p.is_stop);
            command.Parameters.AddWithValue("@percent_discount", p.percent_discount);
            command.Parameters.AddWithValue("@title", p.title);
            command.Parameters.AddWithValue("@type", p.type);

            return General.ConnectDB.UpdateRecord(command);
        }

        public int UpdateSetting(SETTING p)
        {
            if (p is null)
            {
                throw new ArgumentNullException(nameof(p));
            }

            SqlCommand command = new SqlCommand("UPDATE [SETTINGS] SET [value] = @value WHERE [name] = @name AND [account] = @account");
            command.Parameters.AddWithValue("@account", p.account);
            command.Parameters.AddWithValue("@name", p.name);
            command.Parameters.AddWithValue("@value", p.value);

            return General.ConnectDB.UpdateRecord(command);
        }
    }
}
