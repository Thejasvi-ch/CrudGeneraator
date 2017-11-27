using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CrudGenerator
{
    class DataLayer
    {
        DbConnection connection;

        public DbConnection GetConnection(string dataProviderName , string databaseName , bool hasUserAndPassword , string userName , string password)
        {
            string ConnectionString = string.Empty;

            if (dataProviderName == "SQL Server")
            {
                if (hasUserAndPassword)
                {
                    ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + databaseName + ";Integrated Security=True;";
                }
                else
                {
                    ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + databaseName + ";Integrated Security=False;User Id=" + userName + ";Password=" + password + ";";
                }
                connection = new System.Data.SqlClient.SqlConnection(ConnectionString);
            }
            else
            {
                //if (hasUserAndPassword)
                //{
                //    ConnectionString = @"Data Source=;AttachDbFilename=" + databaseName + ";UniCode=True;";
                //}
                //else
                //{
                //    ConnectionString = @"Data Source=DB;AttachDbFilename=" + databaseName + ";Integrated Security=False;User Id=" + userName + ";Password=" + password + ";";
                //}
                //connection = new System.Data.OracleClient.OracleConnection(ConnectionString);

            }
                return connection;
        }

        public string GetShemaList(DbConnection conn , string dbObjectName)
        {
            StringBuilder sbColumnDetails = new StringBuilder();
            try
            {
                conn.Open();
                //conn.GetSchema("Databases");
                DataTable dt = conn.GetSchema("Columns", new string[] { null, null, dbObjectName, null });
                sbColumnDetails.AppendLine(); 
                sbColumnDetails.AppendLine("Column Name - Datatype");
                foreach (DataRow row in dt.Rows)
                {
                    string columnName = row[3].ToString();
                    string dataType = row[7].ToString();
                    sbColumnDetails.Append(columnName + " : ");
                    sbColumnDetails.AppendLine(dataType);

                }

                connection.Close();
                
            }
            catch(Exception ex)
            {
                Console.WriteLine("Please enter valid Database and valid Db object names ");
                    
            }
            return sbColumnDetails.ToString();

        }
    }
}
