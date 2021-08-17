using DAL_ComputerRepair;
using Repository;
using System;
using System.Collections.Generic;
using System.Configuration;
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

namespace OrderManager
{
    /// <summary>
    /// Interaction logic for UpdateClient.xaml
    /// </summary>
    public partial class UpdateClient : Window
    {

        GenericUnitOfWork work;
        IGenericRepository<Client> repositoryClient;
        Client client;

        public UpdateClient()
        {
            InitializeComponent();

            work = new GenericUnitOfWork(new MyContextDb(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString));
            repositoryClient = work.Repository<Client>();
           
        }

        private void searchButton_Click(object sender, RoutedEventArgs e)
        {
            int id = Convert.ToInt32(searchTextBox.Text);
            if (string.IsNullOrEmpty(searchTextBox.Text))
            {
                MessageBox.Show("Empty search field!");
            }
            else
            {
                client = repositoryClient.FindById(id);
                if (client != null)
                {
                    clientNameTextBox.Text = client.Name;
                    clientSurnameTextBox.Text = client.Surname;
                    clientFatherNameTextBox.Text = client.FatherName;
                    clientPhoneNumberTextBox.Text = client.Phone;
                    clientAddressTextBox.Text = client.Address;

                }
            }
        }

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(clientNameTextBox.Text) &&
                !string.IsNullOrEmpty(clientSurnameTextBox.Text) &&
                !string.IsNullOrEmpty(clientFatherNameTextBox.Text) &&
                !string.IsNullOrEmpty(clientPhoneNumberTextBox.Text))
            {
                client.Name = clientNameTextBox.Text;
                client.Surname = clientSurnameTextBox.Text;
                client.FatherName = clientFatherNameTextBox.Text;
                client.Phone = clientPhoneNumberTextBox.Text;
                client.Address = clientAddressTextBox.Text;
                try
                {
                    repositoryClient.Update(client);
                    MessageBox.Show("Client successfully updated!", "Operation completed");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Not update!");
                }
            }
            else
            {
                MessageBox.Show("Check is there empty such field as : Name, Surname, FatherName, Phone. It's required field!", "Empty fields!");
            }
        }
    }
}
