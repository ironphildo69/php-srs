using System;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;

namespace php_srs
{
    class Program
    {
        //Database creation logic, checks if file exists.
        public static bool createDatabase()
        {
            if (File.Exists("php-srs_database.sqlite"))
            {
                //Console.WriteLine("Database successfully located.");
            }
            else
            {
                //Put Table Creation Here + other database operations
                SQLiteConnection.CreateFile("php-srs_database.sqlite");
                userLogin.createUserLoginTable();

            }
            return true;
        }        

        //Global Query String for PHP-SRS Database
        public static SQLiteDataReader phpsrsDBQuery(string sqlStatement)
        {
            var php_srsConnection = new SQLiteConnection("Data Source=php-srs_database.sqlite;Version=3;");
            php_srsConnection.Open();

            SQLiteCommand sqlQuery = new SQLiteCommand(sqlStatement, php_srsConnection);

            SQLiteDataReader readResults = sqlQuery.ExecuteReader();

            string userName;
            string pass;

            while (readResults.Read())
            {
                //readResults["Name"] = userName;
                //readResults["Password"] = pass;

            }
            
            //test strings against input

            php_srsConnection.Close();

            return readResults;

        }
        
        public static void Main(string[] args)
        {
            //Pre initalisation logic

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Window());

            createDatabase();
            //userLogin.runUserLogin();

            int value = 0;

            //Menu selection loop
            while (value != 7)
            {
                Console.WriteLine(" ");
                Console.WriteLine("***********************************************************");
                Console.WriteLine("*                                                         *");
                Console.WriteLine("*******           PEOPLE HEALTH PHARMACY            *******");
                Console.WriteLine("*******           SALES REPORTING SYSTEM            *******");
                Console.WriteLine("***********************************************************");
                Console.WriteLine("*                                                         *");
                Console.WriteLine("* 1:  Add Sales Record                                    *");
                Console.WriteLine("* 2:  View Sales Records                                  *");
                Console.WriteLine("* 3:  Add Stock Item                                      *");
                Console.WriteLine("* 4:  View Stock Items                                    *");
                Console.WriteLine("* 5:  Output to CSV file                                  *");
                Console.WriteLine("* 6:  Log Out                                             *");
                Console.WriteLine("* 7:  Quit                                                *");
                Console.WriteLine("*                                                         *");
                Console.WriteLine("***********************************************************");
                Console.WriteLine("Please select an option [1 - 7]:  ");

                string selection = Console.ReadLine();                

                if (int.TryParse(selection, out value))
                {
                    switch (value)
                    {
                        case 1:
                            //relevant methods will be called depending on the users selection
                            Console.Clear();
                            AddSalesRecord.AddSalesRecords();
                            break;

                        case 2:
                            //relevant methods will be called depending on the users selection
                            StockSales.StockSalesMenu();
                            break;

                        case 3:
                            //relevant methods will be called depending on the users selection
                            Console.Clear();
                            AddItem.AddStock();
                            break;

                        case 4:
                            //relevant methods will be called depending on the users selection
                            StockTake st = new StockTake();
                            st.StockTakeMenu();                               
                            break;

                        case 5:
                            //relevant methods will be called depending on the users selection
                            CSV.CSVMenu();
                            break;

                        case 6:
                            Console.WriteLine("Log Out Function <To be implemented...>");       //relevant methods will be called depending on the users selection
                            break;

                        default:
                            Console.Clear();
                            Console.WriteLine("Exiting . . .");
                            break;
                    }
                } else {
                    Console.Clear();
                    Console.WriteLine("That input is an invalid.");
                }
            }
        }
    }
}
