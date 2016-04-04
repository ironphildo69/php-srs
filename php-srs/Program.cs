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
        static void checkDatabaseFile() //method that checks for the database file and if it doesnt exist creates it.
        {
            if (File.Exists("php-srs_database.sqlite"))
            {
                Console.WriteLine("Database found!");
            }
            else
            {
                SQLiteConnection.CreateFile("php-srs_database.sqlite");
            }

        }

        static void addSalesRecord() //Needs work, also needs to accept a enumorated type and send it to the SQL database. Phil will do SQL statements.
        {
           // code here
        }

        static void Main(string[] args)
        {
            int selection = 0;

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
                        Console.WriteLine("view stock");        //relevant methods will be called depending on the users selection
                        checkDatabaseFile();
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
