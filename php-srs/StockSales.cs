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
    class StockSales
    {
        public void SelectFromTable(string selectQuery, DataGridView dataGridStock)
        {
            var php_srsConnection = new SQLiteConnection("Data Source=php-srs_database.sqlite;Version=3;"); //Prepares the connection to the database
            string query = selectQuery; //Acquires the SQL SELECT statement from the reference

            try
            {
                php_srsConnection.Open(); //Opens the connection

                AddSalesRecord asr = new AddSalesRecord();
                asr.CreateTable();

                DataSet ds = new DataSet();
                var sqliteDA = new SQLiteDataAdapter(selectQuery, php_srsConnection);

                sqliteDA.Fill(ds);
                dataGridStock.DataSource = ds.Tables[0].DefaultView;
            } catch {
                throw;
            }
            
            php_srsConnection.Close();  //Closes the connection
        }
    }
}
