﻿using System;
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
                            StockTake.StockTakeMenu();                               
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
