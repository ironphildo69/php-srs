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
        public void StockTakeMenu()
        {
            Console.Clear();

            Console.WriteLine("***********************************************************");
            Console.WriteLine("*                                                         *");
            Console.WriteLine("*******           PEOPLE HEALTH PHARMACY            *******");
            Console.WriteLine("*******           SALES REPORTING SYSTEM            *******");
            Console.WriteLine("***********************************************************");
            Console.WriteLine("*                                                         *");
            Console.WriteLine("* 1:  View All Stock Items                                *");
            Console.WriteLine("* 2:  View Stock Items Based of ID                        *");
            Console.WriteLine("* 3:  View Stock Items Based of Name                      *");
            Console.WriteLine("* 4:  View Stock Items Based of Attribute                 *");
            Console.WriteLine("* 5:  View Stock Items Based of Quantity                  *");
            Console.WriteLine("* 6:  Back                                                *");
            Console.WriteLine("*                                                         *");
            Console.WriteLine("***********************************************************");
            Console.WriteLine("Please select an option [1 - 6]:  ");

            string selectionStockItems = Console.ReadLine();
            int valueStockItems = 0;

            if (int.TryParse(selectionStockItems, out valueStockItems))
            {
                switch (valueStockItems)
                {
                    case 1:
                        Console.Clear();
                        StockTakeAll();
                        break;

                    case 2:
                        Console.Clear();
                        StockTakeID();
                        break;

                    case 3:
                        Console.Clear();
                        StockTakeName();
                        break;

                    case 4:
                        Console.Clear();
                        StockTakeAttribute();
                        break;

                    case 5:
                        Console.Clear();
                        StockTakeQuantity();
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

        public void SelectFromTable(string selectQuery, DataGridView dataGridStock)
        {
            var php_srsConnection = new SQLiteConnection("Data Source=php-srs_database.sqlite;Version=3;"); //Prepares the connection to the database

            try
            {
                php_srsConnection.Open(); //Opens the connection
                AddItem.CreateTable();
                DataSet ds = new DataSet();
                var sqliteDA = new SQLiteDataAdapter(selectQuery, php_srsConnection);
                sqliteDA.Fill(ds);
                dataGridStock.DataSource = ds.Tables[0].DefaultView;
            } catch {
                throw;
            }
            php_srsConnection.Close();
        }

        public void SelectSpecific()
        {

        }

        public void SelectFromTableCLI(string selectQuery)
        {
            Console.WriteLine("________________________________________________________________________________________________________");
            Console.WriteLine(String.Format("{0,5}|{1,20}|{2,50}|{3,10}|{4,5}", "ID", "Name", "Description", "Attribute", "Quantity")); //Formats the string to look more presentable in the command line.
            Console.WriteLine("________________________________________________________________________________________________________");

            var php_srsConnection = new SQLiteConnection("Data Source=php-srs_database.sqlite;Version=3;"); //Prepares the connection to the database
            php_srsConnection.Open();   //Opens the connection

            AddItem.CreateTable();

            string query = selectQuery; //Acquires the SQL SELECT statement from the reference

            SQLiteCommand selectCommand = new SQLiteCommand(query, php_srsConnection);  //Sets up the query to be used with the database
            SQLiteDataReader readResults = selectCommand.ExecuteReader();   //Reads the results of the query into something that can be easily manipulated

            while (readResults.Read())
                Console.WriteLine(String.Format("{0,5}|{1,20}|{2,50}|{3,10}|{4,5}", readResults["ID"], readResults["Name"], readResults["Description"], readResults["Attribute"], readResults["Quantity"]));

            php_srsConnection.Close();  //Closes the connection

            Console.WriteLine("________________________________________________________________________________________________________");
            Console.WriteLine(" ");
            Console.WriteLine("Press any key to continue . . . ");
            Console.ReadLine();
            Console.Clear();
        }
        
        public void StockTakeAll()
        {
            Console.Clear();
            Console.WriteLine("ALL STOCK: ");
            SelectFromTableCLI("SELECT * FROM StockTable");
        }

        public void StockTakeID()
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
                SelectFromTableCLI("SELECT * FROM StockTable WHERE ID = " + idValue);

            }
            else
            {
                Console.Clear();
                Console.WriteLine("That input is an invalid.");
            }
        }

        public void StockTakeName()
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
            SelectFromTableCLI("SELECT * FROM StockTable WHERE Name = '" + nameValue + "'");
        }

        public void StockTakeAttribute()
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
            SelectFromTableCLI("SELECT * FROM StockTable WHERE Attribute = '" + attrValue + "'");
        }

        public void StockTakeQuantity()
        {
            Console.Clear();
            Console.WriteLine("***********************************************************");
            Console.WriteLine("*                                                         *");
            Console.WriteLine("*******           PEOPLE HEALTH PHARMACY            *******");
            Console.WriteLine("*******           SALES REPORTING SYSTEM            *******");
            Console.WriteLine("***********************************************************");
            Console.WriteLine("*                                                         *");
            Console.WriteLine("Input Qunatity: ");
            string quantityValue = Console.ReadLine();

            Console.Clear();
            Console.WriteLine("QUANTITY SPECIFIED STOCK: ");
            SelectFromTableCLI("SELECT * FROM StockTable WHERE Quantity >= '" + quantityValue + "'");
        }
    }
}
