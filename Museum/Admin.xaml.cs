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

    public partial class Admin : Window
    {
        string connectionString;
        public Admin()
        {
            InitializeComponent();
        }

       

        private void author_btn_Click(object sender, RoutedEventArgs e)
        {

            Author author = new Author();
            author.Show();
        }
        private void room_btn_Click(object sender, RoutedEventArgs e)
        {
            Room room = new Room();
            room.Show();
        }
        private void position_btn_Click(object sender, RoutedEventArgs e)
        {
            Position pos = new Position();
            pos.Show();
        }

        private void worker_btn_Click(object sender, RoutedEventArgs e)
        {
            Worker worker = new Worker();
            worker.Show();
        }

        private void formOfExhibit_Click(object sender, RoutedEventArgs e)
        {
            FormOfExhibit formOfExhibit = new FormOfExhibit();
            formOfExhibit.Show();
        }


        private void comment_Click(object sender, RoutedEventArgs e)
        {
            Comment comment = new Comment();
                comment.Show();
        }
    

       private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            chooseTable.Visibility = Visibility.Hidden;
            
        }

        private void excursion_Click(object sender, RoutedEventArgs e)
        {
            Excursion exc = new Excursion();
            exc.Show();
        }

        private void exhibit_Click(object sender, RoutedEventArgs e)
        {
            Exhibit exhibit = new Exhibit();
            exhibit.Show();
        }

        private void ticket_Click(object sender, RoutedEventArgs e)
        {
            Ticket ticket = new Ticket();
            ticket.Show();
        }

        private void restoration_Click(object sender, RoutedEventArgs e)
        {
            Restoration restoration = new Restoration();
            restoration.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainForm main = new MainForm();
            main.Show();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Label.Visibility = Visibility.Hidden;
            chooseTable.Visibility = Visibility.Hidden;
            scroll.Visibility = Visibility.Visible;
            backToTables.Visibility = Visibility.Visible;
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            SqlConnection sqlConnection = new SqlConnection(connectionString);
            try
            {
                if (sqlConnection.State == ConnectionState.Closed)
                    sqlConnection.Open();
                String query = "exec dbo.КоличествоПроданныхБилетовНаЭкскурсию";

                SqlCommand sqlCmd = new SqlCommand(query, sqlConnection);
                sqlCmd.CommandType = CommandType.Text;

                DataTable data = new DataTable();

                SqlDataAdapter adapter = new SqlDataAdapter(sqlCmd);

                adapter.Fill(data);
                grid.DataContext = data.DefaultView;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void BackToTables_Click(object sender, RoutedEventArgs e)
        {
            Label.Visibility = Visibility.Visible;
            chooseTable.Visibility = Visibility.Visible;
            scroll.Visibility = Visibility.Hidden;
            backToTables.Visibility = Visibility.Hidden;
        }
    }
}
