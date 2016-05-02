using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data.SQLite;

namespace php_srs
{
    class CreateDatabase
    {
        public CreateDatabase()
        {
            //Database creation logic, checks if file exists.
        
            if (File.Exists("php-srs_database.sqlite"))
            {
                //Console.WriteLine("Database successfully located.");
            }
            else
            {
                SQLiteConnection.CreateFile("php-srs_database.sqlite");
            }
        }
    }    
}
