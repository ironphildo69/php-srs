using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;

namespace php_srs
{
    class StockTake
    {
        public static bool CheckIfTableExists()
        {

            return true;
        }

        public static void SelectFromTable(string selectQuery)
        {
            Console.WriteLine("________________________________________________________________________________________________________");
            Console.WriteLine(String.Format("{0,5}|{1,20}|{2,50}|{3,10}|{4,5}", "ID", "Name", "Description", "Attribute", "Quantity")); //Formats the string to look more presentable in the command line.
            
            var php_srsConnection = new SQLiteConnection("Data Source=php-srs_database.sqlite;Version=3;"); //Prepares the connection to the database
            php_srsConnection.Open();   //Opens the connection

            string query = selectQuery; //Acquires the SQL SELECT statement from the reference

            SQLiteCommand selectCommand = new SQLiteCommand(query, php_srsConnection);  //Sets up the query to be used with the database
            SQLiteDataReader readResults = selectCommand.ExecuteReader();   //Reads the results of the query into something that can be easily manipulated
            while (readResults.Read())
                Console.WriteLine(String.Format("{0,5}|{1,20}|{2,50}|{3,10}|{4,5}", readResults["ID"], readResults["Name"], readResults["Description"],
                    readResults["Attribute"], readResults["Quantity"]));

            php_srsConnection.Close();  //Closes the connection

            Console.WriteLine("________________________________________________________________________________________________________");
            Console.WriteLine(" ");
            Console.WriteLine("Press any key to continue . . . ");
            Console.ReadLine();
            Console.Clear();
        }

        public static void CheckingFunction()
        {
            Console.WriteLine("Are you looking for anything in particular? (Y/N)");
            string input = Console.ReadLine();
            switch (input)
            {
                case "y":
                    Console.Clear();

                    Console.WriteLine("Input an ID (Leave blank if you want all results): ");
                    string idValue = Console.ReadLine();

                    int convID = 0;

                    int.TryParse(idValue, out convID);

                    if (!(convID >= 0))
                    {
                        Console.WriteLine("That input is invalid. Leaving ID blank.");
                        idValue = "";
                    }

                    if (idValue != "")
                    {
                        idValue = "ID = " + idValue;
                    }

                    Console.WriteLine("Input a Medicine: ");
                    string nameValue = Console.ReadLine();

                    if (nameValue != "" && idValue != "")
                    {
                        nameValue = "AND Name = " + "'" + nameValue + "'";
                    }
                    else if (nameValue != "") {
                        nameValue = "Name = " + "'" + nameValue + "'";
                    }

                    Console.WriteLine("Input an Attribute: ");
                    string attrValue = Console.ReadLine();
                    
                    if (attrValue != "" && nameValue != "")
                    {
                        attrValue = "AND Attribute = " + "'" + attrValue + "'";
                    } else if (attrValue != "") {
                        attrValue = "Attribute = " + "'" + attrValue + "'";
                    }
                    
                    if (idValue == "" && nameValue == "" && attrValue == "")
                    {
                        Console.Clear();
                        Console.WriteLine("ALL STOCK (Nothing input): ");
                        SelectFromTable("SELECT * FROM MedicineStock");
                    } else {
                        Console.Clear();
                        Console.WriteLine("SPECIFIED STOCK: ");
                        Console.WriteLine("SELECT * FROM MedicineStock WHERE " + idValue + "" + nameValue + "" + attrValue);
                        SelectFromTable("SELECT * FROM MedicineStock WHERE " + idValue + "" + nameValue + "" + attrValue);
                    }
                    break;

                case "n":
                    Console.Clear();
                    Console.WriteLine("ALL STOCK: ");
                    SelectFromTable("SELECT * FROM MedicineStock");
                    break;

                default:
                    Console.WriteLine("That input is an invalid.");
                    break;

            }       
        }
    }
}
