using SellProducts.Model.Demo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellProducts.Common.ConnectDB
{
    public class Manager
    {
        public MANAGER Get(string username, string password)
        {
            MANAGER result = null;

            SqlCommand command = new SqlCommand("select * from MANAGERS where account like @ac and password like @pa");
            command.Parameters.AddWithValue("@ac", username);
            command.Parameters.AddWithValue("@pa", password);

            IList<Dictionary<string,string>> list = General.ConnectDB.SelectRecords(command);

            foreach (var iM in list)
            {
                result = FromDictionary(iM);
            }

            return result;
        }

        private MANAGER FromDictionary(Dictionary<string,string> keyValues)
        {
            MANAGER result = new MANAGER();

            result.account = keyValues["account"];
            result.address = keyValues["address"];
            result.comment = keyValues["comment"];
            result.email = keyValues["email"];
            result.is_disable = Boolean.Parse(keyValues["is_disable"]);
            result.name = keyValues["name"];
            result.password = keyValues["password"];
            result.phone = keyValues["phone"];
            result.type = keyValues["type"];

            return result;
        }
    }
}
