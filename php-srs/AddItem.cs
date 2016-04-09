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

            string createTableQuery = "CREATE TABLE MedicineStock (ID int, Name varchar(30), Description varchar(30), Attribute varchar(10), Quantity int)";

            SQLiteCommand createMedicineTable = new SQLiteCommand(createTableQuery, php_srsConnection);
            createMedicineTable.ExecuteNonQuery();

            php_srsConnection.Close();
        }

        public bool CheckIfTableExists()
        {
            var php_srsConnection = new SQLiteConnection("Data Source=php-srs_database.sqlite;Version=3;");
            php_srsConnection.Open();

            string checkTableQuery = "SELECT count(*) FROM sqlite_master WHERE name = 'MedicineStock' and type = 'table'";

            SQLiteCommand checkMedicineTable = new SQLiteCommand(checkTableQuery, php_srsConnection);
            checkMedicineTable.ExecuteNonQuery();

            php_srsConnection.Close();           

            return true;
        }

        public void InsertIntoTable(int id, string name, string description, string attribute, int quantity)
        {
            if (CheckIfTableExists())
            {
                var php_srsConnection = new SQLiteConnection("Data Source=php-srs_database.sqlite;Version=3;");
                php_srsConnection.Open();

                string insertQuery = "INSERT INTO MedicineStock (ID, Name, Description, Attribute, Quantity) VALUES (" + id + ", '" + name + "', '" + description + 
                    "', '" + attribute + ", " + quantity + ")";
                SQLiteCommand insertCommand = new SQLiteCommand(insertQuery, php_srsConnection);
                insertCommand.ExecuteNonQuery();

                php_srsConnection.Close();
            } else {
                CreateTable();
            }


        }


    }
}
