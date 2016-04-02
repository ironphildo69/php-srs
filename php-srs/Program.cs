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
        static void Main(string[] args)
        {
            Console.WriteLine("test for initial branch");
            checkDatabaseFile();
        }
        
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

        }
    }
}
