using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;

namespace php_srs
{
    class AddItem
    {
        public void CreateTable()
        {
            var php_srsConnection = new SQLiteConnection("Data Source=php-srs_database.sqlite;Version=3;");
            php_srsConnection.Open();

            string createTableQuery = "CREATE TABLE IF NOT EXISTS StockTable (ID INTEGER PRIMARY KEY, Name varchar(30), Description varchar(30), Attribute varchar(10), Quantity int, Price real)";

            SQLiteCommand createMedicineTable = new SQLiteCommand(createTableQuery, php_srsConnection);
            createMedicineTable.ExecuteNonQuery();

            php_srsConnection.Close();
        }

        public void InsertIntoTable(string name, string description, string attribute, int quantity, double price)
        {
            var php_srsConnection = new SQLiteConnection("Data Source=php-srs_database.sqlite;Version=3;");
            php_srsConnection.Open();

            CreateTable();

            string insertQuery = "INSERT INTO StockTable (Name, Description, Attribute, Quantity, Price) VALUES ('" + name + "', '" + description + "', '" + attribute + "', " + quantity + ", " + price + ")";
            SQLiteCommand insertCommand = new SQLiteCommand(insertQuery, php_srsConnection);
            insertCommand.ExecuteNonQuery();

            php_srsConnection.Close();
        }

        public void UpdateTableByName(string name, int quantity, int minusCheck)
        {
            var php_srsConnection = new SQLiteConnection("Data Source=php-srs_database.sqlite;Version=3;");
            int newQty = 0;
            string qty = "";
            string selectQuery = "SELECT Name, Quantity FROM StockTable WHERE Name = '" + name + "'";

            php_srsConnection.Open();

            CreateTable();
            
            SQLiteCommand selectCommand = new SQLiteCommand(selectQuery, php_srsConnection);
            SQLiteDataReader rdr = selectCommand.ExecuteReader();

            while (rdr.Read())
            {
                newQty = (int) rdr["Quantity"];
            }

            if (minusCheck == 0)
            {
                newQty += quantity;
            } else {
                newQty -= quantity;
            }

            string updateQuery = "UPDATE StockTable SET Quantity = " + newQty + " WHERE Name = '" + name + "'";

            SQLiteCommand insertCommand = new SQLiteCommand(updateQuery, php_srsConnection);
            insertCommand.ExecuteNonQuery();

            php_srsConnection.Close();
        }        

        public void InsertIntoTableCLI(string name, string description, string attribute, int quantity)
        {                
            var php_srsConnection = new SQLiteConnection("Data Source=php-srs_database.sqlite;Version=3;");
            php_srsConnection.Open();

            CreateTable();

            string insertQuery = "INSERT INTO StockTable (Name, Description, Attribute, Quantity) VALUES ('" + name + "', '" + description + 
                "', '" + attribute + "', " + quantity + ")";
            SQLiteCommand insertCommand = new SQLiteCommand(insertQuery, php_srsConnection);
            insertCommand.ExecuteNonQuery();

            php_srsConnection.Close();
        }

        public void AddStock()
        {            
            //Console.WriteLine("ID: ");
            //int responseID = int.Parse(Console.ReadLine());

            Console.WriteLine("Name: ");
            string responseName = Console.ReadLine();

            Console.Write("Description: ");
            string responseDescription = Console.ReadLine();

            Console.Write("Attribute: ");
            string responseAttribute = Console.ReadLine();

            Console.Write("Quantity: ");
            int responseQuantity = int.Parse(Console.ReadLine());

            InsertIntoTableCLI(responseName, responseDescription, responseAttribute, responseQuantity);

            Console.WriteLine("The information has been added to the database.");
            Console.Clear();
        }

    }
}
