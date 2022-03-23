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

    public partial class Position : Window
    {
        string connectionString;
        public Position()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            SqlConnection sqlConnection = new SqlConnection(connectionString);
            try
            {
                if (sqlConnection.State == ConnectionState.Closed)
                    sqlConnection.Open();
                String query = "Select  * from Должность order by 1";

                SqlCommand sqlCmd = new SqlCommand(query, sqlConnection);
                sqlCmd.CommandType = CommandType.Text;

                DataTable data = new DataTable();

                SqlDataAdapter adapter = new SqlDataAdapter(sqlCmd);

                adapter.Fill(data);
                positionGrid.DataContext = data.DefaultView;
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
                String query = "Select * from Должность";
                SqlCommand sqlCmd = new SqlCommand(query, sqlConnection);
                sqlCmd.CommandType = CommandType.Text;
                SqlDataReader dr = sqlCmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                positionGrid.ItemsSource = dt.DefaultView;
                dr.Close();
                positionGrid.Columns[0].Visibility = Visibility.Hidden;
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
            DataRowView row = positionGrid.SelectedItem as DataRowView;
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            try
            {
                if (sqlConnection.State == ConnectionState.Closed)
                    sqlConnection.Open();
                String query = "Delete from Должность where Код = @Position_id";
                SqlCommand sqlCmd = new SqlCommand(query, sqlConnection);
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.Parameters.Add("@Position_id", SqlDbType.Int).Value = Convert.ToInt16(row.Row.ItemArray[0].ToString());

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
            DataRowView row = positionGrid.SelectedItem as DataRowView;
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            try
            {
                if (sqlConnection.State == ConnectionState.Closed)
                    sqlConnection.Open();
                String query = "Update Должность set Название = @Position_name  where Код = @Position_id";
                SqlCommand sqlCmd = new SqlCommand(query, sqlConnection);
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.Parameters.Add("@Position_id", SqlDbType.Int).Value = Convert.ToInt16(row.Row.ItemArray[0].ToString());
                sqlCmd.Parameters.Add("@Position_name", SqlDbType.VarChar, 50).Value = newName.Text;
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
                String query = "Insert into Должность(Название) values(@Position_name)";
                SqlCommand sqlCmd = new SqlCommand(query, sqlConnection);
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.Parameters.Add("@Position_name", SqlDbType.VarChar, 50).Value = newName.Text;
                sqlCmd.ExecuteNonQuery();
                MessageBox.Show("Запись добавлена успешно!");
                this.updateDataGrid();
                newName.Text = "";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {

            }
        }

        private void positionGrid_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            DataGrid dg = sender as DataGrid;
            DataRowView dr = dg.SelectedItem as DataRowView;
            if (dr != null)
            {
                
                newName.Text = dr["Название"].ToString();
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

            newName.Text = "";

            add_btn.IsEnabled = true;
            update_btn.IsEnabled = false;
            delete_btn.IsEnabled = false;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            positionGrid.Visibility = Visibility.Visible;
            form.Visibility = Visibility.Visible;
            view_data.Visibility = Visibility.Hidden;
            positionGrid.Columns[0].Visibility = Visibility.Hidden;
            add_btn.IsEnabled = true;
        }
    }
}
