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

    public partial class Room : Window
    {
        string connectionString;
        public Room()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            SqlConnection sqlConnection = new SqlConnection(connectionString);
            try
            {
                if (sqlConnection.State == ConnectionState.Closed)
                    sqlConnection.Open();
                String query = "Select  Код, Этаж, [Площадь(м2)], Название from Залы";

                SqlCommand sqlCmd = new SqlCommand(query, sqlConnection);
                sqlCmd.CommandType = CommandType.Text;

                DataTable data = new DataTable();

                SqlDataAdapter adapter = new SqlDataAdapter(sqlCmd);

                adapter.Fill(data);
                roomGrid.DataContext = data.DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {

            }
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
                String query = "Select  Код, Этаж, [Площадь(м2)], Название from Залы";
                SqlCommand sqlCmd = new SqlCommand(query, sqlConnection);
                sqlCmd.CommandType = CommandType.Text;
                SqlDataReader dr = sqlCmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                roomGrid.ItemsSource = dt.DefaultView;
                dr.Close();
                roomGrid.Columns[0].Visibility = Visibility.Hidden;
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
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            try
            {
                if (sqlConnection.State == ConnectionState.Closed)
                    sqlConnection.Open();
                String query = "Delete from Залы where Код = @Room_id";
                SqlCommand sqlCmd = new SqlCommand(query, sqlConnection);
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.Parameters.Add("@Room_id", SqlDbType.Int).Value = Convert.ToInt16(id.Text);

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
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            try
            {
                if (sqlConnection.State == ConnectionState.Closed)
                    sqlConnection.Open();
                String query = "UpdateЗалы";
                SqlCommand sqlCmd = new SqlCommand(query, sqlConnection);
                sqlCmd.CommandType = System.Data.CommandType.StoredProcedure;
                sqlCmd.Parameters.Add("@Room_id", SqlDbType.Int).Value = Convert.ToInt16(id.Text);
                sqlCmd.Parameters.Add("@Room_floor", SqlDbType.Int).Value = Convert.ToInt16(floor.Text);
                sqlCmd.Parameters.Add("@Room_square", SqlDbType.Int).Value = Convert.ToInt16(square.Text);
                sqlCmd.Parameters.Add("@Room_name", SqlDbType.VarChar, 50).Value = name.Text;
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
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            try
            {
                if (sqlConnection.State == ConnectionState.Closed)
                    sqlConnection.Open();
                String query = "Insert into Залы(Этаж, [Площадь(м2)], Название) values(@Room_floor, @Room_square,@Room_name)";
                SqlCommand sqlCmd = new SqlCommand(query, sqlConnection);
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.Parameters.Add("@Room_floor", SqlDbType.VarChar, 50).Value = floor.Text;
                sqlCmd.Parameters.Add("@Room_square", SqlDbType.VarChar, 50).Value = square.Text;
                sqlCmd.Parameters.Add("@Room_name", SqlDbType.VarChar, 50).Value = name.Text;
                sqlCmd.ExecuteNonQuery();
                MessageBox.Show("Запись добавлена успешно!");
                this.updateDataGrid();
                floor.Text = "";
                square.Text = "";
                name.Text = "";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {

            }
        }

        private void roomGrid_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            DataGrid dg = sender as DataGrid;
            DataRowView dr = dg.SelectedItem as DataRowView;
            if (dr != null)
            {
                id.Text = dr["Код"].ToString();
                floor.Text = dr["Этаж"].ToString();
                square.Text = dr["Площадь(м2)"].ToString();
                name.Text = dr["Название"].ToString();


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
            floor.Text = "";
            square.Text = "";
            name.Text = "";

            add_btn.IsEnabled = true;
            update_btn.IsEnabled = false;
            delete_btn.IsEnabled = false;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            roomGrid.Visibility = Visibility.Visible;
            form.Visibility = Visibility.Visible;
            view_data.Visibility = Visibility.Hidden;
            roomGrid.Columns[0].Visibility = Visibility.Hidden;
            add_btn.IsEnabled = true;
        }
    }
}
