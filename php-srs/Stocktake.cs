using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;

namespace php_srs
{
    class StockTake
    {
        public static void CheckIfTableExists()
        {

        }

        public static void SelectFromTable()
        {
            var php_srsConnection = new SQLiteConnection("Data Source=php-srs_database.sqlite;Version=3;");
            php_srsConnection.Open();

            string selectQuery = "SELECT * FROM MedicineStock";
            SQLiteCommand selectCommand = new SQLiteCommand(selectQuery, php_srsConnection);
            SQLiteDataReader readResults = selectCommand.ExecuteReader();
            while (readResults.Read())
                Console.WriteLine("ID: " + readResults["ID"] + "\tName: " + readResults["Name"] + "\tDescription: " + 
                    readResults["Description"] + "\tAttribute: " + readResults["Attribute"] + "\tQuantity: " + readResults["Quantity"]);

            php_srsConnection.Close();
        }

    }
}
