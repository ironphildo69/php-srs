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

        public static void CreateTable()
        {
            var php_srsConnection = new SQLiteConnection("Data Source=php-srs_database.sqlite;Version=3;");
            php_srsConnection.Open();

            string createTableQuery = "CREATE TABLE IF NOT EXISTS MedicineStock (ID int, Name varchar(30), Description varchar(30), Attribute varchar(10), Quantity int)";

            SQLiteCommand createMedicineTable = new SQLiteCommand(createTableQuery, php_srsConnection);
            createMedicineTable.ExecuteNonQuery();

            php_srsConnection.Close();
        }

        public static bool CheckIfTableExists()
        {

            return true;
        }

        public static void InsertIntoTable(int id, string name, string description, string attribute, int quantity)
        {
                
            var php_srsConnection = new SQLiteConnection("Data Source=php-srs_database.sqlite;Version=3;");
            php_srsConnection.Open();

            CreateTable();

            string insertQuery = "INSERT INTO MedicineStock (ID, Name, Description, Attribute, Quantity) VALUES (" + id + ", '" + name + "', '" + description + 
                "', '" + attribute + "', " + quantity + ")";
            SQLiteCommand insertCommand = new SQLiteCommand(insertQuery, php_srsConnection);
            insertCommand.ExecuteNonQuery();

            php_srsConnection.Close();
        }
    }
}
