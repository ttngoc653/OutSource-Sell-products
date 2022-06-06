using SellProducts.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellProducts.Common.ConnectDB
{
    public class Get
    {
        public IList<ACTION> Actions()
        {
            IList<ACTION> result = new List<ACTION>();

            SqlCommand command = new SqlCommand("select * from ACTIONS");

            IList<Dictionary<string, string>> list = General.ConnectDB.SelectRecords(command);

            foreach (var i in list)
            {
                result.Add(Utils.ConverterUtil.Dictionary2Action(i));
            }

            return result;
        }

        public IList<CART> Carts()
        {
            IList<CART> result = new List<CART>();

            SqlCommand command = new SqlCommand("select * from CARTS");

            IList<Dictionary<string, string>> list = General.ConnectDB.SelectRecords(command);

            foreach (var i in list)
            {
                result.Add(Utils.ConverterUtil.Dictionary2Cart(i));
            }

            return result;
        }

        public IList<CATEGORY> Categories()
        {
            List<CATEGORY> result = new List<CATEGORY>();

            SqlCommand command = new SqlCommand("select * from CATEGORIES");
            IList<Dictionary<string, string>> list = General.ConnectDB.SelectRecords(command);

            foreach (var i in list)
            {
                result.Add(Utils.ConverterUtil.Dictionary2Categoty(i));
            }

            return result;
        }

        public IList<MANAGER> Managers()
        {
            IList<MANAGER> result = new List<MANAGER>();

            SqlCommand command = new SqlCommand("select * from MANAGERS");

            IList<Dictionary<string, string>> list = General.ConnectDB.SelectRecords(command);

            foreach (var iM in list)
            {
                result.Add(Utils.ConverterUtil.Dictionary2Manager(iM));
            }

            return result;
        }

        public CATEGORY GetParentCategory(string name)
        {
            List<CATEGORY> cs = new List<CATEGORY>();

            SqlCommand command = new SqlCommand("select * from CATEGORIES where id in (select c.cat_parent from CATEGORIES where c.name like @na)");
            command.Parameters.AddWithValue("@na", name);

            IList<Dictionary<string, string>> list = General.ConnectDB.SelectRecords(command);

            foreach (var item in list)
            {
                cs.Add(Utils.ConverterUtil.Dictionary2Categoty(item));
            }

            return cs.Count > 0 ? cs.ElementAt(0) : null;
        }

        public MANAGER Login(string username, string password)
        {
            MANAGER result = null;

            SqlCommand command = new SqlCommand("select * from MANAGERS where account like @ac and password like @pa");
            command.Parameters.AddWithValue("@ac", username);
            command.Parameters.AddWithValue("@pa", password);

            IList<Dictionary<string, string>> list = General.ConnectDB.SelectRecords(command);

            foreach (var iM in list)
            {
                result = Utils.ConverterUtil.Dictionary2Manager(iM);
            }

            return result;
        }
    }
}
