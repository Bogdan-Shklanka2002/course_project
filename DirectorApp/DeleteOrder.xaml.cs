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
    /// Interaction logic for DeleteOrder.xaml
    /// </summary>
    public partial class DeleteOrder : Window
    {
        GenericUnitOfWork work;
        IGenericRepository<Client> repositoryClient;
        IGenericRepository<Order> repositoryOrder;
        IGenericRepository<OrderStatus> repositoryOrderStatus;
        IGenericRepository<OrderType> repositoryOrderType;
        IGenericRepository<Device> repositoryDevice;
        Order order;
        Client client;
        public DeleteOrder()
        {
            InitializeComponent();

            work = new GenericUnitOfWork(new MyContextDb(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString));
            repositoryClient = work.Repository<Client>();
            repositoryOrder = work.Repository<Order>();
            repositoryOrderStatus = work.Repository<OrderStatus>();
            repositoryOrderType = work.Repository<OrderType>();
            repositoryDevice = work.Repository<Device>();

            
        }

        private void searchOrderButton_Click(object sender, RoutedEventArgs e)
        {
            int id = Convert.ToInt32(searchOrderTextBox.Text);
            if (string.IsNullOrEmpty(searchOrderTextBox.Text))
            {
                MessageBox.Show("Empty search field!");
            }
            else
            {
                order = repositoryOrder.FindById(id);
                deviceTextBox.Text = repositoryDevice.FindById(order.IdDevice).ToString();
                statusOrderTextBox.Text = repositoryOrderStatus.FindById(order.IdOrderStatus).ToString();
                typeOrderTextBox.Text = repositoryOrderType.FindById(order.IdOrderType).ToString();
                orderDateTextBox.Text = order.OrderDate.ToString();
                client = repositoryClient.FindAll(x => x.Id == order.IdClient).FirstOrDefault();

               
                if (client != null)
                {
                    clientNameAndSurnameTextBlock.Text = client.Name + " " + client.Surname;
                    clientPhoneTextBlock.Text = client.Phone;
                }
            }
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Do you want to delete this order?", "Delete order", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {

                try
                {
                    repositoryOrder.Remove(order);
                    MessageBox.Show("Order successfully deleted!", "Operation completed");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Not delete!");
                }

            }
        }
    }
}
