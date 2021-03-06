﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;

namespace php_srs
{
    class AddSalesRecord
    {
        public void CreateTable()
        {
            var php_srsConnection = new SQLiteConnection("Data Source=php-srs_database.sqlite;Version=3;");
            php_srsConnection.Open();
            
            string createTableQuery = "CREATE TABLE IF NOT EXISTS SalesRecords (ID INTEGER PRIMARY KEY, Item varchar(20), Quantity int, Price real, User varchar(20), Date varchar(10), Time varchar(10))";

            SQLiteCommand createMedicineTable = new SQLiteCommand(createTableQuery, php_srsConnection);
            createMedicineTable.ExecuteNonQuery();

            php_srsConnection.Close();  
        }       

        public void InsertIntoTable(string item, int quantity, double price, string user, string date, string time)
        {
            var php_srsConnection = new SQLiteConnection("Data Source=php-srs_database.sqlite;Version=3;");
            php_srsConnection.Open();

            CreateTable();            

            string insertQuery = "INSERT INTO SalesRecords (Item, Quantity, Price, User, Date, Time) VALUES ('" + item + "', " + quantity + ", " + price + ", '" + user + "', '" + date + "', '" + time + "')";
            SQLiteCommand insertCommand = new SQLiteCommand(insertQuery, php_srsConnection);
            insertCommand.ExecuteNonQuery();

            php_srsConnection.Close();
        }
    }
}
