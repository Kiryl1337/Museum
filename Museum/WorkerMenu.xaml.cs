using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
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

namespace Museum
{

    public partial class WorkerMenu : Window
    {
        string connectionString;
        private int workerId;
        public WorkerMenu(int code)
        {
            InitializeComponent();
            workerId = code;
        }

        private void Button_Click()
        {

        }

        private void viewExhibit_btn_Click(object sender, RoutedEventArgs e)
        {
            viewExhibit.Visibility = Visibility.Visible;
            viewReport.Visibility = Visibility.Hidden;
            list.Visibility = Visibility.Hidden;
            list1.Visibility = Visibility.Hidden;

            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            SqlConnection sqlCon = new SqlConnection(connectionString);
            try
            {
                if (sqlCon.State == ConnectionState.Closed)
                    sqlCon.Open();

                String query = "Select * from ПросмотрЭкспонатов ";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.Add("@WorkerId", SqlDbType.Int).Value = workerId;
                sqlCmd.CommandType = CommandType.Text;
                DataTable data = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(sqlCmd);
                adapter.Fill(data);
                viewExhibitGrid.DataContext = data.DefaultView;
                viewExhibitGrid.Columns[0].Visibility = Visibility.Hidden;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }
        private void submitButton_Click(object sender, RoutedEventArgs e)
        {
            if ((date1.Text == "") && (date2.Text == ""))
            {
                MessageBox.Show("Заполните поля!");
            }
            else
            {
                viewReport.Visibility = Visibility.Visible;
                list.Visibility = Visibility.Hidden;
                label.Content = "Отчёт по экскурсиям";

                connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                SqlConnection sqlCon = new SqlConnection(connectionString);
                try
                {
                    if (sqlCon.State == ConnectionState.Closed)
                        sqlCon.Open();
                    String query = "Select * from ExcursionDateBetween(@Date1,@Date2,@WorkerId)";
                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                    sqlCmd.Parameters.Add("@WorkerId", SqlDbType.Int).Value = workerId;
                    sqlCmd.Parameters.Add("@Date1", SqlDbType.VarChar, 20).Value = date1.Text;
                    sqlCmd.Parameters.Add("@Date2", SqlDbType.VarChar, 20).Value = date2.Text;
                    sqlCmd.CommandType = CommandType.Text;
                    DataTable data = new DataTable();
                    SqlDataAdapter adapter = new SqlDataAdapter(sqlCmd);
                    adapter.Fill(data);
                    viewReportGrid.DataContext = data.DefaultView;
                    viewReportGrid.Columns[0].Visibility = Visibility.Hidden;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void viewReportExcursion_btn_Click(object sender, RoutedEventArgs e)
        {
            viewExhibit.Visibility = Visibility.Hidden;   
            viewReport.Visibility = Visibility.Hidden;
            list.Visibility = Visibility.Visible;
            list1.Visibility = Visibility.Hidden;
            date1.Text = "";
            date2.Text = "";


        }

        private void printButton_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.PrintDialog Printdlg = new System.Windows.Controls.PrintDialog();
            if ((bool)Printdlg.ShowDialog().GetValueOrDefault())
            {
                Size pageSize = new Size(Printdlg.PrintableAreaWidth, Printdlg.PrintableAreaHeight);
                viewReportGrid.Measure(pageSize);
                viewReportGrid.Arrange(new Rect(5, 5, pageSize.Width, pageSize.Height));
                Printdlg.PrintVisual(viewReportGrid, Title);
                viewReportGrid.Visibility = Visibility.Hidden;
               
            }
        }

        private void viewReportRestoration_btn_Click(object sender, RoutedEventArgs e)
        {
            viewExhibit.Visibility = Visibility.Hidden;
            viewReport.Visibility = Visibility.Hidden;
            list.Visibility = Visibility.Hidden;
            list1.Visibility = Visibility.Visible;
            date3.Text = "";
            date4.Text = "";
           
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainForm main = new MainForm();
            main.Show();
            this.Close();
        }

        private void submit1Button_Click(object sender, RoutedEventArgs e)
        {
            if ((date3.Text == "") && (date4.Text == ""))
            {
                MessageBox.Show("Заполните поля!");
            }
            else
            {
                viewReport.Visibility = Visibility.Visible;
                list1.Visibility = Visibility.Hidden;
                label.Content = "Отчёт по реставрациям";

                connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                SqlConnection sqlCon = new SqlConnection(connectionString);
                try
                {
                    if (sqlCon.State == ConnectionState.Closed)
                        sqlCon.Open();
                    String query = "Select * from RestorationDateBetween(@Date1,@Date2,@WorkerId)";
                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                    sqlCmd.Parameters.Add("@WorkerId", SqlDbType.Int).Value = workerId;
                    sqlCmd.Parameters.Add("@Date1", SqlDbType.VarChar, 20).Value = date3.Text;
                    sqlCmd.Parameters.Add("@Date2", SqlDbType.VarChar, 20).Value = date4.Text;
                    sqlCmd.CommandType = CommandType.Text;
                    DataTable data = new DataTable();
                    SqlDataAdapter adapter = new SqlDataAdapter(sqlCmd);
                    adapter.Fill(data);
                    viewReportGrid.DataContext = data.DefaultView;
                    viewReportGrid.Columns[0].Visibility = Visibility.Hidden;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
