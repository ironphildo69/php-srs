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
        public static bool CheckIfTableExists()
        {

            return true;
        }

        public static void SelectAllFromTable()
        {
            Console.Clear();
            Console.WriteLine("______________________________________________________________________________________");
            Console.WriteLine(String.Format("{0,5}|{1,20}|{2,30}|{3,10}|{4,5}", "ID", "Name", "Description", "Attribute", "Quantity"));    

            var php_srsConnection = new SQLiteConnection("Data Source=php-srs_database.sqlite;Version=3;");
            php_srsConnection.Open();

            string selectQuery = "SELECT * FROM MedicineStock";
            SQLiteCommand selectCommand = new SQLiteCommand(selectQuery, php_srsConnection);
            SQLiteDataReader readResults = selectCommand.ExecuteReader();
            while (readResults.Read())
                Console.WriteLine(String.Format("{0,5}|{1,20}|{2,30}|{3,10}|{4,5}", readResults["ID"], readResults["Name"], readResults["Description"],
                    readResults["Attribute"], readResults["Quantity"]));

            php_srsConnection.Close();

            Console.WriteLine("______________________________________________________________________________________");
            Console.WriteLine(" ");
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
            Console.Clear();
        }

    }
}
