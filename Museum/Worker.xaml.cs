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

    public partial class Worker : Window
    {
        private int positionId;
        string connectionString;
        public Worker()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            SqlConnection sqlConnection = new SqlConnection(connectionString);
            try
            {
                if (sqlConnection.State == ConnectionState.Closed)
                    sqlConnection.Open();
                String query = "Select * from viewСотрудник";
                SqlCommand sqlCmd = new SqlCommand(query, sqlConnection);
                sqlCmd.CommandType = CommandType.Text;

                DataTable data = new DataTable();

                SqlDataAdapter adapter = new SqlDataAdapter(sqlCmd);

                adapter.Fill(data);
                workerGrid.DataContext = data.DefaultView;

                String query1 = "Select Код, Название from Должность order by 1";
                SqlCommand sqlCmd1 = new SqlCommand(query1, sqlConnection);
                sqlCmd1.CommandType = CommandType.Text;
                DataTable data1 = new DataTable();
                SqlDataAdapter adapter1 = new SqlDataAdapter(sqlCmd1);
                adapter1.Fill(data1);
                choosePosition.Items.Clear();
                foreach (DataRow r in data1.Rows)
                {
                    choosePosition.Items.Add(new
                    {
                        Position_Info = r["Название"].ToString(),
                        Position_Code = r["Код"].ToString()
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



        private void choosePosition_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            positionId = Convert.ToInt16(choosePosition.SelectedValue.ToString());
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
                String query = "Select * from viewСотрудник";
                SqlCommand sqlCmd = new SqlCommand(query, sqlConnection);
                sqlCmd.CommandType = CommandType.Text;

                SqlDataReader dr = sqlCmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
              
                
                workerGrid.ItemsSource = dt.DefaultView;
                dr.Close();
                workerGrid.Columns[0].Visibility = Visibility.Hidden;
                workerGrid.Columns[3].Visibility = Visibility.Hidden;
                choosePosition.SelectedIndex = 0;
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
            DataRowView row = workerGrid.SelectedItem as DataRowView;
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            try
            {
                if (sqlConnection.State == ConnectionState.Closed)
                    sqlConnection.Open();
                String query = "Delete from Сотрудники where Код = @Worker_id";
                SqlCommand sqlCmd = new SqlCommand(query, sqlConnection);
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.Parameters.Add("@Worker_id", SqlDbType.Int).Value = Convert.ToInt16(row.Row.ItemArray[0].ToString());

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
           
            DataRowView row = workerGrid.SelectedItem as DataRowView;
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            try
            {
                if (sqlConnection.State == ConnectionState.Closed)
                    sqlConnection.Open();
                String query = "Update Сотрудники set ФИО = @Worker_FIO, [Код должности]=@Position_id, Логин=@Login,Пароль=@Password where Код = @Worker_id";
                SqlCommand sqlCmd = new SqlCommand(query, sqlConnection);
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.Parameters.Add("@Worker_id", SqlDbType.Int).Value = Convert.ToInt16(row.Row.ItemArray[0].ToString());
                sqlCmd.Parameters.Add("@Worker_FIO", SqlDbType.VarChar, 50).Value = FIO.Text;
                sqlCmd.Parameters.Add("@Position_id", SqlDbType.Int).Value = positionId;
                sqlCmd.Parameters.Add("@Login", SqlDbType.VarChar, 50).Value = login.Text;
                sqlCmd.Parameters.Add("@Password", SqlDbType.VarChar, 50).Value = password.Password;
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
            
            DataRowView row = workerGrid.SelectedItem as DataRowView;
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            try
            {
                if (sqlConnection.State == ConnectionState.Closed)
                    sqlConnection.Open();
                String query = "Insert into Сотрудники(ФИО, [Код должности], Логин, Пароль) values(@Worker_FIO,@Position_id,@Login,@Password)";
                SqlCommand sqlCmd = new SqlCommand(query, sqlConnection);
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.Parameters.Add("@Worker_FIO", SqlDbType.VarChar, 50).Value = FIO.Text;
                sqlCmd.Parameters.Add("@Position_id", SqlDbType.Int).Value = positionId;
                sqlCmd.Parameters.Add("@Login", SqlDbType.VarChar, 50).Value = login.Text;
                sqlCmd.Parameters.Add("@Password", SqlDbType.VarChar, 50).Value = password.Password;

                sqlCmd.ExecuteNonQuery();
                MessageBox.Show("Запись добавлена успешно!");
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

        private void workerGrid_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            DataGrid dg = sender as DataGrid;
            DataRowView dr = dg.SelectedItem as DataRowView;
            if (dr != null)
            {

                FIO.Text = dr["ФИО"].ToString();
                string positionCode = dr["Код должности"].ToString();
                choosePosition.SelectedIndex = 0;
                for (int i = 0; i < choosePosition.Items.Count; i++)
                {
                    if (Convert.ToString(choosePosition.SelectedValue) == positionCode) break;
                    choosePosition.SelectedIndex = i + 1;
                }
                login.Text = dr["Логин"].ToString();
                password.Password = dr["Пароль"].ToString();
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

            FIO.Text = "";
            login.Text = "";
            password.Password = "";
            choosePosition.SelectedIndex = 0;
            add_btn.IsEnabled = true;
            update_btn.IsEnabled = false;
            delete_btn.IsEnabled = false;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            workerGrid.Visibility = Visibility.Visible;
            form.Visibility = Visibility.Visible;
            view_data.Visibility = Visibility.Hidden;
            workerGrid.Columns[0].Visibility = Visibility.Hidden;
            workerGrid.Columns[3].Visibility = Visibility.Hidden;
            add_btn.IsEnabled = true;
        }


   
    }
}
