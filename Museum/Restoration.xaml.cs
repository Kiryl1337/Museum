using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows;

using System.Windows.Controls;

namespace Museum
{

    public partial class Restoration : Window
    {
        private int workerId;
        private int exhibitId;

        string connectionString;
        public Restoration()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            SqlConnection sqlConnection = new SqlConnection(connectionString);
            try
            {
                if (sqlConnection.State == ConnectionState.Closed)
                    sqlConnection.Open();
                String query = "Select * from viewРеставрация ";

                SqlCommand sqlCmd = new SqlCommand(query, sqlConnection);
                sqlCmd.CommandType = CommandType.Text;

                DataTable data = new DataTable();

                SqlDataAdapter adapter = new SqlDataAdapter(sqlCmd);

                adapter.Fill(data);
                restorationGrid.DataContext = data.DefaultView;

                String query1 = "Select Код, Название from Экспонаты order by 1";
                SqlCommand sqlCmd1 = new SqlCommand(query1, sqlConnection);
                sqlCmd1.CommandType = CommandType.Text;
                DataTable data1 = new DataTable();
                SqlDataAdapter adapter1 = new SqlDataAdapter(sqlCmd1);
                adapter1.Fill(data1);
                chooseExhibitName.Items.Clear();
                foreach (DataRow row in data1.Rows)
                {
                    chooseExhibitName.Items.Add(new
                    {
                        Exhibit_Info = row["Название"].ToString(),
                        Exhibit_Code = row["Код"].ToString()
                    });

                }

                String query2 = "Select Сотрудники.Код, ФИО from Сотрудники, Должность where Сотрудники.[Код должности]=Должность.Код and Название='Реставратор' order by 1";
                SqlCommand sqlCmd2 = new SqlCommand(query2, sqlConnection);
                sqlCmd2.CommandType = CommandType.Text;
                DataTable data2 = new DataTable();
                SqlDataAdapter adapter2 = new SqlDataAdapter(sqlCmd2);
                adapter2.Fill(data2);
                chooseWorkerFIO.Items.Clear();
                foreach (DataRow row in data2.Rows)
                {
                    chooseWorkerFIO.Items.Add(new
                    {
                        Worker_Info = row["ФИО"].ToString(),
                        Worker_Code = row["Код"].ToString()
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



        private void chooseExhibitName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            exhibitId = Convert.ToInt16(chooseExhibitName.SelectedValue.ToString());
        }


        private void chooseWorkerFIO_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            workerId = Convert.ToInt16(chooseWorkerFIO.SelectedValue.ToString());
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
                String query = "Select * from viewРеставрация";
                SqlCommand sqlCmd = new SqlCommand(query, sqlConnection);
                sqlCmd.CommandType = CommandType.Text;

                SqlDataReader dr = sqlCmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);


                restorationGrid.ItemsSource = dt.DefaultView;
                dr.Close();
                restorationGrid.Columns[0].Visibility = Visibility.Hidden;
                restorationGrid.Columns[4].Visibility = Visibility.Hidden;
                restorationGrid.Columns[5].Visibility = Visibility.Hidden;


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
            DataRowView row = restorationGrid.SelectedItem as DataRowView;
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            try
            {
                if (sqlConnection.State == ConnectionState.Closed)
                    sqlConnection.Open();
                String query = "Delete from Реставрация where Код = @Restoration_id";
                SqlCommand sqlCmd = new SqlCommand(query, sqlConnection);
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.Parameters.Add("@Restoration_id", SqlDbType.Int).Value = Convert.ToInt16(row.Row.ItemArray[0].ToString());

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

            DataRowView row = restorationGrid.SelectedItem as DataRowView;
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            try
            {
                if (sqlConnection.State == ConnectionState.Closed)
                    sqlConnection.Open();
                String query = "UpdateРеставрация";
                SqlCommand sqlCmd = new SqlCommand(query, sqlConnection);
                sqlCmd.CommandType = System.Data.CommandType.StoredProcedure;
                sqlCmd.Parameters.Add("@Restoration_id", SqlDbType.Int).Value = Convert.ToInt16(row.Row.ItemArray[0].ToString());
                sqlCmd.Parameters.Add("@Restoration_date", SqlDbType.Date).Value = date.Text;
                sqlCmd.Parameters.Add("@Exhibit_id", SqlDbType.Int).Value = exhibitId;
                sqlCmd.Parameters.Add("@Worker_id", SqlDbType.VarChar, 50).Value = workerId;
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

            DataRowView row = restorationGrid.SelectedItem as DataRowView;
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            try
            {
                if (sqlConnection.State == ConnectionState.Closed)
                    sqlConnection.Open();
                String query = "Insert into Реставрация(Дата, [Код экспоната], [Код сотрудника]) values(@Restoration_date, @Exhibit_id, @Worker_id)";
                SqlCommand sqlCmd = new SqlCommand(query, sqlConnection);
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.Parameters.Add("@Restoration_date", SqlDbType.VarChar, 50).Value = date.Text;
                sqlCmd.Parameters.Add("@Exhibit_id", SqlDbType.Int).Value = exhibitId;
                sqlCmd.Parameters.Add("@Worker_id", SqlDbType.VarChar, 50).Value = workerId;

                sqlCmd.ExecuteNonQuery();
                MessageBox.Show("Запись добавлена успешно!");
                this.updateDataGrid();
                this.resetAll();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }

        private void restorationGrid_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            DataGrid dg = sender as DataGrid;
            DataRowView dr = dg.SelectedItem as DataRowView;
            if (dr != null)
            {

                date.Text = dr["Дата"].ToString();
                string exhibitCode = dr["Код экспоната"].ToString();
                chooseExhibitName.SelectedIndex = 0;
                for (int i = 0; i < chooseExhibitName.Items.Count; i++)
                {
                    if (Convert.ToString(chooseExhibitName.SelectedValue) == exhibitCode) break;
                    chooseExhibitName.SelectedIndex = i + 1;
                }
                string workerCode = dr["Код сотрудника"].ToString();
                chooseWorkerFIO.SelectedIndex = 0;
                for (int i = 0; i < chooseWorkerFIO.Items.Count; i++)
                {
                    if (Convert.ToString(chooseWorkerFIO.SelectedValue) == workerCode) break;
                    chooseWorkerFIO.SelectedIndex = i + 1;
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
            chooseExhibitName.SelectedIndex = 0;
            chooseWorkerFIO.SelectedIndex = 0;

            add_btn.IsEnabled = true;
            update_btn.IsEnabled = false;
            delete_btn.IsEnabled = false;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            restorationGrid.Visibility = Visibility.Visible;
            form.Visibility = Visibility.Visible;
            view_data.Visibility = Visibility.Hidden;
            restorationGrid.Columns[0].Visibility = Visibility.Hidden;
            restorationGrid.Columns[4].Visibility = Visibility.Hidden;
            restorationGrid.Columns[5].Visibility = Visibility.Hidden;

            add_btn.IsEnabled = true;
        }



    }
}
