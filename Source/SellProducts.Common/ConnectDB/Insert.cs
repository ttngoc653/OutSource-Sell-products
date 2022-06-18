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

            if (string.IsNullOrEmpty(c.name))
                command.Parameters.AddWithValue("@name", DBNull.Value);
            else
                command.Parameters.AddWithValue("@name", c.name);

            if (c.cat_parent.HasValue)
                command.Parameters.AddWithValue("@cat_parent", c.cat_parent);
            else
                command.Parameters.AddWithValue("@cat_parent", DBNull.Value);

            if (string.IsNullOrEmpty(c.detail))
                command.Parameters.AddWithValue("@detail", DBNull.Value);
            else
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

        public static bool Instance(HISTORY h)
        {
            if (h is null)
            {
                throw new ArgumentNullException(nameof(h));
            }

            SqlCommand command = new SqlCommand("INSERT INTO [HISTORIES]([idorder], [datetime], [detail], [act]) " +
                "VALUES (@idorder, @datetime, @detail, @act)");
            command.Parameters.AddWithValue("@idorder", h.idorder);
            command.Parameters.AddWithValue("@datetime", h.datetime);

            if (string.IsNullOrEmpty(h.act))
                command.Parameters.AddWithValue("@act", DBNull.Value);
            else
                command.Parameters.AddWithValue("@act", h.act);

            if (string.IsNullOrEmpty(h.detail))
                command.Parameters.AddWithValue("@detail", DBNull.Value);
            else
                command.Parameters.AddWithValue("@detail", h.detail);

            return General.ConnectDB.AddRecord(command) > 1;
        }

        public static bool Instance(MADEIN m)
        {
            if (m is null)
            {
                throw new ArgumentNullException(nameof(m));
            }

            SqlCommand command = new SqlCommand("INSERT INTO [MADEINS]([location], [detail]) VALUES (@location, @detail)");

            if (string.IsNullOrEmpty(m.location))
                command.Parameters.AddWithValue("@location", DBNull.Value);
            else
                command.Parameters.AddWithValue("@location", m.location);

            if (string.IsNullOrEmpty(m.detail))
                command.Parameters.AddWithValue("@detail", DBNull.Value);
            else
                command.Parameters.AddWithValue("@detail", m.detail);

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

            if (string.IsNullOrEmpty(m.address))
                command.Parameters.AddWithValue("@address", DBNull.Value);
            else
                command.Parameters.AddWithValue("@address", m.address);

            if (string.IsNullOrEmpty(m.comment))
                command.Parameters.AddWithValue("@comment", DBNull.Value);
            else
                command.Parameters.AddWithValue("@comment", m.comment);

            if (string.IsNullOrEmpty(m.email))
                command.Parameters.AddWithValue("@email", DBNull.Value);
            else
                command.Parameters.AddWithValue("@email", m.email);

            command.Parameters.AddWithValue("@is_disable", m.is_disable);

            if (string.IsNullOrEmpty(m.name))
                command.Parameters.AddWithValue("@name", DBNull.Value);
            else
                command.Parameters.AddWithValue("@name", m.name);

            command.Parameters.AddWithValue("@password", m.password);

            if (string.IsNullOrEmpty(m.phone))
                command.Parameters.AddWithValue("@phone", DBNull.Value);
            else
                command.Parameters.AddWithValue("@phone", m.phone);

            if (string.IsNullOrEmpty(m.type))
                command.Parameters.AddWithValue("@type", DBNull.Value);
            else
                command.Parameters.AddWithValue("@type", m.type);

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

            if (string.IsNullOrEmpty(m.name))
                command.Parameters.AddWithValue("@name", DBNull.Value);
            else
                command.Parameters.AddWithValue("@name", m.name);

            if (string.IsNullOrEmpty(m.detail))
                command.Parameters.AddWithValue("@detail", DBNull.Value);
            else
                command.Parameters.AddWithValue("@detail", m.detail);

            return General.ConnectDB.AddRecord(command) > 1;
        }

        public static bool Instance(ORDER o)
        {
            if (o is null)
            {
                throw new ArgumentNullException(nameof(o));
            }

            SqlCommand command = new SqlCommand("INSERT INTO [ORDERS]([time], [customer], [promotion], [total], [comment]) VALUES (@time, @customer, @promotion, @total, @comment)");
            
            if (string.IsNullOrEmpty(o.comment))
                command.Parameters.AddWithValue("@comment", DBNull.Value);
            else
                command.Parameters.AddWithValue("@comment", o.comment);

            if (string.IsNullOrEmpty(o.customer))
                command.Parameters.AddWithValue("@customer", DBNull.Value);
            else
                command.Parameters.AddWithValue("@customer", o.customer);

            if (o.promotion.HasValue)
                command.Parameters.AddWithValue("@promotion", o.promotion);
            else
                command.Parameters.AddWithValue("@promotion", DBNull.Value);

            command.Parameters.AddWithValue("@time", o.time);

            if (o.total.HasValue)
                command.Parameters.AddWithValue("@total", o.total);
            else
                command.Parameters.AddWithValue("@total", DBNull.Value);

            return General.ConnectDB.AddRecord(command) > 1;
        }

        public static bool Instance(PRODUCT p)
        {
            if (p is null)
            {
                throw new ArgumentNullException(nameof(p));
            }

            SqlCommand command = new SqlCommand("INSERT INTO [PRODUCTS]([code], [name], [price], [price_sale], [describe], [detail], [amount_current], [madein], [manufacturer], [is_hide]) " +
                "VALUES (@code, @name, @price, @price_sale, @describe, @detail, @amount_current, @madein, @manufacturer, @is_hide)");

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

            return General.ConnectDB.AddRecord(command) > 0;
        }

        public static bool Instance(PROMOTION p)
        {
            if (p is null)
            {
                throw new ArgumentNullException(nameof(p));
            }

            SqlCommand command = new SqlCommand("INSERT INTO [PROMOTIONS]([code], [title], [detail], [date_start], [date_end], [type], [percent_discount], [discount], [is_stop], [is_hide], [amount]) " +
                "VALUES (@code, @title, @detail, @date_start, @date_end, @type, @percent_discount, @discount, @is_stop, @is_hide, @amount)");
            
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

            if (p.date_start.HasValue)
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

            return General.ConnectDB.AddRecord(command) > 0;
        }

        public static bool Instance(SETTING s)
        {
            if (s is null)
            {
                throw new ArgumentNullException(nameof(s));
            }

            SqlCommand command = new SqlCommand("INSERT INTO [SETTINGS]([name], [value], [account]) " +
                "VALUES (@name, @value, @account)");
            command.Parameters.AddWithValue("@account", s.account);
            command.Parameters.AddWithValue("@name", s.name);

            if (string.IsNullOrEmpty(s.value))
                command.Parameters.AddWithValue("@value", DBNull.Value);
            else
                command.Parameters.AddWithValue("@value", s.value);

            return General.ConnectDB.AddRecord(command) > 1;
        }
    }
}
