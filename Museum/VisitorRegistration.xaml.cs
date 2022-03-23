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
    /// <summary>
    /// Логика взаимодействия для VisitorRegistration.xaml
    /// </summary>
    public partial class VisitorRegistration : Window
    {
        string connectionString;
        public VisitorRegistration()
        {
            InitializeComponent();
        }



        private void Registration_Click(object sender, RoutedEventArgs e)
        {
            if (login.Text == "" || password.Password == "")
            {
                MessageBox.Show("Введите логин и пароль");
            }
            else if (password.Password != confifmPassword.Password)
            {
                MessageBox.Show("Пароль и его подтверждение не совпадают.");
            }
            else
            {
                connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

                SqlConnection sqlConnection = new SqlConnection(connectionString);
                try
                {
                    if (sqlConnection.State == ConnectionState.Closed)
                        sqlConnection.Open();
                    String query = "Select count(1) from Посетители where Логин = @Login";
                    SqlCommand sqlCmd = new SqlCommand(query, sqlConnection);
                    sqlCmd.CommandType = CommandType.Text;
                    sqlCmd.Parameters.AddWithValue("@Login", login.Text);
                    int num = Convert.ToInt32(sqlCmd.ExecuteScalar());
                    if (num == 1)
                    {
                        MessageBox.Show("Этот логин уже занят! Используйте другой.");
                    }
                    else
                    {
                        query = "Insert into Посетители(Фамилия, Имя, Телефон, Логин, Пароль) VALUES(@Surname, @Name, @MobilePhone, @Login, @Password) ";
                        sqlCmd = new SqlCommand(query, sqlConnection);
                        sqlCmd.CommandType = CommandType.Text;
                        sqlCmd.Parameters.Add("@Surname", SqlDbType.VarChar, 40).Value = surname.Text;
                        sqlCmd.Parameters.Add("@Name", SqlDbType.VarChar, 40).Value = name.Text;
                        sqlCmd.Parameters.Add("@MobilePhone", SqlDbType.VarChar, 40).Value = mobilePhone.Text;
                        sqlCmd.Parameters.Add("@Login", SqlDbType.VarChar, 40).Value = login.Text;
                        sqlCmd.Parameters.Add("@Password", SqlDbType.VarChar, 40).Value = password.Password;
                        sqlCmd.ExecuteNonQuery();
                        MessageBox.Show("Вы успешно зарегистрировались!");
                        VisitorLogin backFrom = new VisitorLogin();
                        backFrom.Show();
                        this.Close();
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            VisitorLogin login = new VisitorLogin();
            login.Show();
            this.Close();
        }
    }
}