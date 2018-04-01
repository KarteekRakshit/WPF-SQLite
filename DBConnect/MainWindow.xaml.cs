using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;

namespace DBConnect
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SubmitButtonOnClick(object sender, RoutedEventArgs e)
        {
            Database databaseObject = new Database();
            string query = "INSERT INTO MyLog ('userid','date','pronning','reviewing','pronecycle','reviewcycle','pronecount','reviewcount') " +
                            "values ( @userid, @date, @pronning, @reviewing, @pronecycle, @reviewcycle, @pronecount, @reviewcount   )";

            SQLiteCommand myCommand = new SQLiteCommand(query, databaseObject.myConnetion);
            databaseObject.OpenConnection();
            myCommand.Parameters.AddWithValue("@userid", UserIdTextBox.Text);
            myCommand.Parameters.AddWithValue("@date", DateDatePicker.SelectedDate.Value.Date);
            myCommand.Parameters.AddWithValue("@pronning", PronningCheckBox.IsChecked.Value);
            myCommand.Parameters.AddWithValue("@reviewing", ReviewingCheckBox.IsChecked.Value);
            myCommand.Parameters.AddWithValue("@pronecycle", ProneCycleTextBox.Text);
            myCommand.Parameters.AddWithValue("@reviewcycle", ReviewCycleTextBox.Text);
            myCommand.Parameters.AddWithValue("@pronecount", ProneCountTextBox.Text);
            myCommand.Parameters.AddWithValue("@reviewcount", ReviewCountTextBox.Text);
            var result = myCommand.ExecuteNonQuery();
            databaseObject.CloseConnection();

            MessageBox.Show("Rows Added:"+ result.ToString());

        }

        private void LoadButtonOnClick(object sender, RoutedEventArgs e)
        {
            MyDataWindow win1 = new MyDataWindow();
            win1.Show();

        }


    }
}
