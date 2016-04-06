using System;
using System.IO;
using SwinGameSDK;
using System.Data.SQLite;

namespace php_srs
{
    public class GameMain
    {
        public static void Main()
        {
            //Pre initalisation logic

            createDatabase();

            //Open the game window
            
            SwinGame.OpenGraphicsWindow("GameMain", 800, 600);
            SwinGame.ShowSwinGameSplashScreen();
            
            //Run the game loop
            while(false == SwinGame.WindowCloseRequested())
            {
                //Fetch the next batch of UI interaction
                SwinGame.ProcessEvents();
                
                //Clear the screen and draw the framerate
                SwinGame.ClearScreen(Color.White);
                SwinGame.DrawFramerate(0,0);
                
                //Draw onto the screen
                SwinGame.RefreshScreen(60);
            }
        }

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
                Console.WriteLine("Database found!");
            }
            else
            {
                SQLiteConnection.CreateFile("php-srs_database.sqlite");

            }
            return true;
        }

        //Start of sales record function

        //CODE HERE

        //Startof CSV Export function from local SQL Database

        //CODE HERE

    }
}