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

namespace DirectorApp
{
    /// <summary>
    /// Interaction logic for DeleteClient.xaml
    /// </summary>
    public partial class DeleteClient : Window
    {
        GenericUnitOfWork work;
        IGenericRepository<Client> repositoryClient;
        Client client;
        public DeleteClient()
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
                    clientNameTextBlock.Text = client.Name;
                    clientSurnameTextBlock.Text = client.Surname;
                    clientFatherNameTextBlock.Text = client.FatherName;
                    clientPhoneNumberTextBlock.Text = client.Phone;
                    clientAddressTextBlock.Text = client.Address;

                }
            }
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Do you want to delete this client?", "Delete client", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {

                try
                {
                    repositoryClient.Remove(client);
                    MessageBox.Show("Client successfully deleted!", "Operation completed");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Not delete!");
                }

            }
        }
    }
}
