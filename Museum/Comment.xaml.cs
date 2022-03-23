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

    public partial class Comment : Window
    {
        private int excursionId;
        string connectionString;
        public Comment()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            SqlConnection sqlConnection = new SqlConnection(connectionString);
            try
            {
                if (sqlConnection.State == ConnectionState.Closed)
                    sqlConnection.Open();
                String query = "Select * from viewОтзыв";

                SqlCommand sqlCmd = new SqlCommand(query, sqlConnection);
                sqlCmd.CommandType = CommandType.Text;

                DataTable data = new DataTable();

                SqlDataAdapter adapter = new SqlDataAdapter(sqlCmd);

                adapter.Fill(data);
                commentGrid.DataContext = data.DefaultView;

                String query1 = "Select Код, Название from Экскурсии order by 1";
                SqlCommand sqlCmd1 = new SqlCommand(query1, sqlConnection);
                sqlCmd1.CommandType = CommandType.Text;
                DataTable data1 = new DataTable();
                SqlDataAdapter adapter1 = new SqlDataAdapter(sqlCmd1);
                adapter1.Fill(data1);
                chooseExcursion.Items.Clear();
                foreach (DataRow r in data1.Rows)
                {
                    chooseExcursion.Items.Add(new
                    {
                        Excursion_Info = r["Название"].ToString(),
                        Excursion_Code = r["Код"].ToString()
                    });

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }



        private void chooseExcursion_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            excursionId = Convert.ToInt16(chooseExcursion.SelectedValue.ToString());
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
                String query = "Select * from viewОтзыв";
                SqlCommand sqlCmd = new SqlCommand(query, sqlConnection);
                sqlCmd.CommandType = CommandType.Text;

                SqlDataReader dr = sqlCmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);


                commentGrid.ItemsSource = dt.DefaultView;
                dr.Close();
                commentGrid.Columns[0].Visibility = Visibility.Hidden;
                commentGrid.Columns[3].Visibility = Visibility.Hidden;
                chooseExcursion.SelectedIndex = 0;
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
            DataRowView row = commentGrid.SelectedItem as DataRowView;
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            try
            {
                if (sqlConnection.State == ConnectionState.Closed)
                    sqlConnection.Open();
                String query = "Delete from Отзыв where Код = @Comment_id";
                SqlCommand sqlCmd = new SqlCommand(query, sqlConnection);
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.Parameters.Add("@Comment_id", SqlDbType.Int).Value = Convert.ToInt16(row.Row.ItemArray[0].ToString());

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

            DataRowView row = commentGrid.SelectedItem as DataRowView;
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            try
            {
                if (sqlConnection.State == ConnectionState.Closed)
                    sqlConnection.Open();
                String query = "UpdateОтзыв";
                SqlCommand sqlCmd = new SqlCommand(query, sqlConnection);
                sqlCmd.CommandType = System.Data.CommandType.StoredProcedure;
                sqlCmd.Parameters.Add("@Comment_id", SqlDbType.Int).Value = Convert.ToInt16(row.Row.ItemArray[0].ToString());
                sqlCmd.Parameters.Add("@Comment_text", SqlDbType.VarChar, 100).Value = text.Text;
                sqlCmd.Parameters.Add("@Excursion_id", SqlDbType.Int).Value = excursionId;
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

            DataRowView row = commentGrid.SelectedItem as DataRowView;
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            try
            {
                if (sqlConnection.State == ConnectionState.Closed)
                    sqlConnection.Open();
                String query = "Insert into Отзыв(Текст, [Код экскурсии]) values(@Comment_text,@Excursion_id)";
                SqlCommand sqlCmd = new SqlCommand(query, sqlConnection);
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.Parameters.Add("@Comment_text", SqlDbType.VarChar, 50).Value = text.Text;
                sqlCmd.Parameters.Add("@Excursion_id", SqlDbType.Int).Value = excursionId;


                sqlCmd.ExecuteNonQuery();
                MessageBox.Show("Запись добавлена успешно!");
                this.updateDataGrid();
                text.Text = "";
                



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {

            }

        }

        private void commentGrid_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            DataGrid dg = sender as DataGrid;
            DataRowView dr = dg.SelectedItem as DataRowView;
            if (dr != null)
            {

                text.Text = dr["Текст"].ToString();
                string excursionCode = dr["Код экскурсии"].ToString();
                chooseExcursion.SelectedIndex = 0;
                for (int i = 0; i < chooseExcursion.Items.Count; i++)
                {
                    if (Convert.ToString(chooseExcursion.SelectedValue) == excursionCode) break;
                    chooseExcursion.SelectedIndex = i + 1;
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

            text.Text = "";
            chooseExcursion.SelectedIndex = 0;
            add_btn.IsEnabled = true;
            update_btn.IsEnabled = false;
            delete_btn.IsEnabled = false;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            commentGrid.Visibility = Visibility.Visible;
            form.Visibility = Visibility.Visible;
            view_data.Visibility = Visibility.Hidden;
            commentGrid.Columns[0].Visibility = Visibility.Hidden;
            commentGrid.Columns[3].Visibility = Visibility.Hidden;
            add_btn.IsEnabled = true;
        }



    }
}
