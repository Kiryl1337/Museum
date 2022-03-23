using System;
using System.Collections.Generic;
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

    public partial class MainForm : Window
    {
        public MainForm()
        {
            InitializeComponent();
            var timer = new System.Windows.Threading.DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.IsEnabled = true;
            timer.Tick += (o, t) => { label1.Content = DateTime.Now.ToString(); };
            timer.Start();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            VisitorLogin visitor = new VisitorLogin();
            visitor.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            AdminLogin adminLogin= new AdminLogin();
            adminLogin.Show();
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            WorkerLogin workerLoginForm = new WorkerLogin();
            workerLoginForm.Show();
            this.Close();
        }
    }
}
