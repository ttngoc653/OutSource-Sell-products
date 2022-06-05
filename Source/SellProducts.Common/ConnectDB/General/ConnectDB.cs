using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;

namespace SellProducts.Common.ConnectDB.General
{
    public class ConnectDB
    {
        private static string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\SellProduct_DB.mdf;Integrated Security=True;Connect Timeout=30";

        public static void SetConnectString(string value)
        {
            if (string.IsNullOrEmpty(value) == false)
            {
                connectionString = value;
            }
        }

        public static bool CheckConnect()
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                bool connected = connection.State != System.Data.ConnectionState.Closed;
                connection.Close();
                return connected;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        internal static int AddRecord(SqlCommand sqlCommand)
        {
            int result = -1;

            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            sqlCommand.Connection = connection;
            result = sqlCommand.ExecuteNonQuery();
            connection.Close();

            return result;
        }

        internal static List<Dictionary<String,String>> SelectRecords(SqlCommand sqlCommand)
        {
            List<Dictionary<String, String>> listRecord = new List<Dictionary<String, String>>();

            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            sqlCommand.Connection = connection;

            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            while (sqlDataReader.Read())
            {
                Dictionary<string, string> keyValues = new Dictionary<string, string>();

                for (int i = 0; i < sqlDataReader.FieldCount; i++)
                {
                    string key = sqlDataReader.GetName(i);
                    string value = sqlDataReader.GetValue(i).ToString();

                    keyValues.Add(key, value);
                }

                listRecord.Add(keyValues);
            }

            connection.Close();

            return listRecord;
        }

        internal static int UpdateRecord(SqlCommand sqlCommand)
        {
            int result = -1;

            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            sqlCommand.Connection = connection;
            result = sqlCommand.ExecuteNonQuery();
            connection.Close();

            return result;
        }
    }
}
