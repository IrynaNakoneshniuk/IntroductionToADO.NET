using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Employee> employees;
        public MainWindow()
        {
            InitializeComponent();
            employees = new List<Employee>();
        }

        private void loadButton_Click(object sender, RoutedEventArgs e)
        {
            string? ConnectionStr = @"Data Source=DESKTOP-LRIFAQL;Initial Catalog=Shop;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Encrypt=False;TrustServerCertificate=False";
            SqlConnection connection = new SqlConnection(ConnectionStr);
            try
            {
                connection.Open();
                string? Command = @"SELECT * FROM Employee";
                SqlCommand command =new SqlCommand(Command, connection);
                SqlDataReader sqlDataReader = command.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    employees.Add(new Employee(sqlDataReader.GetInt32(0), sqlDataReader.GetString(1), 
                        sqlDataReader.GetString(2),sqlDataReader.GetInt32(3)));
                }
                MessageBox.Show("Connect with database");
                connection.Close();
            }
            catch (SqlException ex)
            {  
                StringBuilder errorMessages = new StringBuilder();
                for (int i = 0; i < ex.Errors.Count; i++)
                {
                    errorMessages.Append("Index #" + i + "\n" +
                        "Message: " + ex.Errors[i].Message + "\n" +
                        "LineNumber: " + ex.Errors[i].LineNumber + "\n" +
                        "Source: " + ex.Errors[i].Source + "\n" +
                        "Procedure: " + ex.Errors[i].Procedure + "\n");
                }
                MessageBox.Show(errorMessages.ToString());
            }
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void AllInformationButton_Click(object sender, RoutedEventArgs e)
        {
            dgEmployee.ItemsSource=employees;
        }

        private void Click_Sort_ByRang(object sender, RoutedEventArgs e)
        {
            try
            {
                dgEmployee.ItemsSource = null;
                employees = employees.OrderBy(x => x.Rang).ToList();
                dgEmployee.ItemsSource = employees;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
           
        }

        private void Click_Sort_ByName(object sender, RoutedEventArgs e)
        {
            try
            {
                dgEmployee.ItemsSource = null;
                employees = employees.OrderBy(x => x.Name).ToList();
                dgEmployee.ItemsSource = employees;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
