using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;
using php_srs;

namespace php_srs
{
    class UserLogin
    {   
        //Runs query to check if provided ID matchs whats in the database.
        public bool checkUserLoginTable(string username, string password)
        {
            var php_srsConnection = new SQLiteConnection("Data Source=php-srs_database.sqlite;Version=3;"); //Prepares the connection to the database
            
            php_srsConnection.Open();   //Opens the connection

            UserLogin ul = new UserLogin();
            ul.createUserLoginTable();

            //string query = "SELECT * FROM UserLogin"; //Acquires the SQL SELECT statement from the reference
            //string sqlStatement = "SELECT * FROM UserLogin WHERE Name = '" + username + "' AND Password = '" + password + "'";

            string sqlStatement = "SELECT COUNT(*) FROM UserLogin WHERE Name = '" + username + "' AND Password = '" + password + "'";

            SQLiteCommand selectCommand = new SQLiteCommand(sqlStatement, php_srsConnection);

            //SQLiteDataReader readResults = selectCommand.ExecuteReader();

            int readResults = System.Convert.ToInt32(selectCommand.ExecuteScalar());

            //string adminCheck = (string) readResults["Name"] + (string) readResults["Password"];
            //Console.Write(adminCheck + "\n"); //Debug

            //while (readResults.Read())
            //{
            //    user = "" + readResults["Name"];
            //    pass = "" + readResults["Password"];
            //}
            
            php_srsConnection.Close();

            if (readResults == 1)
            {
                return true;
            } else {
                return false;
            }
        }

        //creates the table and if it exists should update the default credientials incase they have changed.
        public void createUserLoginTable()
        {
            //All this needs refactoring
            string defaultUser = "admin";
            string defaultPassword = "admin";
            string defaultRole = "administrator";
            string userLoginTable = "UserLogin";
            
            var php_srsConnection = new SQLiteConnection("Data Source=php-srs_database.sqlite;Version=3;");
            php_srsConnection.Open();

            string createTableQuery = "CREATE TABLE IF NOT EXISTS " + userLoginTable + " (Name varchar(30) PRIMARY KEY, Password varchar(30), Role varchar(30))";

            SQLiteCommand createUserLoginTable = new SQLiteCommand(createTableQuery, php_srsConnection);
            createUserLoginTable.ExecuteNonQuery();

            //string updateQuery = "UPDATE UserLogin SET (Name, Password, Role) VALUES ('" + defaultUser + "', '" + defaultPassword + "', '" + defaultRole + "') WHERE Name='" + defaultUser + "'";
            string insertQuery = "INSERT INTO UserLogin (Name, Password, Role) VALUES ('" + defaultUser + "', '" + defaultPassword + "', '" + defaultRole + "')";
            SQLiteCommand insertCommand = new SQLiteCommand(insertQuery, php_srsConnection);
            //insertCommand.ExecuteNonQuery();

            php_srsConnection.Close();
        } 

        //checks user permisions level and loads this in. Unfinished.
        public bool userCheckPerms(String username)
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