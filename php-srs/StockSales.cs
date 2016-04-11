using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;

namespace php_srs
{
    class StockSales
    {
        public static void StockSalesMenu()
        {
            Console.Clear();

            Console.WriteLine("***********************************************************");
            Console.WriteLine("*                                                         *");
            Console.WriteLine("*******           PEOPLE HEALTH PHARMACY            *******");
            Console.WriteLine("*******           SALES REPORTING SYSTEM            *******");
            Console.WriteLine("***********************************************************");
            Console.WriteLine("*                                                         *");
            Console.WriteLine("* 1:  View All Stock Sales                                *");
            Console.WriteLine("* 2:  View Stock Sales Based of ID                        *");
            Console.WriteLine("* 3:  View Stock Sales Based of Name                      *");
            Console.WriteLine("* 4:  View Stock Sales Based of Attribute                 *");
            Console.WriteLine("* 5:  View Stock Sales Based of Date                      *");
            Console.WriteLine("* 6:  Back                                                *");
            Console.WriteLine("*                                                         *");
            Console.WriteLine("***********************************************************");
            Console.WriteLine("Please select an option [1 - 6]:  ");

            string selectionStockSales = Console.ReadLine();

            int valueStockSales = 0;

            if (int.TryParse(selectionStockSales, out valueStockSales))
            {
                switch (valueStockSales)
                {
                    case 1:
                        Console.Clear();
                        StockSalesAll();
                        break;

                    case 2:
                        Console.Clear();
                        StockSalesID();
                        break;

                    case 3:
                        Console.Clear();
                        StockSalesName();
                        break;

                    case 4:
                        Console.Clear();
                        StockSalesAttribute();
                        break;

                    case 5:
                        Console.Clear();
                        StockSalesDate();
                        break;

                    default:
                        Console.Clear();
                        break;
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("That input is an invalid.");
            }
        }

        public static void SelectFromTable(string selectQuery)
        {
            Console.WriteLine("_______________________________________________________________________________________________________________________");
            Console.WriteLine(String.Format("{0,5}|{1,20}|{2,50}|{3,10}|{4,10}|{5,10}", "ID", "Name", "Description", "Attribute", "Quantity", "Date")); //Formats the string to look more presentable in the command line.

            Console.WriteLine("_______________________________________________________________________________________________________________________");

            var php_srsConnection = new SQLiteConnection("Data Source=php-srs_database.sqlite;Version=3;"); //Prepares the connection to the database
            php_srsConnection.Open();   //Opens the connection

            string query = selectQuery; //Acquires the SQL SELECT statement from the reference

            SQLiteCommand selectCommand = new SQLiteCommand(query, php_srsConnection);  //Sets up the query to be used with the database
            SQLiteDataReader readResults = selectCommand.ExecuteReader();   //Reads the results of the query into something that can be easily manipulated
            while (readResults.Read())
                Console.WriteLine(String.Format("{0,5}|{1,20}|{2,50}|{3,10}|{4,10}|{5,10}", readResults["ID"], readResults["Name"], readResults["Description"],
                    readResults["Attribute"], readResults["Quantity"], readResults["Date"]));

            php_srsConnection.Close();  //Closes the connection

            Console.WriteLine("_______________________________________________________________________________________________________________________");
            Console.WriteLine(" ");
            Console.WriteLine("Press any key to continue . . . ");
            Console.ReadLine();
            Console.Clear();
        }

        public static void StockSalesAll()
        {
            Console.Clear();
            Console.WriteLine("ALL STOCK: ");
            SelectFromTable("SELECT * FROM SalesRecords");
        }

        public static void StockSalesID()
        {
            Console.Clear();
            Console.WriteLine("***********************************************************");
            Console.WriteLine("*                                                         *");
            Console.WriteLine("*******           PEOPLE HEALTH PHARMACY            *******");
            Console.WriteLine("*******           SALES REPORTING SYSTEM            *******");
            Console.WriteLine("***********************************************************");
            Console.WriteLine("*                                                         *");
            Console.WriteLine("Input ID: ");

            string idValue = Console.ReadLine();
            int value = 0;

            if (int.TryParse(idValue, out value))
            {
                Console.Clear();
                Console.WriteLine("ID SPECIFIED STOCK: ");
                SelectFromTable("SELECT * FROM SalesRecords WHERE" + idValue);

            } else {
                Console.Clear();
                Console.WriteLine("That input is an invalid.");
            }
        }

        public static void StockSalesName()
        {
            Console.Clear();
            Console.WriteLine("***********************************************************");
            Console.WriteLine("*                                                         *");
            Console.WriteLine("*******           PEOPLE HEALTH PHARMACY            *******");
            Console.WriteLine("*******           SALES REPORTING SYSTEM            *******");
            Console.WriteLine("***********************************************************");
            Console.WriteLine("*                                                         *");
            Console.WriteLine("Input Name: ");
            string nameValue = Console.ReadLine();

            Console.Clear();
            Console.WriteLine("NAME SPECIFIED STOCK: ");
            SelectFromTable("SELECT * FROM SalesRecords WHERE Name = '" + nameValue + "'");
        }

        public static void StockSalesAttribute()
        {
            Console.Clear();
            Console.WriteLine("***********************************************************");
            Console.WriteLine("*                                                         *");
            Console.WriteLine("*******           PEOPLE HEALTH PHARMACY            *******");
            Console.WriteLine("*******           SALES REPORTING SYSTEM            *******");
            Console.WriteLine("***********************************************************");
            Console.WriteLine("*                                                         *");
            Console.WriteLine("Input Attribute: ");
            string attrValue = Console.ReadLine();

            Console.Clear();
            Console.WriteLine("ATTRIBUTE SPECIFIED STOCK: ");
            SelectFromTable("SELECT * FROM SalesRecords WHERE Name = '" + attrValue + "'");
        }

        public static void StockSalesDate()
        {
            Console.Clear();
            Console.WriteLine("Unavailable at this time.");

            //Console.WriteLine("Input Date (DD/MM/YYYY): ");
            //string dateValue = Console.ReadLine();
            //Console.Clear();
            //Console.WriteLine("DATE SPECIFIED STOCK: ");
            //SelectFromTable("SELECT * FROM SalesRecords WHERE Name = '" + dateValue + "'");
        }

    }
}
