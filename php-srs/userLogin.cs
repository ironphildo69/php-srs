using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;

namespace php_srs
{
    class userLogin
    {

        public static void runUserLogin()
        {
            string defaultUser = "admin";
            string defaultPassword = "passtest";
            string defaultRole = "administrator";

            createUserLoginTable(defaultUser, defaultPassword, defaultRole);

        }

        private static void createUserLoginTable(string name, string password, string role)
        {
            String userLoginTable = "UserLogin";
            var php_srsConnection = new SQLiteConnection("Data Source=php-srs_database.sqlite;Version=3;");
            php_srsConnection.Open();

            string createTableQuery = "CREATE TABLE IF NOT EXISTS " + userLoginTable + " (Name varchar(30) PRIMARY KEY, Password varchar(30), Role varchar(30))";

            SQLiteCommand createUserLoginTable = new SQLiteCommand(createTableQuery, php_srsConnection);
            createUserLoginTable.ExecuteNonQuery();

            string insertQuery = "INSERT INTO " + userLoginTable + " (Name, Password, Role) VALUES ('" + name + "', '" + password + "', '" + role + "')";
            SQLiteCommand insertCommand = new SQLiteCommand(insertQuery, php_srsConnection);
            insertCommand.ExecuteNonQuery();

            php_srsConnection.Close();
        } 

        private static bool userCheckPerms(String username)
        {

            var php_srsConnection = new SQLiteConnection("Data Source=php-srs_database.sqlite;Version=3;");

            php_srsConnection.Open();

            string sqlQuery = "Select from ";
            SQLiteCommand sqlauthcheck = new SQLiteCommand(sqlQuery, php_srsConnection);

            php_srsConnection.Close();

            if (username == sqlQuery)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }


}