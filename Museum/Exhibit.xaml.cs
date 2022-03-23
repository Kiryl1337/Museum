using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows;

using System.Windows.Controls;

namespace Museum
{

    public partial class Exhibit : Window
    {
        private int formOfExhibitId;
        private int roomId;
        private int authorId;
        string connectionString;
        public Exhibit()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            SqlConnection sqlConnection = new SqlConnection(connectionString);
            try
            {
                if (sqlConnection.State == ConnectionState.Closed)
                    sqlConnection.Open();
                String query = "Select * from viewЭкспонат";

                SqlCommand sqlCmd = new SqlCommand(query, sqlConnection);
                sqlCmd.CommandType = CommandType.Text;

                DataTable data = new DataTable();

                SqlDataAdapter adapter = new SqlDataAdapter(sqlCmd);

                adapter.Fill(data);
                exhibitGrid.DataContext = data.DefaultView;

                String query1 = "Select Код, [Вид экспоната] from Вид_экспоната order by 1";
                SqlCommand sqlCmd1 = new SqlCommand(query1, sqlConnection);
                sqlCmd1.CommandType = CommandType.Text;
                DataTable data1 = new DataTable();
                SqlDataAdapter adapter1 = new SqlDataAdapter(sqlCmd1);
                adapter1.Fill(data1);
                chooseFormOfExhibit.Items.Clear();
                foreach (DataRow row in data1.Rows)
                {
                    chooseFormOfExhibit.Items.Add(new
                    {
                        FormOfExhibit_Info = row["Вид экспоната"].ToString(),
                        FormOfExhibit_Code = row["Код"].ToString()
                    });

                }

                String query2 = "Select Код, Название from Залы order by 1";
                SqlCommand sqlCmd2 = new SqlCommand(query2, sqlConnection);
                sqlCmd2.CommandType = CommandType.Text;
                DataTable data2 = new DataTable();
                SqlDataAdapter adapter2 = new SqlDataAdapter(sqlCmd2);
                adapter2.Fill(data2);
                chooseRoomName.Items.Clear();
                foreach (DataRow row in data2.Rows)
                {
                    chooseRoomName.Items.Add(new
                    {
                        Room_Info = row["Название"].ToString(),
                        Room_Code = row["Код"].ToString()
                    });

                }

                String query3 = "Select Код, ФИО from Автор order by 1";
                SqlCommand sqlCmd3 = new SqlCommand(query3, sqlConnection);
                sqlCmd3.CommandType = CommandType.Text;
                DataTable data3 = new DataTable();
                SqlDataAdapter adapter3 = new SqlDataAdapter(sqlCmd3);
                adapter3.Fill(data3);
                chooseAuthorFIO.Items.Clear();
                foreach (DataRow row in data3.Rows)
                {
                    chooseAuthorFIO.Items.Add(new
                    {
                        Author_Info = row["ФИО"].ToString(),
                        Author_Code = row["Код"].ToString()
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



        private void chooseFormOfExhibit_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            formOfExhibitId = Convert.ToInt16(chooseFormOfExhibit.SelectedValue.ToString());
        }
        

         private void chooseRoomName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            roomId = Convert.ToInt16(chooseRoomName.SelectedValue.ToString());
        }
        private void chooseAuthorFIO_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            authorId = Convert.ToInt16(chooseAuthorFIO.SelectedValue.ToString());
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
                String query = "Select * from viewЭкспонат";
                SqlCommand sqlCmd = new SqlCommand(query, sqlConnection);
                sqlCmd.CommandType = CommandType.Text;

                SqlDataReader dr = sqlCmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);


                exhibitGrid.ItemsSource = dt.DefaultView;
                dr.Close();
                exhibitGrid.Columns[0].Visibility = Visibility.Hidden;
                exhibitGrid.Columns[5].Visibility = Visibility.Hidden;
                exhibitGrid.Columns[6].Visibility = Visibility.Hidden;
                exhibitGrid.Columns[7].Visibility = Visibility.Hidden;

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
            DataRowView row = exhibitGrid.SelectedItem as DataRowView;
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            try
            {
                if (sqlConnection.State == ConnectionState.Closed)
                    sqlConnection.Open();
                String query = "Delete from Экспонаты where Код = @Exhibit_id";
                SqlCommand sqlCmd = new SqlCommand(query, sqlConnection);
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.Parameters.Add("@Exhibit_id", SqlDbType.Int).Value = Convert.ToInt16(row.Row.ItemArray[0].ToString());

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

            DataRowView row = exhibitGrid.SelectedItem as DataRowView;
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            try
            {
                if (sqlConnection.State == ConnectionState.Closed)
                    sqlConnection.Open();
                String query = "Update Экспонаты set Название = @Exhibit_name, [Код вида экспоната]=@FormOfExhibit_id, [Код зала]=@Room_id,[Код автора]=@Author_id where Код = @Exhibit_id";
                SqlCommand sqlCmd = new SqlCommand(query, sqlConnection);
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.Parameters.Add("@Exhibit_id", SqlDbType.Int).Value = Convert.ToInt16(row.Row.ItemArray[0].ToString());
                sqlCmd.Parameters.Add("@Exhibit_name", SqlDbType.VarChar, 50).Value = name.Text;
                sqlCmd.Parameters.Add("@FormOfExhibit_id", SqlDbType.Int).Value = formOfExhibitId;
                sqlCmd.Parameters.Add("@Room_id", SqlDbType.VarChar, 50).Value = roomId;
                sqlCmd.Parameters.Add("@Author_id", SqlDbType.VarChar, 50).Value = authorId;
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

            DataRowView row = exhibitGrid.SelectedItem as DataRowView;
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            try
            {
                if (sqlConnection.State == ConnectionState.Closed)
                    sqlConnection.Open();
                String query = "Insert into Экспонаты(Название, [Код вида экспоната], [Код зала], [Код автора]) values(@Exhibit_name, @FormOfExhibit_id, @Room_id, @Author_id)";
                SqlCommand sqlCmd = new SqlCommand(query, sqlConnection);
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.Parameters.Add("@Exhibit_name", SqlDbType.VarChar, 50).Value = name.Text;
                sqlCmd.Parameters.Add("@FormOfExhibit_id", SqlDbType.Int).Value = formOfExhibitId;
                sqlCmd.Parameters.Add("@Room_id", SqlDbType.VarChar, 50).Value = roomId;
                sqlCmd.Parameters.Add("@Author_id", SqlDbType.VarChar, 50).Value = authorId;

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

        private void exhibitGrid_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            DataGrid dg = sender as DataGrid;
            DataRowView dr = dg.SelectedItem as DataRowView;
            if (dr != null)
            {

                name.Text = dr["Название экспоната"].ToString();
                string formOfExhibitCode = dr["Код вида экспоната"].ToString();
                chooseFormOfExhibit.SelectedIndex = 0;
                for (int i = 0; i < chooseFormOfExhibit.Items.Count; i++)
                {
                    if (Convert.ToString(chooseFormOfExhibit.SelectedValue) == formOfExhibitCode) break;
                    chooseFormOfExhibit.SelectedIndex = i + 1;
                }
                string roomCode = dr["Код зала"].ToString();
                chooseRoomName.SelectedIndex = 0;
                for (int i = 0; i < chooseRoomName.Items.Count; i++)
                {
                    if (Convert.ToString(chooseRoomName.SelectedValue) == roomCode) break;
                    chooseRoomName.SelectedIndex = i + 1;
                }
                string authorCode = dr["Код автора"].ToString();
                chooseAuthorFIO.SelectedIndex = 0;
                for (int i = 0; i < chooseAuthorFIO.Items.Count; i++)
                {
                    if (Convert.ToString(chooseAuthorFIO.SelectedValue) == authorCode) break;
                    chooseAuthorFIO.SelectedIndex = i + 1;
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

            name.Text = "";
            chooseFormOfExhibit.SelectedIndex = 0;
            chooseAuthorFIO.SelectedIndex = 0;
            chooseRoomName.SelectedIndex = 0;

            add_btn.IsEnabled = true;
            update_btn.IsEnabled = false;
            delete_btn.IsEnabled = false;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            exhibitGrid.Visibility = Visibility.Visible;
            form.Visibility = Visibility.Visible;
            view_data.Visibility = Visibility.Hidden;
            exhibitGrid.Columns[0].Visibility = Visibility.Hidden;
            exhibitGrid.Columns[5].Visibility = Visibility.Hidden;
            exhibitGrid.Columns[6].Visibility = Visibility.Hidden;
            exhibitGrid.Columns[7].Visibility = Visibility.Hidden;
            add_btn.IsEnabled = true;
        }



    }
}
