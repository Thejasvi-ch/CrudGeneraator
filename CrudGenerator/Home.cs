using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudGenerator
{

    class Home
    {
        #region Constants
        private const string SQL_INSTANCE = "SQL Server";
        private const string ORACLE_INSTANCE = "Oracle Server";
        #endregion
        public void GetColumnListForSpecifiedObject()
        {
            Console.WriteLine("Please select the server Instance of your Database");
            Console.WriteLine("1. Sql Server");
            Console.WriteLine("2. Oracle Server");
            Console.WriteLine("Please enter 1 or 2");
            string serverInstanceValue = Console.ReadLine().ToString();
            Console.WriteLine("Enter Database name(please enter along with location)");
            string dbName = Console.ReadLine().ToString();
            Console.WriteLine("Enter Table or View name");
            string dbObjName = Console.ReadLine().ToString().ToUpper();
            // Test Db
            // D:\Projects\CrudGenerator\CrudGenerator\Rego.mdf
            Console.WriteLine("Do you have User Name and Password ? Press Y or N");
            bool hasUserAndPwd = true;
            string userName = string.Empty;
            string password = string.Empty;
            string UserAndPwd = Console.Read().ToString();
            if (UserAndPwd == "Y" ||  UserAndPwd == "y")
            {
                hasUserAndPwd = true;
                Console.WriteLine("Enter UserName");
                userName = Console.ReadLine().ToString();
                Console.WriteLine("Enter Password");
                password = Console.ReadLine().ToString();
            }
            else if (UserAndPwd == "N" || UserAndPwd == "n")
            {
                hasUserAndPwd = false;
            }

            if (serverInstanceValue == "1")
            {
                DataLayer dl = new DataLayer();
                Console.WriteLine(dl.GetShemaList(dl.GetConnection(SQL_INSTANCE, dbName , hasUserAndPwd , userName , password) , dbObjName));
            }
            else if (serverInstanceValue == "2")
            {
                // for oracle instance
                DataLayer dl = new DataLayer();
                Console.WriteLine(dl.GetShemaList(dl.GetConnection(ORACLE_INSTANCE, dbName ,hasUserAndPwd, userName, password), dbObjName));
            }
            else
            {
                Console.WriteLine("please enter valid inputs");
            }
        }
    }
}
