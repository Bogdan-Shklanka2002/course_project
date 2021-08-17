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
    /// Interaction logic for CreateClient.xaml
    /// </summary>
    public partial class CreateClient : Window
    {
        GenericUnitOfWork work;
        IGenericRepository<Client> repositoryClient;
        public Client Client { get; set; }
        public CreateClient()
        {
            InitializeComponent();
            work = new GenericUnitOfWork(new MyContextDb(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString));
            repositoryClient = work.Repository<Client>();
        }

        private void addClient_Click(object sender, RoutedEventArgs e)
        {
            string name = clientNameTextBox.Text;
            string surname = clientSurnameTextBox.Text;
            string fatherName = clientFatherNameTextBox.Text;
            string phone = clientPhoneNumberTextBox.Text;
            string address = clientAddressTextBox.Text;

            if (!String.IsNullOrEmpty(name) && !String.IsNullOrEmpty(surname) && !String.IsNullOrEmpty(fatherName) && !String.IsNullOrEmpty(phone))
            {
                
                repositoryClient.Add(new Client { Name = name, Surname = surname, FatherName = fatherName, Phone = phone, Address = address });
                Client = new Client { Name = name, Surname = surname, FatherName = fatherName, Phone = phone, Address = address };
                MessageBox.Show("Successfully added!", "Operation completed");
            }
            else
            {
                MessageBox.Show("Check is there empty such field as : Name, Surname, FatherName, Phone. It's required field","Empty fields");
            }
        }
    }
}
