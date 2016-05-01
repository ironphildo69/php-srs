using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;

namespace php_srs
{
    class Report
    {
        private void saleReport()
        {
            TextWriter tw = new StreamWriter("StockSales-Report.txt");
            double total = 0.0;

            tw.WriteLine("PEOPLE HEALTH PHARMACY - SALES REPORTING SYSTEM\n");
            tw.WriteLine("SALES RECORDS REPORT\n");
            tw.WriteLine("------------------------------------------------------------------------------------------------------------------------\n");

            var php_srsConnection = new SQLiteConnection("Data Source=php-srs_database.sqlite;Version=3;"); //Prepares the connection to the database
            php_srsConnection.Open();   //Opens the connection

            string query = "SELECT * FROM SalesRecords"; //Acquires the SQL SELECT statement from the reference

            SQLiteCommand selectCommand = new SQLiteCommand(query, php_srsConnection);  //Sets up the query to be used with the database
            SQLiteDataReader readResults = selectCommand.ExecuteReader();   //Reads the results of the query into something that can be easily manipulated
            while (readResults.Read())
            {
                tw.WriteLine(readResults["ID"] + ", " + readResults["Name"] + ", " + readResults["Description"] + ", " + readResults["Attribute"] + ", " +
                    readResults["Quantity"] + ", " + readResults["Date"] + "\n");
                total = total + (double) readResults["Price"];
            }

            tw.WriteLine("Total Sales to Date: " + total + "\n");
            tw.Close();
            php_srsConnection.Close();  //Closes the connection
        }
    }
}
