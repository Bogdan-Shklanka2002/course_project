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
    /// Interaction logic for UpdateOrder.xaml
    /// </summary>
    public partial class UpdateOrder : Window
    {

        GenericUnitOfWork work;
        IGenericRepository<Client> repositoryClient;
        IGenericRepository<Order> repositoryOrder;
        IGenericRepository<OrderStatus> repositoryOrderStatus;
        IGenericRepository<OrderType> repositoryOrderType;
        IGenericRepository<Device> repositoryDevice;
        IGenericRepository<Employee> repositoryEmployee;
        Order order;
        Client client;
        public UpdateOrder()
        {
            InitializeComponent();

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


        private void searchButton_Click(object sender, RoutedEventArgs e)
        {
            int id = Convert.ToInt32(searchTextBox.Text);
            if (string.IsNullOrEmpty(searchTextBox.Text))
            {
                MessageBox.Show("Empty search field!");
            }
            else
            {
                order = repositoryOrder.FindById(id);
                deviceComboBox.SelectedItem = repositoryDevice.FindAll(x => x.Id == order.IdDevice).FirstOrDefault();
                statusComboBox.SelectedItem = repositoryOrderStatus.FindAll(x => x.Id == order.IdOrderStatus).FirstOrDefault();
                typeOrderComboBox.SelectedItem = repositoryOrderType.FindAll(x => x.Id == order.IdOrderType).FirstOrDefault();
                workmanComboBox.SelectedItem = repositoryEmployee.FindAll(x => x.Id == order.IdWorkman).FirstOrDefault();
                dateOrder.SelectedDate = order.OrderDate;
                client = repositoryClient.FindAll(x => x.Id == order.IdClient).FirstOrDefault();
                if (client != null)
                {
                    clientNameTextBox.Text = client.Name;
                    clientSurnameTextBox.Text = client.Surname;
                    clientFatherNameTextBox.Text = client.FatherName;
                    clientPhoneNumberTextBox.Text = client.Phone;
                    clientAddressTextBox.Text = client.Address;
                }
                descriptionTextBox.Text = order.Description;
            }
        }

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            Device device = deviceComboBox.SelectedItem as Device;
            OrderType orderType = typeOrderComboBox.SelectedItem as OrderType;
            OrderStatus orderStatus = statusComboBox.SelectedItem as OrderStatus;
            DateTime date = dateOrder.SelectedDate.Value;
            string description = descriptionTextBox.Text;
            order.Device = device;
            order.IdDevice = device.Id;
            order.OrderStatus = orderStatus;
            order.IdOrderStatus = orderStatus.Id;
            order.OrderType = orderType;
            order.IdOrderType = orderType.Id;
            order.OrderDate = date;
            order.Description = description;
            order.Client = client;
            order.IdClient = client.Id;

            try
            {
            repositoryOrder.Update(order);
                MessageBox.Show("Order successfully updated!", "Operation completed");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Not update!");
            }

        }
    }
}