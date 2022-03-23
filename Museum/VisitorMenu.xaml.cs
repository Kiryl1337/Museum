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

    public partial class VisitorMenu : Window
    {
        string connectionString;
        int excursionId;
        int visitorId;
        string excursionName;
        public VisitorMenu(int id)
        {
            visitorId = id; 
            InitializeComponent();          
        }


        private void viewExcursion_btn_Click(object sender, RoutedEventArgs e)
        {
            viewExcursion.Visibility = Visibility.Visible;
            viewBuyTicket.Visibility = Visibility.Hidden;
            viewTextComment.Visibility = Visibility.Hidden;

            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            try
            {
                if (sqlConnection.State == ConnectionState.Closed)
                    sqlConnection.Open();

                String query = "Select * from ПросмотрЭкскурсий";
                SqlCommand sqlCmd = new SqlCommand(query, sqlConnection);
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

        private void buyTicket_btn_Click(object sender, RoutedEventArgs e)
        {
            chooseExcursionName.Items.Clear();
            viewBuyTicket.Visibility = Visibility.Visible;
            viewExcursion.Visibility = Visibility.Hidden;
            viewTextComment.Visibility = Visibility.Hidden;

            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            SqlConnection sqlCon = new SqlConnection(connectionString);
            try
            {
                if (sqlCon.State == ConnectionState.Closed)
                    sqlCon.Open();
                String query = "Select Код, Название from Экскурсии order by 1";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.CommandType = CommandType.Text;
                DataTable data = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(sqlCmd);
                adapter.Fill(data);

                chooseExcursionName.Items.Clear();
                foreach (DataRow row in data.Rows)
                {
                    chooseExcursionName.Items.Add(new
                    {
                        ExcursionName_Code = row["Код"].ToString(),
                        ExcursionName_Info = row["Название"].ToString()
                    });

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void chooseExcursionName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

           
            if (chooseExcursionName.SelectedValue != null)
            {
                excursionId = Convert.ToInt16(chooseExcursionName.SelectedValue.ToString());
            }
        }

       
        private void addVisitor_Click(object sender, RoutedEventArgs e)
        {
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            SqlConnection sqlConnection = new SqlConnection(connectionString);
            try
            {
                if (chooseExcursionName.Text != "")
                {
                    if (sqlConnection.State == ConnectionState.Closed)
                        sqlConnection.Open();
                    String query = "Insert into Билеты( Дата, [Код экскурсии], [Код посетителя]) VALUES(@TicketDate, @ExcursionId, @VisitorId)";              
                    SqlCommand sqlCmd = new SqlCommand(query, sqlConnection);
                    sqlCmd.CommandType = CommandType.Text;
                    sqlCmd.Parameters.Add("@VisitorId", SqlDbType.Int).Value = visitorId;
                    sqlCmd.Parameters.Add("@ExcursionId", SqlDbType.Int).Value = excursionId;
                    sqlCmd.Parameters.Add("@TicketDate", SqlDbType.VarChar, 50).Value = DateTime.Now;
      
                    sqlCmd.ExecuteNonQuery();
                    MessageBox.Show("Билет был куплен!");

                    viewBuyTicket.Visibility = Visibility.Hidden;
                    
                }
                else
                {
                    MessageBox.Show("Выберите экскурсию! ");
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void chooseExcursionName1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (chooseExcursionName1.SelectedValue != null)
            {
                excursionId = Convert.ToInt16(chooseExcursionName1.SelectedValue.ToString());
            }
        }

        private void viewComment_btn_Click(object sender, RoutedEventArgs e)
        {
            chooseExcursionName1.Items.Clear();
            viewTextComment.Visibility = Visibility.Visible;
            viewExcursion.Visibility = Visibility.Hidden;
            viewBuyTicket.Visibility = Visibility.Hidden;
  
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            try
            {
                if (sqlConnection.State == ConnectionState.Closed)
                    sqlConnection.Open();
                String query = "Select Код, Название from Экскурсии order by 1";
                SqlCommand sqlCmd = new SqlCommand(query, sqlConnection);
                sqlCmd.CommandType = CommandType.Text;
                DataTable data = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(sqlCmd);
                adapter.Fill(data);

                chooseExcursionName1.Items.Clear();
                foreach (DataRow row in data.Rows)
                {
                    chooseExcursionName1.Items.Add(new
                    {
                        ExcursionName1_Code = row["Код"].ToString(),
                        ExcursionName1_Info = row["Название"].ToString()
                    });

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void addComment_Click(object sender, RoutedEventArgs e)
        {
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            SqlConnection sqlConnection = new SqlConnection(connectionString);
            try
            {
                if (chooseExcursionName1.Text != "")
                {
                    if (commentText.Text != "")
                    {
                        if (sqlConnection.State == ConnectionState.Closed)
                            sqlConnection.Open();
                        String query = "Insert into Отзыв(Текст, [Код экскурсии]) VALUES(@CommentText,  @ExcursionId)";
                        SqlCommand sqlCmd = new SqlCommand(query, sqlConnection);
                        sqlCmd.CommandType = CommandType.Text;
                        sqlCmd.Parameters.Add("@ExcursionId", SqlDbType.Int).Value = excursionId;
                        sqlCmd.Parameters.Add("@CommentText", SqlDbType.VarChar, 100).Value = commentText.Text;
                        sqlCmd.ExecuteNonQuery();
                        MessageBox.Show("Отзыв успешно отправлен!");

                        viewTextComment.Visibility = Visibility.Hidden;
                    }
                    else
                    {
                        MessageBox.Show("Напишите отзыв для того чтобы его отправить!");
                    }
                }
                else
                {
                    MessageBox.Show("Выберите экскурсию для которой хотите оставить отзыв!");
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainForm main = new MainForm();
            main.Show();
            this.Close();
        }
    }
}
