using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DBConnect
{
    class Database
    {
        public SQLiteConnection myConnetion;

        public Database()
        {
            myConnetion = new SQLiteConnection("Data Source=database.sqlite3");

            if (!File.Exists("./database.sqlite3"))
            {
                SQLiteConnection.CreateFile("database.sqlite3");
                MessageBox.Show("Created");
            }
        }

        public void OpenConnection()
        {
            if(myConnetion.State != System.Data.ConnectionState.Open)
            {
                myConnetion.Open();
            }
        }
        public void CloseConnection()
        {
            if (myConnetion.State != System.Data.ConnectionState.Closed)
            {
                myConnetion.Close();
            }
        }
    }
}
