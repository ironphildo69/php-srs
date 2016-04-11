using System;
using System.Data.SQLite;
using System.IO;

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
                SQLiteConnection.CreateFile("php-srs_database.sqlite");
            }
            return true;
        }        

        public static void Main(string[] args)
        {
            //Pre initalisation logic

            createDatabase();

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
                Console.WriteLine("* 2:  View Stock Sales                                    *");
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

                            string selectionStockSales = Console.ReadLine();

                            int valueStockSales = 0;

                            if (int.TryParse(selectionStockSales, out valueStockSales))
                            {
                                switch (valueStockSales)
                                {
                                    case 1:
                                        Console.Clear();
                                        StockSales.StockSalesAll();
                                        break;

                                    case 2:
                                        Console.Clear();
                                        StockSales.StockSalesID();
                                        break;

                                    case 3:
                                        Console.Clear();
                                        StockSales.StockSalesName();
                                        break;

                                    case 4:
                                        Console.Clear();
                                        StockSales.StockSalesAttribute();
                                        break;

                                    case 5:
                                        Console.Clear();
                                        StockSales.StockSalesDate();
                                        break;

                                    default:
                                        Console.Clear();
                                        break;
                                }
                            } else {
                                Console.Clear();
                                Console.WriteLine("That input is an invalid.");
                            }
                            break;

                        case 3:
                            //relevant methods will be called depending on the users selection
                            Console.Clear();
                            AddItem.AddStock();
                            break;

                        case 4:
                            //relevant methods will be called depending on the users selection
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

                            string selectionStockItems = Console.ReadLine();
                            int valueStockItems = 0;

                            if (int.TryParse(selectionStockItems, out valueStockItems))
                            {
                                switch (valueStockItems)
                                {
                                    case 1:
                                        Console.Clear();
                                        StockTake.StockTakeAll();
                                        break;

                                    case 2:
                                        Console.Clear();
                                        StockTake.StockTakeID();
                                        break;

                                    case 3:
                                        Console.Clear();
                                        StockTake.StockTakeName();
                                        break;

                                    case 4:
                                        Console.Clear();
                                        StockTake.StockTakeAttribute();
                                        break;

                                    case 5:
                                        Console.Clear();
                                        StockTake.StockTakeQuantity();
                                        break;

                                    default:
                                        Console.Clear();
                                        break;
                                }
                            } else {
                                Console.Clear();
                                Console.WriteLine("That input is an invalid.");
                            }
                            break;

                        case 5:
                            //relevant methods will be called depending on the users selection
                            Console.Clear();
                            CSV.WriteCSVToFile();
                            Console.WriteLine("Text file created in 'CSV.txt'");
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
