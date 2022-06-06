using SellProducts.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellProducts.Common.ConnectDB
{
    class Insert
    {
        public bool Instance(ACTION action)
        {
            SqlCommand command = new SqlCommand("INSERT INTO ACTIONS(idref, time, detail, manager) VALUES (@ir,@t,@d,@m)");
            command.Parameters.AddWithValue("@ir", action.idref);
            command.Parameters.AddWithValue("@t", action.time);
            command.Parameters.AddWithValue("@d", action.detail);
            command.Parameters.AddWithValue("@m", action.manager);

            return General.ConnectDB.AddRecord(command) > 1;
        }

        public bool Instance(CART cart)
        {
            SqlCommand command = new SqlCommand("INSERT INTO CARTS(idorder, idproduct, amount, price) VALUES(@io,@ip,@a,@p)");
            command.Parameters.AddWithValue("@io", cart.idorder);
            command.Parameters.AddWithValue("@ip", cart.idproduct);
            command.Parameters.AddWithValue("@a", cart.amount);
            command.Parameters.AddWithValue("@p", cart.price);

            return General.ConnectDB.AddRecord(command) > 1;
        }

        public bool Instance(CATEGORY c)
        {
            if (c is null)
            {
                throw new ArgumentNullException(nameof(c));
            }

            SqlCommand command = new SqlCommand("INSERT INTO CATEGORIES(name, cat_parent, detail) VALUES(@n,@cp,@d)");
            command.Parameters.AddWithValue("@n", c.name);
            command.Parameters.AddWithValue("@cp", c.cat_parent);
            command.Parameters.AddWithValue("@d", c.detail);

            return General.ConnectDB.AddRecord(command) > 1;
        }

        public bool Instance(MANAGER m)
        {
            if (m is null)
            {
                throw new ArgumentNullException(nameof(m));
            }

            SqlCommand command = new SqlCommand("INSERT INTO MANAGERS(account,name,password,phone,email,address,type,is_disable,comment) VALUES (@a,@n,@pw,@p,@e,@ad,@t,@d,@c)");
            command.Parameters.AddWithValue("@a", m.account);
            command.Parameters.AddWithValue("@n", m.name);
            command.Parameters.AddWithValue("@pw", m.password);
            command.Parameters.AddWithValue("@p", m.phone);
            command.Parameters.AddWithValue("@e", m.email);
            command.Parameters.AddWithValue("@ad", m.address);
            command.Parameters.AddWithValue("@t", m.type);
            command.Parameters.AddWithValue("@d", m.is_disable);
            command.Parameters.AddWithValue("@c", m.comment);

            return General.ConnectDB.AddRecord(command) > 1;
        }
    }
}
