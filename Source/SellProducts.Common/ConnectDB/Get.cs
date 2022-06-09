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

            IList<Dictionary<string, object>> list = General.ConnectDB.SelectRecords(command);

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

            IList<Dictionary<string, object>> list = General.ConnectDB.SelectRecords(command);

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
            IList<Dictionary<string, object>> list = General.ConnectDB.SelectRecords(command);

            foreach (var i in list)
            {
                result.Add(Utils.ConverterUtil.Dictionary2Categoty(i));
            }

            return result;
        }

        public IList<CLASSIFY> Classifies()
        {
            List<CLASSIFY> result = new List<CLASSIFY>();

            SqlCommand command = new SqlCommand("select * from CLASSIFIES");
            IList<Dictionary<string, object>> list = General.ConnectDB.SelectRecords(command);

            foreach (var i in list)
            {
                result.Add(Utils.ConverterUtil.Dictionary2Classify(i));
            }

            return result;
        }

        public IList<CUSTOMER> Customers()
        {
            List<CUSTOMER> result = new List<CUSTOMER>();

            SqlCommand command = new SqlCommand("select * from CUSTOMERS");
            IList<Dictionary<string, object>> list = General.ConnectDB.SelectRecords(command);

            foreach (var i in list)
            {
                result.Add(Utils.ConverterUtil.Dictionary2Customer(i));
            }

            return result;
        }

        public IList<HISTORY> Histories()
        {
            List<HISTORY> result = new List<HISTORY>();

            SqlCommand command = new SqlCommand("select * from HISTORIES");
            IList<Dictionary<string, object>> list = General.ConnectDB.SelectRecords(command);

            foreach (var i in list)
            {
                result.Add(Utils.ConverterUtil.Dictionary2History(i));
            }

            return result;
        }

        public IList<MADEIN> Madeins()
        {
            List<MADEIN> result = new List<MADEIN>();

            SqlCommand command = new SqlCommand("select * from MADEINS");
            IList<Dictionary<string, object>> list = General.ConnectDB.SelectRecords(command);

            foreach (var i in list)
            {
                result.Add(Utils.ConverterUtil.Dictionary2MadeIn(i));
            }

            return result;
        }

        public IList<MANAGER> Managers()
        {
            IList<MANAGER> result = new List<MANAGER>();

            SqlCommand command = new SqlCommand("select * from MANAGERS");

            IList<Dictionary<string, object>> list = General.ConnectDB.SelectRecords(command);

            foreach (var iM in list)
            {
                result.Add(Utils.ConverterUtil.Dictionary2Manager(iM));
            }

            return result;
        }

        public IList<MANUFACTURER> Manufactureres()
        {
            IList<MANUFACTURER> result = new List<MANUFACTURER>();

            SqlCommand command = new SqlCommand("select * from MANUFACTURERES");

            IList<Dictionary<string, object>> list = General.ConnectDB.SelectRecords(command);

            foreach (var iM in list)
            {
                result.Add(Utils.ConverterUtil.Dictionary2Manufacturer(iM));
            }

            return result;
        }

        public IList<ORDER> Orders()
        {
            IList<ORDER> result = new List<ORDER>();

            SqlCommand command = new SqlCommand("select * from ORDERS");

            IList<Dictionary<string, object>> list = General.ConnectDB.SelectRecords(command);

            foreach (var iM in list)
            {
                result.Add(Utils.ConverterUtil.Dictionary2Order(iM));
            }

            return result;
        }

        public IList<PRODUCT> Products()
        {
            IList<PRODUCT> result = new List<PRODUCT>();

            SqlCommand command = new SqlCommand("select * from PRODUCTS");

            IList<Dictionary<string, object>> list = General.ConnectDB.SelectRecords(command);

            foreach (var iM in list)
            {
                result.Add(Utils.ConverterUtil.Dictionary2Product(iM));
            }

            return result;
        }

        public IList<PROMOTION> Promotions()
        {
            IList<PROMOTION> result = new List<PROMOTION>();

            SqlCommand command = new SqlCommand("select * from PROMOTIONS");

            IList<Dictionary<string, object>> list = General.ConnectDB.SelectRecords(command);

            foreach (var i in list)
            {
                result.Add(Utils.ConverterUtil.Dictionary2Promotion(i));
            }

            return result;
        }

        public IList<SETTING> Settings()
        {
            IList<SETTING> result = new List<SETTING>();

            SqlCommand command = new SqlCommand("select * from SETTINGS");

            IList<Dictionary<string, object>> list = General.ConnectDB.SelectRecords(command);

            foreach (var i in list)
            {
                result.Add(Utils.ConverterUtil.Dictionary2Setting(i));
            }

            return result;
        }

        public CATEGORY GetParentCategory(string name)
        {
            List<CATEGORY> cs = new List<CATEGORY>();

            SqlCommand command = new SqlCommand("select * from CATEGORIES where id in (select c.cat_parent from CATEGORIES where c.name like @na)");
            command.Parameters.AddWithValue("@na", name);

            IList<Dictionary<string, object>> list = General.ConnectDB.SelectRecords(command);

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

            IList<Dictionary<string, object>> list = General.ConnectDB.SelectRecords(command);

            foreach (var iM in list)
            {
                result = Utils.ConverterUtil.Dictionary2Manager(iM);
            }

            return result;
        }
    }
}
