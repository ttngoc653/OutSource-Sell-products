using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellProducts.Common.ConnectDB
{
    class Modify
    {
        public int ChangePassword(string username, string oldPassword, string newPassword)
        {
            SqlCommand command = new SqlCommand("update MANAGERS set password = @newPa where account like @ac and password like @oldPa");
            command.Parameters.AddWithValue("@newPa", newPassword);
            command.Parameters.AddWithValue("@ac", username);
            command.Parameters.AddWithValue("@oldPa", oldPassword);

            return General.ConnectDB.UpdateRecord(command);
        }
    }
}
