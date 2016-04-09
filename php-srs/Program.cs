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
                        Console.WriteLine("Viewing Stock Selected.");        //relevant methods will be called depending on the users selection

                        var php_srsConnection = new SQLiteConnection("Data Source=php-srs_database.sqlite;Version=3;");
                        php_srsConnection.Open();

                        string createTableQuery = "create table if not exists Medicine (id int, name varchar(20), description varchar(30))";

                        SQLiteCommand createMedicineTable = new SQLiteCommand(createTableQuery, php_srsConnection);               
                        createMedicineTable.ExecuteNonQuery();

                        string sql = "insert into Medicine (id, name, description) values (1, 'Panadol', 'For headaches')";
                        SQLiteCommand command = new SQLiteCommand(sql, php_srsConnection);
                        command.ExecuteNonQuery();

                        sql = "insert into Medicine (id, name, description) values (2, 'Paracetamol', 'For toothaches')";
                        command = new SQLiteCommand(sql, php_srsConnection);
                        command.ExecuteNonQuery();

                        sql = "insert into Medicine (id, name, description) values (3, 'Ibuprofen', 'For feeling good')";
                        command = new SQLiteCommand(sql, php_srsConnection);
                        command.ExecuteNonQuery();

                        string selectQuery = "select * from Medicine order by id desc";
                        SQLiteCommand selectCommand = new SQLiteCommand(selectQuery, php_srsConnection);

                        SQLiteDataReader reader = selectCommand.ExecuteReader();
                        while (reader.Read())
                        {
                            Console.WriteLine("ID: " + reader["id"] + "\tName: " + reader["name"] + "\tDescription: " + reader["description"]);
                        }

                        string dropTableQuery = "drop table if exists 'Medicine'";
                        SQLiteCommand dropTableCommand = new SQLiteCommand(dropTableQuery, php_srsConnection);
                        dropTableCommand.ExecuteNonQuery();

                        php_srsConnection.Close();

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
