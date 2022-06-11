using SellProducts.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellProducts.Common.ConnectDB
{
 public class Insert
    {
        public static bool Instance(ACTION action)
        {
            SqlCommand command = new SqlCommand("INSERT INTO [ACTIONS]([idref], [time], [detail], [manager]) " +
                "VALUES (@idref, @time, @detail, @m)");
            command.Parameters.AddWithValue("@idref", action.idref);
            command.Parameters.AddWithValue("@time", action.time);
            command.Parameters.AddWithValue("@detail", action.detail);
            command.Parameters.AddWithValue("@manager", action.manager);

            return General.ConnectDB.AddRecord(command) > 1;
        }

        public static bool Instance(CART cart)
        {
            SqlCommand command = new SqlCommand("INSERT INTO [CARTS]([idorder], [idproduct], [amount], [price]) " +
                "VALUES (@idorder, @idproduct, @amount, @price)");
            command.Parameters.AddWithValue("@idorder", cart.idorder);
            command.Parameters.AddWithValue("@idproduct", cart.idproduct);
            command.Parameters.AddWithValue("@amount", cart.amount);
            command.Parameters.AddWithValue("@price", cart.price);

            return General.ConnectDB.AddRecord(command) > 1;
        }

        public static bool Instance(CATEGORY c)
        {
            if (c is null)
            {
                throw new ArgumentNullException(nameof(c));
            }

            SqlCommand command = new SqlCommand("INSERT INTO [CATEGORIES]([name], [cat_parent], [detail]) " +
                "VALUES (@name, @cat_parent, @detail)");
            command.Parameters.AddWithValue("@name", c.name);
            command.Parameters.AddWithValue("@cat_parent", c.cat_parent);
            command.Parameters.AddWithValue("@detail", c.detail);

            return General.ConnectDB.AddRecord(command) > 1;
        }

        public static bool Instance(CLASSIFY c)
        {
            if (c is null)
            {
                throw new ArgumentNullException(nameof(c));
            }

            SqlCommand command = new SqlCommand("INSERT INTO [CLASSIFIES]([category], [product]) " +
                "VALUES (@category, @product)");
            command.Parameters.AddWithValue("@category", c.category);
            command.Parameters.AddWithValue("@product", c.product);

            return General.ConnectDB.AddRecord(command) > 1;
        }

        public static bool Instance(CUSTOMER c)
        {
            if (c is null)
            {
                throw new ArgumentNullException(nameof(c));
            }

            SqlCommand command = new SqlCommand("INSERT INTO [CUSTOMERS]([phone], [name], [address]) " +
                "VALUES (@phone, @name, @address)");
            command.Parameters.AddWithValue("@phone", c.phone);
            command.Parameters.AddWithValue("@name", c.name);
            command.Parameters.AddWithValue("@address", c.address);

            return General.ConnectDB.AddRecord(command) > 1;
        }

        public static bool Instance(HISTORY c)
        {
            if (c is null)
            {
                throw new ArgumentNullException(nameof(c));
            }

            SqlCommand command = new SqlCommand("INSERT INTO [HISTORIES]([idorder], [datetime], [detail], [act]) " +
                "VALUES (@idorder, @datetime, @detail, @act)");
            command.Parameters.AddWithValue("@idorder", c.idorder);
            command.Parameters.AddWithValue("@datetime", c.datetime);
            command.Parameters.AddWithValue("@detail", c.detail);
            command.Parameters.AddWithValue("@act", c.act);

            return General.ConnectDB.AddRecord(command) > 1;
        }

        public static bool Instance(MADEIN c)
        {
            if (c is null)
            {
                throw new ArgumentNullException(nameof(c));
            }

            SqlCommand command = new SqlCommand("INSERT INTO [MADEINS]([location], [detail]) VALUES (@location, @detail)");
            command.Parameters.AddWithValue("@location", c.location);
            command.Parameters.AddWithValue("@detail", c.detail);

            return General.ConnectDB.AddRecord(command) > 1;
        }

        public static bool Instance(MANAGER m)
        {
            if (m is null)
            {
                throw new ArgumentNullException(nameof(m));
            }

            SqlCommand command = new SqlCommand("INSERT INTO [MANAGERS]([account], [name], [password], [phone], [email], [address], [type], [is_disable], [comment]) " +
                "VALUES (@account, @name, @password, @phone, @email, @address, @type, @is_disable, @comment)");
            command.Parameters.AddWithValue("@account", m.account);
            command.Parameters.AddWithValue("@name", m.name);
            command.Parameters.AddWithValue("@password", m.password);
            command.Parameters.AddWithValue("@phone", m.phone);
            command.Parameters.AddWithValue("@email", m.email);
            command.Parameters.AddWithValue("@address", m.address);
            command.Parameters.AddWithValue("@type", m.type);
            command.Parameters.AddWithValue("@is_disable", m.is_disable);
            command.Parameters.AddWithValue("@comment", m.comment);

            return General.ConnectDB.AddRecord(command) > 1;
        }

        public static bool Instance(MANUFACTURER m)
        {
            if (m is null)
            {
                throw new ArgumentNullException(nameof(m));
            }

            SqlCommand command = new SqlCommand("INSERT INTO [MANUFACTURERES]([name], [detail]) " +
                "VALUES (@name, @detail)");
            command.Parameters.AddWithValue("@name", m.name);
            command.Parameters.AddWithValue("@detail", m.detail);

            return General.ConnectDB.AddRecord(command) > 1;
        }

        public static bool Instance(ORDER m)
        {
            if (m is null)
            {
                throw new ArgumentNullException(nameof(m));
            }

            SqlCommand command = new SqlCommand("INSERT INTO [ORDERS]([time], [customer], [promotion], [total], [comment]) VALUES (@time, @customer, @promotion, @total, @comment)");
            command.Parameters.AddWithValue("@time", m.time);
            command.Parameters.AddWithValue("@customer", m.customer);
            command.Parameters.AddWithValue("@promotion", m.promotion);
            command.Parameters.AddWithValue("@total", m.total);
            command.Parameters.AddWithValue("@comment", m.comment);

            return General.ConnectDB.AddRecord(command) > 1;
        }

        public static bool Instance(PRODUCT m)
        {
            if (m is null)
            {
                throw new ArgumentNullException(nameof(m));
            }

            SqlCommand command = new SqlCommand("INSERT INTO [PRODUCTS]([code], [name], [price], [price_sale], [describe], [detail], [avatar], [amount_current], [madein], [manufacturer], [is_hide]) " +
                "VALUES (@code, @name, @price, @price_sale, @describe, @detail, @avatar, @amount_current, @madein, @manufacturer, @is_hide)");
            command.Parameters.AddWithValue("@code", m.code);
            command.Parameters.AddWithValue("@name", m.name);
            command.Parameters.AddWithValue("@price_sale", m.price_sale);
            command.Parameters.AddWithValue("@describe", m.describe);
            command.Parameters.AddWithValue("@detail", m.detail);
            command.Parameters.AddWithValue("@amount_current", m.amount_current);
            command.Parameters.AddWithValue("@madein", m.madein);
            command.Parameters.AddWithValue("@manufacturer", m.manufacturer);
            command.Parameters.AddWithValue("@is_hide", m.is_hide);

            return General.ConnectDB.AddRecord(command) > 1;
        }

        public static bool Instance(PROMOTION m)
        {
            if (m is null)
            {
                throw new ArgumentNullException(nameof(m));
            }

            SqlCommand command = new SqlCommand("INSERT INTO [PROMOTIONS]([code], [title], [detail], [date_start], [date_end], [type], [percent_discount], [discount], [is_stop], [is_hide], [amount]) " +
                "VALUES (@code, @title, @detail, @date_start, @date_end, @type, @percent_discount, @discount, @is_stop, @is_hide, @amount)");
            command.Parameters.AddWithValue("@code", m.code);
            command.Parameters.AddWithValue("@title", m.title);
            command.Parameters.AddWithValue("@detail", m.detail);
            command.Parameters.AddWithValue("@date_start", m.date_start);
            command.Parameters.AddWithValue("@date_end", m.date_end);
            command.Parameters.AddWithValue("@type", m.type);
            command.Parameters.AddWithValue("@percent_discount", m.percent_discount);
            command.Parameters.AddWithValue("@discount", m.discount);
            command.Parameters.AddWithValue("@is_stop", m.is_stop);
            command.Parameters.AddWithValue("@is_hide", m.is_hide);
            command.Parameters.AddWithValue("@amount", m.amount);

            return General.ConnectDB.AddRecord(command) > 1;
        }

        public static bool Instance(SETTING m)
        {
            if (m is null)
            {
                throw new ArgumentNullException(nameof(m));
            }

            SqlCommand command = new SqlCommand("INSERT INTO [SETTINGS]([name], [value], [account]) " +
                "VALUES (@name, @value, @account)");
            command.Parameters.AddWithValue("@account", m.account);
            command.Parameters.AddWithValue("@name", m.name);
            command.Parameters.AddWithValue("@value", m.value);

            return General.ConnectDB.AddRecord(command) > 1;
        }
    }
}
