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
        
        static void checkDatabaseFile()
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

    }
}
