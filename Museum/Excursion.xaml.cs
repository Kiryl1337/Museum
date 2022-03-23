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

    public partial class Excursion : Window
    {
        private int workerId;
        string connectionString;
        public Excursion()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            SqlConnection sqlConnection = new SqlConnection(connectionString);
            try
            {
                if (sqlConnection.State == ConnectionState.Closed)
                    sqlConnection.Open();
                String query = "Select * from viewЭкскурсия";

                SqlCommand sqlCmd = new SqlCommand(query, sqlConnection);
                sqlCmd.CommandType = CommandType.Text;

                DataTable data = new DataTable();

                SqlDataAdapter adapter = new SqlDataAdapter(sqlCmd);

                adapter.Fill(data);
                excursionGrid.DataContext = data.DefaultView;

                String query1 = "Select Сотрудники.Код, ФИО from Сотрудники, Должность where Сотрудники.[Код должности]=Должность.Код and Название='Экскурсовод' order by 1";
                SqlCommand sqlCmd1 = new SqlCommand(query1, sqlConnection);
                sqlCmd1.CommandType = CommandType.Text;
                DataTable data1 = new DataTable();
                SqlDataAdapter adapter1 = new SqlDataAdapter(sqlCmd1);
                adapter1.Fill(data1);
                chooseWorker.Items.Clear();
                foreach (DataRow r in data1.Rows)
                {
                    chooseWorker.Items.Add(new
                    {
                        Worker_Info = r["ФИО"].ToString(),
                        Worker_Code = r["Код"].ToString()
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



        private void chooseWorker_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            workerId = Convert.ToInt16(chooseWorker.SelectedValue.ToString());
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
                String query = "Select * from viewЭкскурсия";
                SqlCommand sqlCmd = new SqlCommand(query, sqlConnection);
                sqlCmd.CommandType = CommandType.Text;

                SqlDataReader dr = sqlCmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);


                excursionGrid.ItemsSource = dt.DefaultView;
                dr.Close();
                excursionGrid.Columns[0].Visibility = Visibility.Hidden;
                excursionGrid.Columns[5].Visibility = Visibility.Hidden;
                chooseWorker.SelectedIndex = 0;
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
            DataRowView row = excursionGrid.SelectedItem as DataRowView;
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            try
            {
                if (sqlConnection.State == ConnectionState.Closed)
                    sqlConnection.Open();
                String query = "Delete from Экскурсии where Код = @Excursion_id";
                SqlCommand sqlCmd = new SqlCommand(query, sqlConnection);
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.Parameters.Add("@Excursion_id", SqlDbType.Int).Value = Convert.ToInt16(row.Row.ItemArray[0].ToString());

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

            DataRowView row = excursionGrid.SelectedItem as DataRowView;
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            try
            {
                if (sqlConnection.State == ConnectionState.Closed)
                    sqlConnection.Open();
                String query = "UpdateЭкскурсии";
                SqlCommand sqlCmd = new SqlCommand(query, sqlConnection);
                sqlCmd.CommandType = System.Data.CommandType.StoredProcedure;
                sqlCmd.Parameters.Add("@Excursion_id", SqlDbType.Int).Value = Convert.ToInt16(row.Row.ItemArray[0].ToString());
                sqlCmd.Parameters.Add("@Excursion_date", SqlDbType.VarChar, 50).Value = date.Text;
                sqlCmd.Parameters.Add("@Excursion_name", SqlDbType.VarChar, 50).Value = name.Text;
                sqlCmd.Parameters.Add("@Excursion_description", SqlDbType.VarChar, 50).Value = description.Text;
                sqlCmd.Parameters.Add("@Worker_id", SqlDbType.Int).Value = workerId;
                sqlCmd.Parameters.Add("@Excursion_cost", SqlDbType.Float).Value = cost.Text;
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

            DataRowView row = excursionGrid.SelectedItem as DataRowView;
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            try
            {
                if (sqlConnection.State == ConnectionState.Closed)
                    sqlConnection.Open();
                String query = "Insert into Экскурсии(Дата, Название,Описание, [Код сотрудника], Цена) values(@Excursion_date, @Excursion_name,@Excursion_description,@Worker_id, @Excursion_cost)";
                SqlCommand sqlCmd = new SqlCommand(query, sqlConnection);
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.Parameters.Add("@Excursion_date", SqlDbType.VarChar, 50).Value = date.Text;
                sqlCmd.Parameters.Add("@Excursion_name", SqlDbType.VarChar, 50).Value = name.Text;
                sqlCmd.Parameters.Add("@Excursion_description", SqlDbType.VarChar, 50).Value = description.Text;
                sqlCmd.Parameters.Add("@Worker_id", SqlDbType.Int).Value = workerId;
                sqlCmd.Parameters.Add("@Excursion_cost", SqlDbType.Float).Value = cost.Text;


                sqlCmd.ExecuteNonQuery();
                MessageBox.Show("Запись добавлена успешно!");
                this.updateDataGrid();
                date.Text = "";
                description.Text = "";
                name.Text = "";
                cost.Text = "";
                chooseWorker.SelectedIndex = 0;


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {

            }

        }

        private void excursionGrid_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            DataGrid dg = sender as DataGrid;
            DataRowView dr = dg.SelectedItem as DataRowView;
            if (dr != null)
            {

                date.Text = dr["Дата"].ToString();
                string workerCode = dr["Код сотрудника"].ToString();
                chooseWorker.SelectedIndex = 0;
                for (int i = 0; i < chooseWorker.Items.Count; i++)
                {
                    if (Convert.ToString(chooseWorker.SelectedValue) == workerCode) break;
                    chooseWorker.SelectedIndex = i + 1;
                }
                name.Text = dr["Название экскурсии"].ToString();
                description.Text = dr["Описание экскурсии"].ToString();
                cost.Text = dr["Цена экскурсии"].ToString();
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
            name.Text = "";
            description.Text = "";
            cost.Text = "";
            chooseWorker.SelectedIndex = 0;

            add_btn.IsEnabled = true;
            update_btn.IsEnabled = false;
            delete_btn.IsEnabled = false;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            excursionGrid.Visibility = Visibility.Visible;
            form.Visibility = Visibility.Visible;
            view_data.Visibility = Visibility.Hidden;
            excursionGrid.Columns[0].Visibility = Visibility.Hidden;
            excursionGrid.Columns[5].Visibility = Visibility.Hidden;
            add_btn.IsEnabled = true;
        }



    }
}
