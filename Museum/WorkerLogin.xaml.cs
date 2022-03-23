using System;
using System.Collections.Generic;
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
using System.Configuration;
namespace Museum
{
  
    public partial class WorkerLogin : Window
    {
        string connectionString;
        public WorkerLogin()
        {
            InitializeComponent();
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainForm main = new MainForm();
            main.Show();
            this.Close();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            SqlConnection sqlCon = new SqlConnection(connectionString);
            try
            {
                if (sqlCon.State == ConnectionState.Closed)
                    sqlCon.Open();
                String query = "Select Сотрудники.Код from Сотрудники where Логин=@Username and Пароль=@Password";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.Parameters.AddWithValue("@Username", login.Text);
                sqlCmd.Parameters.AddWithValue("@Password", password.Password);
                int workerCode = Convert.ToInt32(sqlCmd.ExecuteScalar());
                if (workerCode != 0)
                {
                    WorkerMenu mainMenu = new WorkerMenu(workerCode);
                    mainMenu.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Логин или пароль неверны");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
