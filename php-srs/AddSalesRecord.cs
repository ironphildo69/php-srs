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

            string createTableQuery = "CREATE TABLE IF NOT EXISTS SalesRecords (ID int, Name varchar(30), Description varchar(30), Attribute varchar(10), Quantity int, Date varchar (10))";

            SQLiteCommand createMedicineTable = new SQLiteCommand(createTableQuery, php_srsConnection);
            createMedicineTable.ExecuteNonQuery();

            php_srsConnection.Close();
        }

        public static bool CheckIfTableExists()
        {

            return true;
        }

        public static void InsertIntoTable(int id, string name, string description, string attribute, int quantity, string date)
        {

            var php_srsConnection = new SQLiteConnection("Data Source=php-srs_database.sqlite;Version=3;");
            php_srsConnection.Open();

            CreateTable();

            string insertQuery = "INSERT INTO SalesRecords (ID, Name, Description, Attribute, Quantity) VALUES (" + id + ", '" + name + "', '" + description +
                "', '" + attribute + "', " + quantity + ", '" + date + "')";
            SQLiteCommand insertCommand = new SQLiteCommand(insertQuery, php_srsConnection);
            insertCommand.ExecuteNonQuery();

            php_srsConnection.Close();
        }

        public static void AddSalesRecords()
        {
            Console.WriteLine("ID: ");
            2int responseID = int.Parse(Console.ReadLine());

            Console.WriteLine("Name: ");
            string responseName = Console.ReadLine();

            Console.WriteLine("Description: ");
            string responseDescription = Console.ReadLine();

            Console.WriteLine("Attribute: ");
            string responseAttribute = Console.ReadLine();

            Console.WriteLine("Quantity: ");
            int responseQuantity = int.Parse(Console.ReadLine());

            DateTime date = DateTime.Today;

            InsertIntoTable(responseID, responseName, responseDescription, responseAttribute, responseQuantity, date.ToString("D"));

            Console.WriteLine("The information has been added to the database.");
            Console.Clear();
        }

    }
}
