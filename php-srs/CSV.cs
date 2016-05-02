using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;

namespace php_srs
{
    class CSV
    {
        public void WriteStockSalesToFile()
        {
            TextWriter tw = new StreamWriter("CSV-StockSales.txt");
            AddSalesRecord asr = new AddSalesRecord();

            tw.WriteLine("PEOPLE HEALTH PHARMACY - SALES REPORTING SYSTEM\n");
            tw.WriteLine("ALL SALES RECORDS\n");
            tw.WriteLine("------------------------------------------------------------------------------------------------------------------------\n");

            var php_srsConnection = new SQLiteConnection("Data Source=php-srs_database.sqlite;Version=3;"); //Prepares the connection to the database
            php_srsConnection.Open();   //Opens the connection

            asr.CreateTable();
                        
            string query = "SELECT * FROM SalesRecords"; //Acquires the SQL SELECT statement from the reference

            SQLiteCommand selectCommand = new SQLiteCommand(query, php_srsConnection);  //Sets up the query to be used with the database
            SQLiteDataReader readResults = selectCommand.ExecuteReader();   //Reads the results of the query into something that can be easily manipulated
            while (readResults.Read())
            {
                tw.WriteLine(readResults["ID"] + ", " + readResults["Item"] + ", " + readResults["Quantity"] + ", " + readResults["Price"] + ", " +
                    readResults["User"] + ", " + readResults["Date"] + ", " + readResults["Time"] + " \n");
            }

            tw.Close();
            php_srsConnection.Close();  //Closes the connection
        }

        public void WriteStockTakeToFile()
        {
            TextWriter tw = new StreamWriter("CSV-StockTake.txt");

            tw.WriteLine("PEOPLE HEALTH PHARMACY - SALES REPORTING SYSTEM\n");
            tw.WriteLine("ALL SALES RECORDS\n");                      
            tw.WriteLine("------------------------------------------------------------------------------------------------------------------------\n");            

            var php_srsConnection = new SQLiteConnection("Data Source=php-srs_database.sqlite;Version=3;"); //Prepares the connection to the database
            php_srsConnection.Open();   //Opens the connection

            string query = "SELECT * FROM StockTable"; //Acquires the SQL SELECT statement from the reference

            SQLiteCommand selectCommand = new SQLiteCommand(query, php_srsConnection);  //Sets up the query to be used with the database
            SQLiteDataReader readResults = selectCommand.ExecuteReader();   //Reads the results of the query into something that can be easily manipulated
            while (readResults.Read())
            {
                tw.WriteLine(readResults["ID"] + ", " + readResults["Name"] + ", " + readResults["Description"] + ", " + readResults["Attribute"] + ", " + 
                    readResults["Quantity"] + ", " + readResults["Price"] + "\n");
            }
            
            tw.Close();
            php_srsConnection.Close();  //Closes the connection            
        }
    }
}
