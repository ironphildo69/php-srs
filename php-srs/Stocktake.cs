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
        public static void SelectFromTable(string selectQuery)
        {
            Console.WriteLine("________________________________________________________________________________________________________");
            Console.WriteLine(String.Format("{0,5}|{1,20}|{2,50}|{3,10}|{4,5}", "ID", "Name", "Description", "Attribute", "Quantity")); //Formats the string to look more presentable in the command line.

            Console.WriteLine("________________________________________________________________________________________________________");

            var php_srsConnection = new SQLiteConnection("Data Source=php-srs_database.sqlite;Version=3;"); //Prepares the connection to the database
            php_srsConnection.Open();   //Opens the connection

            string query = selectQuery; //Acquires the SQL SELECT statement from the reference

            SQLiteCommand selectCommand = new SQLiteCommand(query, php_srsConnection);  //Sets up the query to be used with the database
            SQLiteDataReader readResults = selectCommand.ExecuteReader();   //Reads the results of the query into something that can be easily manipulated
            while (readResults.Read())
                Console.WriteLine(String.Format("{0,5}|{1,20}|{2,50}|{3,10}|{4,5}", readResults["ID"], readResults["Name"], readResults["Description"],
                    readResults["Attribute"], readResults["Quantity"]));

            php_srsConnection.Close();  //Closes the connection

            Console.WriteLine("________________________________________________________________________________________________________");
            Console.WriteLine(" ");
            Console.WriteLine("Press any key to continue . . . ");
            Console.ReadLine();
            Console.Clear();
        }
        
        public static void StockTakeAll()
        {
            Console.Clear();
            Console.WriteLine("ALL STOCK: ");
            SelectFromTable("SELECT * FROM StockTable");
        }

        public static void StockTakeID()
        {
            Console.Clear();
            string idValue = Console.ReadLine();
            int value = 0;

            if (int.TryParse(idValue, out value))
            {
                Console.Clear();
                Console.WriteLine("ID SPECIFIED STOCK: ");
                SelectFromTable("SELECT * FROM StockTable WHERE ID = " + idValue);

            }
            else
            {
                Console.Clear();
                Console.WriteLine("That input is an invalid.");
            }
        }

        public static void StockTakeName()
        {
            Console.Clear();
            string nameValue = Console.ReadLine();

            Console.Clear();
            Console.WriteLine("NAME SPECIFIED STOCK: ");
            SelectFromTable("SELECT * FROM StockTable WHERE Name = '" + nameValue + "'");
        }

        public static void StockTakeAttribute()
        {
            Console.Clear();
            string attrValue = Console.ReadLine();

            Console.Clear();
            Console.WriteLine("ATTRIBUTE SPECIFIED STOCK: ");
            SelectFromTable("SELECT * FROM StockTable WHERE Attribute = '" + attrValue + "'");
        }

        public static void StockTakeQuantity()
        {
            Console.Clear();
            string quantityValue = Console.ReadLine();

            Console.Clear();
            Console.WriteLine("DATE SPECIFIED STOCK: ");
            SelectFromTable("SELECT * FROM StockTable WHERE Quantity = '" + quantityValue + "'");
        }


    }
}
