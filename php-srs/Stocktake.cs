using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;
using System.Data;
using System.Windows.Forms;

namespace php_srs
{
    class StockTake
    {      
        public void SelectFromTable(string selectQuery, DataGridView dataGridStock)
        {
            var php_srsConnection = new SQLiteConnection("Data Source=php-srs_database.sqlite;Version=3;"); //Prepares the connection to the database

            try
            {
                php_srsConnection.Open(); //Opens the connection
                AddItem ai = new AddItem();
                ai.CreateTable();
                DataSet ds = new DataSet();
                var sqliteDA = new SQLiteDataAdapter(selectQuery, php_srsConnection);
                sqliteDA.Fill(ds);
                dataGridStock.DataSource = ds.Tables[0].DefaultView;
            } catch {
                throw;
            }
            php_srsConnection.Close();
        }

        public List<string> GetNameRows(string selectQuery)
        {
            var php_srsConnection = new SQLiteConnection("Data Source=php-srs_database.sqlite;Version=3;"); //Prepares the connection to the database

            List<string> results = new List<string>();        

            php_srsConnection.Open(); //Opens the connection

            AddItem ai = new AddItem();

            ai.CreateTable();

            SQLiteCommand selectCommand = new SQLiteCommand(selectQuery, php_srsConnection);
            SQLiteDataReader readResults = selectCommand.ExecuteReader();

            while (readResults.Read())
            {
                results.Add("" + readResults["Name"]);
            }

            php_srsConnection.Close();

            return results;
        }

        public List<string> GetItemRows(string selectQuery)
        {
            var php_srsConnection = new SQLiteConnection("Data Source=php-srs_database.sqlite;Version=3;"); //Prepares the connection to the database

            List<string> results = new List<string>();

            php_srsConnection.Open(); //Opens the connection

            AddItem ai = new AddItem();

            ai.CreateTable();

            SQLiteCommand selectCommand = new SQLiteCommand(selectQuery, php_srsConnection);
            SQLiteDataReader readResults = selectCommand.ExecuteReader();

            while (readResults.Read())
            {
                results.Add("Item: " + readResults["Name"] + ", Quantity: " + readResults["Quantity"] + ", Price: " + readResults["Price"]);
            }

            php_srsConnection.Close();

            return results;
        }

        public string GetName(string id)
        {
            var php_srsConnection = new SQLiteConnection("Data Source=php-srs_database.sqlite;Version=3;"); //Prepares the connection to the database
            AddItem ai = new AddItem();

            string selectQuery = "SELECT Name FROM StockTable WHERE ID = " + id;
            string name = "";

            php_srsConnection.Open(); //Opens the connection            

            ai.CreateTable();

            SQLiteCommand selectCommand = new SQLiteCommand(selectQuery, php_srsConnection);
            SQLiteDataReader readResults = selectCommand.ExecuteReader();

            while (readResults.Read())
            {
                name = "" + readResults["Name"];
            }

            php_srsConnection.Close();

            return name;
        }

        public double GetPrice(string id)
        {
            var php_srsConnection = new SQLiteConnection("Data Source=php-srs_database.sqlite;Version=3;"); //Prepares the connection to the database
            AddItem ai = new AddItem();
            string selectQuery = "SELECT Price FROM StockTable WHERE ID = " + id;
            double price = 0;

            php_srsConnection.Open(); //Opens the connection           

            ai.CreateTable();

            SQLiteCommand selectCommand = new SQLiteCommand(selectQuery, php_srsConnection);
            SQLiteDataReader readResults = selectCommand.ExecuteReader();

            while (readResults.Read())
            {
                price = (double) readResults["Price"];
            }

            php_srsConnection.Close();

            return price;
        }

        public int GetQuantity(string id)
        {
            var php_srsConnection = new SQLiteConnection("Data Source=php-srs_database.sqlite;Version=3;"); //Prepares the connection to the database
            AddItem ai = new AddItem();
            string selectQuery = "SELECT Quantity FROM StockTable WHERE ID = " + id;
            int quantity = 0;

            php_srsConnection.Open(); //Opens the connection           

            ai.CreateTable();

            SQLiteCommand selectCommand = new SQLiteCommand(selectQuery, php_srsConnection);
            SQLiteDataReader readResults = selectCommand.ExecuteReader();

            while (readResults.Read())
            {
                quantity = (int)readResults["Quantity"];
            }

            php_srsConnection.Close();

            return quantity;
        }        
    }
}
