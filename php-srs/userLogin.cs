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
    class userLogin
    {
        //Initalises Login Code Methods, all code for logins should be initialised here.
        public static void runUserLogin()
        {
            Console.WriteLine("Please Enter your Username:");
            string username = Console.ReadLine();
            Console.WriteLine("Please Enter your Password:");
            string password = Console.ReadLine();


            if (checkUserLoginTable(username, password) == true)
            {
                Console.WriteLine("Successfully Authenticated!");
            }
            else
            {
                Console.WriteLine("Your Login Details are incorrect. Please Contact your System Administrator for more Details.");
            }
        
        }
        //Runs query to check if provided ID matchs whats in the database.
        private static bool checkUserLoginTable(string username, string password)
        {
            String sqlStatement = "Select * from UserLogin Where Name='" + username + "' AND Password='" + password + "'";
            SQLiteDataReader readResults = Program.phpsrsDBQuery(sqlStatement);
            while (readResults.Read())
                Console.WriteLine(readResults);

            string userCheck = readResults.ToString();
            //string adminCheck = readResults["Name"];
            //Console.Write(readResults["Name"]); //Debug

            if (userCheck == username + password)
            {
                Console.WriteLine("Success!");
                //Console.Write(readResults["Name"]); //More Debug
                return true;
            }
            else
            {
                return false;
            }

        }
        //creates the table and if it exists should update the default credientials incase they have changed.
        public static void createUserLoginTable()
        {
            //All this needs refactoring
            string defaultUser = "admin";
            string defaultPassword = "passtest";
            string defaultRole = "administrator";
            string userLoginTable = "UserLogin";
            
            var php_srsConnection = new SQLiteConnection("Data Source=php-srs_database.sqlite;Version=3;");
            php_srsConnection.Open();

            string createTableQuery = "CREATE TABLE IF NOT EXISTS " + userLoginTable + " (Name varchar(30) PRIMARY KEY, Password varchar(30), Role varchar(30))";

            SQLiteCommand createUserLoginTable = new SQLiteCommand(createTableQuery, php_srsConnection);
            createUserLoginTable.ExecuteNonQuery();

            string insertQuery = "UPDATE " + userLoginTable + " SET (Name, Password, Role) VALUES ('" + defaultUser + "', '" + defaultPassword + "', '" + defaultRole + "') WHERE Name='" + defaultUser + "'";
            SQLiteCommand insertCommand = new SQLiteCommand(insertQuery, php_srsConnection);
            //insertCommand.ExecuteNonQuery();

            php_srsConnection.Close();
        } 

        //checks user permisions level and loads this in. Unfinished.
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