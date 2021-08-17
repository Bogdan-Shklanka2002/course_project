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
    /// Interaction logic for CreateOrder.xaml
    /// </summary>
    public partial class CreateOrder : Window
    {
        GenericUnitOfWork work;
        IGenericRepository<Client> repositoryClient;
        IGenericRepository<Order> repositoryOrder;
        IGenericRepository<OrderStatus> repositoryOrderStatus;
        IGenericRepository<OrderType> repositoryOrderType;
        IGenericRepository<Device> repositoryDevice;
        IGenericRepository<Employee> repositoryEmployee;


        Client clientToAdd;
        public CreateOrder()
        {
            InitializeComponent();
            addClient.IsEnabled = false;
            work = new GenericUnitOfWork(new MyContextDb(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString));
            repositoryClient = work.Repository<Client>();
            repositoryOrder = work.Repository<Order>();
            repositoryOrderStatus = work.Repository<OrderStatus>();
            repositoryOrderType = work.Repository<OrderType>();
            repositoryDevice = work.Repository<Device>();
            repositoryEmployee = work.Repository<Employee>();
            FillCombo();
        }

        private void FillCombo()
        {
            statusComboBox.ItemsSource = repositoryOrderStatus.GetAll();
            typeOrderComboBox.ItemsSource = repositoryOrderType.GetAll();
            deviceComboBox.ItemsSource = repositoryDevice.GetAll();
            workmanComboBox.ItemsSource = repositoryEmployee.FindAll(x => x.IdPosition == 2).ToList();

        }
        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if (isNewClient.IsChecked == true)
            {
                //searchGrid.IsEnabled = false;
                addClient.IsEnabled = true;
            }
            else
            {
                searchGrid.IsEnabled = true;
                addClient.IsEnabled = false;
            }


        }

        private void addClient_Click(object sender, RoutedEventArgs e)
        {
            CreateClient createClient = new CreateClient();
            createClient.Show();
            if (createClient.Client != null)
            {
                clientToAdd = createClient.Client;
                MessageBox.Show("Client added to order.");
            }
        }

        private void searchClient_Click(object sender, RoutedEventArgs e)
        {
            string phone = searchTextBox.Text;
            Client client = repositoryClient.FindAll(x => x.Phone.Contains(phone)).FirstOrDefault();
            if (client != null)
            {
                MessageBoxResult res = MessageBox.Show($"Client is found. {client.Name} {client.Surname}. Do you want to add him to order?", "Result of searching", MessageBoxButton.YesNo);
                if (res == MessageBoxResult.Yes)
                {
                    clientToAdd = client;
                }
            }
        }


        private void createOrder_Click(object sender, RoutedEventArgs e)
        {
            Device device = deviceComboBox.SelectedItem as Device;
            OrderType orderType = typeOrderComboBox.SelectedItem as OrderType;
            OrderStatus orderStatus = statusComboBox.SelectedItem as OrderStatus;
            DateTime date = dateOrder.SelectedDate.Value;
            string description = descriptionTextBox.Text;
            Employee workman = workmanComboBox.SelectedItem as Employee;
            int price = Convert.ToInt32(priceTextBox.Text);

            if (device != null && 
                orderType != null && 
                orderStatus != null && 
                date != null && 
                description != null && 
                workman != null &&
                priceTextBox.Text != null )
            {
                repositoryOrder.Add(new Order
                {
                    Device = device,
                    IdDevice = device.Id,
                    OrderStatus = orderStatus,
                    IdOrderStatus = orderStatus.Id,
                    OrderType = orderType,
                    IdOrderType = orderType.Id,
                    OrderDate = date,
                    Description = description,
                    TotalPrice = price,
                    Workman = workman,
                    IdWorkman = workman.Id,
                    Client = clientToAdd,
                    IdClient = clientToAdd.Id
                });
                MessageBox.Show("Order successfully added!", "Operation completed");
            }
        }
    }
}
