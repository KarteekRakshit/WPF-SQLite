using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DBConnect
{
    /// <summary>
    /// Interaction logic for MyDataWindow.xaml
    /// </summary>
    public partial class MyDataWindow : Window
    {
        public MyDataWindow()
        {
            InitializeComponent();
            MyDataGridLoad();
        }

        private void MyDataGridLoad()
        {
            Database databaseObject = new Database();
            string query = "SELECT * FROM MyLog";
            SQLiteCommand myCommand = new SQLiteCommand(query, databaseObject.myConnetion);
            databaseObject.OpenConnection();
            //SQLiteDataReader result = myCommand.ExecuteReader();
            SQLiteDataAdapter sda = new SQLiteDataAdapter(myCommand);
            DataTable dt = new DataTable("MyLog");
            sda.Fill(dt);
            MyDataDataGrid.ItemsSource = dt.DefaultView;


            databaseObject.CloseConnection();


        }
    }
}
