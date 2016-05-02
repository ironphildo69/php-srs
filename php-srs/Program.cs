using System;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;

namespace php_srs
{
    class Program
    {
        private string currentUser = "";
        
        //Database creation logic, checks if file exists.
        public static bool createDatabase()
        {
            if (File.Exists("php-srs_database.sqlite"))
            {
                //Console.WriteLine("Database successfully located.");
            } else {
                //Put Table Creation Here + other database operations
                SQLiteConnection.CreateFile("php-srs_database.sqlite");

                UserLogin ul = new UserLogin();                    
                ul.createUserLoginTable();
            }
            return true;
        }

        public void setUser(string user)
        {
            currentUser = user;
        }

        public string getUser()
        {
            return currentUser;
        }

        public static void Main(string[] args)
        {
            //Pre initalisation logic
            createDatabase();
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Login());     
            
            //pass new user?
                   
            Application.Run(new Window());
            
        }
    }
}
