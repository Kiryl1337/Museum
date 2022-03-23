using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Configuration;
using System.Windows;

using System.Windows.Controls;

namespace Museum
{

    public partial class Ticket : Window
    {
        private int visitorId;
        private int excursionId;
        string connectionString;
        public Ticket()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            SqlConnection sqlConnection = new SqlConnection(connectionString);
            try
            {
                if (sqlConnection.State == ConnectionState.Closed)
                    sqlConnection.Open();
                String query = "Select * from viewБилет";
                SqlCommand sqlCmd = new SqlCommand(query, sqlConnection);
                sqlCmd.CommandType = CommandType.Text;

                DataTable data = new DataTable();

                SqlDataAdapter adapter = new SqlDataAdapter(sqlCmd);

                adapter.Fill(data);
                ticketGrid.DataContext = data.DefaultView;

                String query1 = "Select Код, Название from Экскурсии order by 1";
                SqlCommand sqlCmd1 = new SqlCommand(query1, sqlConnection);
                sqlCmd1.CommandType = CommandType.Text;
                DataTable data1 = new DataTable();
                SqlDataAdapter adapter1 = new SqlDataAdapter(sqlCmd1);
                adapter1.Fill(data1);
                chooseExcursionName.Items.Clear();
                foreach (DataRow row in data1.Rows)
                {
                    chooseExcursionName.Items.Add(new
                    {
                        Excursion_Info = row["Название"].ToString(),
                        Excursion_Code = row["Код"].ToString()
                    });

                }
                String query2 = "Select Код, Фамилия from Посетители order by 1";
                SqlCommand sqlCmd2 = new SqlCommand(query2, sqlConnection);
                sqlCmd2.CommandType = CommandType.Text;
                DataTable data2 = new DataTable();
                SqlDataAdapter adapter2 = new SqlDataAdapter(sqlCmd2);
                adapter2.Fill(data2);
                chooseVisitorFIO.Items.Clear();
                foreach (DataRow row in data2.Rows)
                {
                    chooseVisitorFIO.Items.Add(new
                    {
                        Visitor_Info = row["Фамилия"].ToString(),
                        Visitor_Code = row["Код"].ToString()
                    });

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {

            }
        }



        private void chooseExcursionName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            excursionId = Convert.ToInt16(chooseExcursionName.SelectedValue.ToString());
        }

        private void chooseVisitorFIO_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            visitorId = Convert.ToInt16(chooseVisitorFIO.SelectedValue.ToString());
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {


        }
        private void updateDataGrid()
        {

            SqlConnection sqlConnection = new SqlConnection(connectionString);
            try
            {
                if (sqlConnection.State == ConnectionState.Closed)
                    sqlConnection.Open();
                String query = "Select * from viewБилет";
                SqlCommand sqlCmd = new SqlCommand(query, sqlConnection);
                sqlCmd.CommandType = CommandType.Text;

                SqlDataReader dr = sqlCmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);


                ticketGrid.ItemsSource = dt.DefaultView;
                dr.Close();
                ticketGrid.Columns[0].Visibility = Visibility.Hidden;
                ticketGrid.Columns[4].Visibility = Visibility.Hidden;
                ticketGrid.Columns[5].Visibility = Visibility.Hidden;
                chooseExcursionName.SelectedIndex = 0;
                chooseVisitorFIO.SelectedIndex = 0;
                sqlCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {

            }
        }

