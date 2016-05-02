using System;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;

namespace php_srs
{
    class Program
    {
        public static void Main(string[] args)
        {
            //Pre initalisation logic
            new CreateDatabase();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            LoginHandler login = new LoginHandler();            
        }
    }
}