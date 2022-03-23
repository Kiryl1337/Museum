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

    public partial class Author : Window
    {
        string connectionString;
        public Author()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            SqlConnection sqlConnection = new SqlConnection(connectionString);
            try
            {
                if (sqlConnection.State == ConnectionState.Closed)
                    sqlConnection.Open();
                String query = "Select  * from Автор";

                SqlCommand sqlCmd = new SqlCommand(query, sqlConnection);
                sqlCmd.CommandType = CommandType.Text;

                DataTable data = new DataTable();

                SqlDataAdapter adapter = new SqlDataAdapter(sqlCmd);

                adapter.Fill(data);
                authorGrid.DataContext = data.DefaultView;
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
                String query = "Select  * from Автор";
                SqlCommand sqlCmd = new SqlCommand(query, sqlConnection);
                sqlCmd.CommandType = CommandType.Text;
                SqlDataReader dr = sqlCmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                authorGrid.ItemsSource = dt.DefaultView;
                dr.Close();
                authorGrid.Columns[0].Visibility = Visibility.Hidden;
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
                String query = "Delete from Автор where Код = @Author_id";
                SqlCommand sqlCmd = new SqlCommand(query, sqlConnection);
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.Parameters.Add("@Author_id", SqlDbType.Int).Value = Convert.ToInt16(newId.Text);

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
                String query = "Update Автор set ФИО = @Author_FIO, Страна = @Author_country, Специальность = @Author_specialty  where Код = @Author_id";
                SqlCommand sqlCmd = new SqlCommand(query, sqlConnection);
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.Parameters.Add("@Author_id", SqlDbType.Int).Value = Convert.ToInt16(newId.Text);
                sqlCmd.Parameters.Add("@Author_FIO", SqlDbType.VarChar, 50).Value = newFIO.Text;
                sqlCmd.Parameters.Add("@Author_country", SqlDbType.VarChar, 50).Value = newCountry.Text;
                sqlCmd.Parameters.Add("@Author_specialty", SqlDbType.VarChar, 50).Value = newSpecialty.Text;
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
                String query = "Insert into Автор(ФИО, Страна, Специальность) values(@Author_FIO, @Author_country,@Author_specialty)";
                SqlCommand sqlCmd = new SqlCommand(query, sqlConnection);
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.Parameters.Add("@Author_FIO", SqlDbType.VarChar, 50).Value = newFIO.Text;
                sqlCmd.Parameters.Add("@Author_country", SqlDbType.VarChar, 50).Value = newCountry.Text;
                sqlCmd.Parameters.Add("@Author_specialty", SqlDbType.VarChar, 50).Value = newSpecialty.Text;
                sqlCmd.ExecuteNonQuery();
                MessageBox.Show("Запись добавлена успешно!");
                this.updateDataGrid();
                newFIO.Text = "";
                newCountry.Text = "";
                newSpecialty.Text = "";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {

            }
        }

        private void authorGrid_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            DataGrid dg = sender as DataGrid;
            DataRowView dr = dg.SelectedItem as DataRowView;
            if (dr != null)
            {
                newId.Text = dr["Код"].ToString();
                newFIO.Text = dr["ФИО"].ToString();
                newCountry.Text = dr["Страна"].ToString();
                newSpecialty.Text = dr["Специальность"].ToString();


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
            newFIO.Text = "";
            newCountry.Text = "";
            newSpecialty.Text = "";

            add_btn.IsEnabled = true;
            update_btn.IsEnabled = false;
            delete_btn.IsEnabled = false;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        
            {
                authorGrid.Visibility = Visibility.Visible;
                form.Visibility = Visibility.Visible;
                view_data.Visibility = Visibility.Hidden;
                authorGrid.Columns[0].Visibility = Visibility.Hidden;
                add_btn.IsEnabled = true;
            }
        
    }
}
