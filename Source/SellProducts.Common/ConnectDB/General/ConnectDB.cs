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
        private static SqlConnection connection = null;

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
                connection = new SqlConnection(connectionString);
                connection.Open();
                bool connected = connection.State != System.Data.ConnectionState.Closed;
                connection.Close();
                return connected;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                if (connection != null && connection.State != System.Data.ConnectionState.Closed)
                {
                    connection.Close();
                }
            }
        }

        internal static int AddRecord(SqlCommand sqlCommand)
        {
            int result = -1;

            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();
                sqlCommand.Connection = connection;
                result = sqlCommand.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (connection.State != System.Data.ConnectionState.Closed)
                {
                    connection.Close();
                }
            }

            return result;
        }

        internal static List<Dictionary<string, object>> SelectRecords(SqlCommand sqlCommand)
        {
            List<Dictionary<string, object>> listRecord = new List<Dictionary<string, object>>();

            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();
                sqlCommand.Connection = connection;

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    Dictionary<string, object> keyValues = new Dictionary<string, object>();

                    for (int i = 0; i < sqlDataReader.FieldCount; i++)
                    {
                        string key = sqlDataReader.GetName(i);
                        object value = sqlDataReader.GetValue(i);

                        keyValues.Add(key, value);
                    }

                    listRecord.Add(keyValues);
                }

                connection.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (connection.State != System.Data.ConnectionState.Closed)
                {
                    connection.Close();
                }
            }

            return listRecord;
        }
        internal static int UpdateRecord(SqlCommand sqlCommand)
        {
            int result = -1;
            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();
                sqlCommand.Connection = connection;
                result = sqlCommand.ExecuteNonQuery();
                connection.Close();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (connection.State != System.Data.ConnectionState.Closed)
                {
                    connection.Close();
                }
            }

            return result;
        }

        public static int BackUpDb(string fileBak)
        {
            int result = 0;
            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();

                SqlCommand command = new SqlCommand("BACKUP DATABASE [SellProduct_DB] TO DISK=@pathBak", connection);
                command.Parameters.AddWithValue("@pathBak", fileBak);

                result = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (connection.State != System.Data.ConnectionState.Closed)
                {
                    connection.Close();
                }
            }
            return result;
        }

        [Obsolete]
        public static void Restore(string Filepath)
        {
            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();

                SqlCommand cmd2 = new SqlCommand("ALTER DATABASE [SellProduct_DB] SET SINGLE_USER WITH ROLLBACK IMMEDIATE; " +
                    "RESTORE FILELISTONLY FROM disk = @filepath; " +
                    "USE master; " +
                    "RESTORE DATABASE [SellProduct_DB] FROM DISK=@filepath WITH REPLACE; " +
                    "ALTER DATABASE [SellProduct_DB] SET MULTI_USER; ", connection);
                cmd2.Parameters.Add("@filepath", Filepath);
                cmd2.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (connection.State != System.Data.ConnectionState.Closed)
                {
                    connection.Close();
                }
            }
        }
    }
}
