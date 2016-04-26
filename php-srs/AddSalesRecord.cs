using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;

namespace php_srs
{
    class AddSalesRecord
    {

        public static void CreateTable()
        {
            var php_srsConnection = new SQLiteConnection("Data Source=php-srs_database.sqlite;Version=3;");
            php_srsConnection.Open();
            
            string createTableQuery = "CREATE TABLE IF NOT EXISTS SalesRecords (ID INTEGER PRIMARY KEY, Name varchar(30), Description varchar(30), Attribute varchar(10), Quantity int, Date DATETIME DEFAULT CURRENT_TIMESTAMP)";

            SQLiteCommand createMedicineTable = new SQLiteCommand(createTableQuery, php_srsConnection);
            createMedicineTable.ExecuteNonQuery();

            php_srsConnection.Close();  
        }

        public static bool CheckIfTableExists()
        {

            return true;
        }

        public static void InsertIntoTable(string name, string description, string attribute, int quantity)
        {

            var php_srsConnection = new SQLiteConnection("Data Source=php-srs_database.sqlite;Version=3;");
            php_srsConnection.Open();

            CreateTable();

            string insertQuery = "INSERT INTO SalesRecords (Name, Description, Attribute, Quantity) VALUES ('" + name + "', '" + description +
                "', '" + attribute + "', " + quantity + ")";
            SQLiteCommand insertCommand = new SQLiteCommand(insertQuery, php_srsConnection);
            insertCommand.ExecuteNonQuery();

            php_srsConnection.Close();
        }

        public static void AddSalesRecords()
        {
            //Console.WriteLine("ID: ");
            //int responseID = int.Parse(Console.ReadLine());
            Console.WriteLine(" ");
            Console.WriteLine("***********************************************************");
            Console.WriteLine("*                                                         *");
            Console.WriteLine("*******           PEOPLE HEALTH PHARMACY            *******");
            Console.WriteLine("*******           SALES REPORTING SYSTEM            *******");
            Console.WriteLine("***********************************************************");

            Console.Write("Name: ");
            string responseName = Console.ReadLine();

            Console.Write("Description: ");
            string responseDescription = Console.ReadLine();

            Console.Write("Attribute: ");
            string responseAttribute = Console.ReadLine();

            Console.Write("Quantity: ");
            int responseQuantity = int.Parse(Console.ReadLine());

            InsertIntoTable(responseName, responseDescription, responseAttribute, responseQuantity);

            Console.WriteLine("The information has been added to the database.");
            Console.Clear();
        }

    }
}