        private void delete_btn_Click(object sender, RoutedEventArgs e)
        {
            DataRowView row = ticketGrid.SelectedItem as DataRowView;
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            try
            {
                if (sqlConnection.State == ConnectionState.Closed)
                    sqlConnection.Open();
                String query = "Delete from Билеты where Код = @Ticket_id";
                SqlCommand sqlCmd = new SqlCommand(query, sqlConnection);
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.Parameters.Add("@Ticket_id", SqlDbType.Int).Value = Convert.ToInt16(row.Row.ItemArray[0].ToString());

                sqlCmd.ExecuteNonQuery();
                MessageBox.Show("Запись удалена успешно!");
                this.updateDataGrid();
                this.resetAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {

            }
        }

        private void update_btn_Click(object sender, RoutedEventArgs e)
        {

            DataRowView row = ticketGrid.SelectedItem as DataRowView;
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            try
            {
                if (sqlConnection.State == ConnectionState.Closed)
                    sqlConnection.Open();
                String query = "UpdateБилеты";
                SqlCommand sqlCmd = new SqlCommand(query, sqlConnection);
                sqlCmd.CommandType = System.Data.CommandType.StoredProcedure;
                sqlCmd.Parameters.Add("@Ticket_id", SqlDbType.Int).Value = Convert.ToInt16(row.Row.ItemArray[0].ToString());
                sqlCmd.Parameters.Add("@Ticket_date", SqlDbType.Date).Value = date.Text;
                sqlCmd.Parameters.Add("@Excursion_id", SqlDbType.Int).Value = excursionId;
                sqlCmd.Parameters.Add("@Visitor_id", SqlDbType.Int).Value = visitorId;

                sqlCmd.ExecuteNonQuery();
                MessageBox.Show("Запись изменена успешно!");
                this.updateDataGrid();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {

            }

        }

        private void add_btn_Click(object sender, RoutedEventArgs e)
        {

            DataRowView row = ticketGrid.SelectedItem as DataRowView;
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            try
            {
                if (sqlConnection.State == ConnectionState.Closed)
                    sqlConnection.Open();
                String query = "Insert into Билеты(Дата, [Код экскурсии], [Код посетителя]) values(@Ticket_date, @Excursion_id, @Visitor_id)";
                SqlCommand sqlCmd = new SqlCommand(query, sqlConnection);
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.Parameters.Add("@Ticket_date", SqlDbType.VarChar, 50).Value = date.Text;
                sqlCmd.Parameters.Add("@Excursion_id", SqlDbType.Int).Value = excursionId;
                sqlCmd.Parameters.Add("@Visitor_id", SqlDbType.Int).Value = visitorId;

                sqlCmd.ExecuteNonQuery();
                MessageBox.Show("Запись добавлена успешно!");
                this.updateDataGrid();
                date.Text = "";
   


                chooseExcursionName.SelectedIndex = 0;
                chooseVisitorFIO.SelectedIndex = 0;


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {

            }

        }

        private void ticketGrid_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            DataGrid dg = sender as DataGrid;
            DataRowView dr = dg.SelectedItem as DataRowView;
            if (dr != null)
            {

                date.Text = dr["Дата"].ToString();

                string excursionCode = dr["Код экскурсии"].ToString();
                chooseExcursionName.SelectedIndex = 0;
                for (int i = 0; i < chooseExcursionName.Items.Count; i++)
                {
                    if (Convert.ToString(chooseExcursionName.SelectedValue) == excursionCode) break;
                    chooseExcursionName.SelectedIndex = i + 1;
                }
               
                string visitorCode = dr["Код посетителя"].ToString();
                chooseVisitorFIO.SelectedIndex = 0;
                for (int i = 0; i < chooseVisitorFIO.Items.Count; i++)
                {
                    if (Convert.ToString(chooseVisitorFIO.SelectedValue) == visitorCode) break;
                    chooseVisitorFIO.SelectedIndex = i + 1;
                }
                add_btn.IsEnabled = false;
                update_btn.IsEnabled = true;
                delete_btn.IsEnabled = true;
            }
        }

        private void reset_btn_Click(object sender, RoutedEventArgs e)
        {
            this.resetAll();
        }
        private void resetAll()
        {

            date.Text = "";
           
            chooseExcursionName.SelectedIndex = 0;
            chooseVisitorFIO.SelectedIndex = 0;
          
            add_btn.IsEnabled = true;
            update_btn.IsEnabled = false;
            delete_btn.IsEnabled = false;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ticketGrid.Visibility = Visibility.Visible;
            form.Visibility = Visibility.Visible;
            view_data.Visibility = Visibility.Hidden;
            ticketGrid.Columns[0].Visibility = Visibility.Hidden;
            ticketGrid.Columns[4].Visibility = Visibility.Hidden;
            ticketGrid.Columns[5].Visibility = Visibility.Hidden;
            add_btn.IsEnabled = true;
        }



    }
}
