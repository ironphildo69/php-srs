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

        public static void SelectFromTable(string selectQuery)
        {
            Console.WriteLine("______________________________________________________________________________________");
            Console.WriteLine(String.Format("{0,5}|{1,20}|{2,50}|{3,10}|{4,5}", "ID", "Name", "Description", "Attribute", "Quantity"));
            
            var php_srsConnection = new SQLiteConnection("Data Source=php-srs_database.sqlite;Version=3;");
            php_srsConnection.Open();

            string query = selectQuery;

            SQLiteCommand selectCommand = new SQLiteCommand(query, php_srsConnection);
            SQLiteDataReader readResults = selectCommand.ExecuteReader();
            while (readResults.Read())
                Console.WriteLine(String.Format("{0,5}|{1,20}|{2,50}|{3,10}|{4,5}", readResults["ID"], readResults["Name"], readResults["Description"],
                    readResults["Attribute"], readResults["Quantity"]));

            php_srsConnection.Close();

            Console.WriteLine("______________________________________________________________________________________");
            Console.WriteLine(" ");
            Console.WriteLine("Press any key to continue . . . ");
            Console.ReadLine();
            Console.Clear();
        }

        public static void CheckingFunction()
        {
            Console.WriteLine("Are you looking for anything in particular? (Y/N)");
            string input = Console.ReadLine();
            switch (input)
            {
                case "y":
                    Console.Clear();
                    Console.WriteLine("Input a keyword: ");
                    Console.ReadLine();

                    SelectFromTable("SELECT * FROM MedicineStock");
                    break;

                case "n":
                    Console.Clear();
                    Console.WriteLine("ALL STOCK: ");
                    SelectFromTable("SELECT * FROM MedicineStock");
                    break;

                default:
                    Console.WriteLine("That is not a valid input.");
                    break;

            }       
        }
    }
}
