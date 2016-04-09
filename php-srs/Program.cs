using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;

namespace php_srs
{
    class Program
    {
        //Global Variables
        public static void globalVariables()
        {
            //Global SQL Connection to Database
            SQLiteConnection databaseConnection = new SQLiteConnection("Data Source=php-srs_database.sqlite;Version=3;");
        }

        //Database creation logic, checks if file exists.
        public static bool createDatabase()
        {
            if (File.Exists("php-srs_database.sqlite"))
            {
                Console.WriteLine("Database successfully located.");
            }
            else
            {
                SQLiteConnection.CreateFile("php-srs_database.sqlite");
            }
            return true;
        }

        //Start of sales record function
        static void addSalesRecord() //Needs work, also needs to accept a enumorated type and send it to the SQL database. Phil will do SQL statements.
        {
            // code here
        }

        //CODE HERE

        //Startof CSV Export function from local SQL Database

        //CODE HERE

        public static void Main(string[] args)
        {
            //Pre initalisation logic

            createDatabase();

            int selection = 0;

            //Menu selection loop
            while (selection != 5)
            {
                Console.WriteLine(" ");
                Console.WriteLine("**************************************");
                Console.WriteLine("*                                    *");
                Console.WriteLine("******* PEOPLE HEALTH PHARMACY *******");
                Console.WriteLine("******* SALES REPORTING SYSTEM *******");
                Console.WriteLine("**************************************");
                Console.WriteLine("*                                    *");
                Console.WriteLine("* 1:  Add Sales Record               *");
                Console.WriteLine("* 2:  View Stock                     *");
                Console.WriteLine("* 3:  Output to CSV file             *");
                Console.WriteLine("* 4:  Log Out                        *");
                Console.WriteLine("* 5:  Quit                           *");
                Console.WriteLine("*                                    *");
                Console.WriteLine("**************************************");
                Console.WriteLine("Please Enter Option :  ");

                selection = int.Parse(Console.ReadLine());

                switch (selection)
                {
                    case 1:
                        Console.WriteLine("add sales record");      //relevant methods will be called depending on the users selection
                        break;

                    case 2:
                        Console.WriteLine("View Stock Selected.");        //relevant methods will be called depending on the users selection

                        string sql = "create table medicine (id int, name varchar(20), description )";


                        break;
                    case 3:

                        Console.WriteLine("CSV");       //relevant methods will be called depending on the users selection
                        break;

                    case 4:
                        Console.WriteLine("log out");       //relevant methods will be called depending on the users selection
                        break;
                }
            }
        }
    }
}
