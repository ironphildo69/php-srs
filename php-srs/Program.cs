using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

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
            SQLiteConnection.CreateFile("MyDatabase.sqlite");
        }

    }
}
