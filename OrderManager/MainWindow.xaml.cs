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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OrderManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        GenericUnitOfWork work;
        IGenericRepository<Client> repositoryClient;
        IGenericRepository<Detail> repositoryDetail;
        IGenericRepository<DetailType> repositoryDetailType;
        IGenericRepository<Device> repositoryDevice;
        IGenericRepository<DeviceType> repositoryDeviceType;
        IGenericRepository<Employee> repositoryEmployee;
        IGenericRepository<Order> repositoryOrder;
        IGenericRepository<OrderStatus> repositoryOrderStatus;
        IGenericRepository<OrderType> repositoryOrderType;
        IGenericRepository<Position> repositoryPosition;
        IGenericRepository<UsedDetail> repositoryUsedDetail;

        //+380672683963
        public MainWindow()
        {
            InitializeComponent();
            work = new GenericUnitOfWork(new MyContextDb(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString));
            repositoryEmployee = work.Repository<Employee>();
            
            Login login = new Login(work, 3);
            System.Windows.Forms.DialogResult result = login.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                
            }
            else
            {
                
                Close();
            }
            repositoryClient = work.Repository<Client>();
            repositoryDetail = work.Repository<Detail>();
            repositoryDetailType = work.Repository<DetailType>();
            repositoryDevice = work.Repository<Device>();
            repositoryDeviceType = work.Repository<DeviceType>();
            repositoryOrder = work.Repository<Order>();
            repositoryOrderStatus = work.Repository<OrderStatus>();
            repositoryOrderType = work.Repository<OrderType>();
            repositoryPosition = work.Repository<Position>();
            repositoryUsedDetail = work.Repository<UsedDetail>();

            AddToGrids();
        }

        
        private void AddToGrids()
        {
            ordersGrid.ItemsSource = repositoryOrder.GetAll();
            clientsGrid.ItemsSource = repositoryClient.GetAll();
            devicesGrid.ItemsSource = repositoryDevice.GetAll();
            detailsGrid.ItemsSource = repositoryDetail.GetAll();

        }

        private void createOrderMenuItem_Click(object sender, RoutedEventArgs e)
        {
            CreateOrder createOrder = new CreateOrder();
            createOrder.Show();
        }

        private void updateOrderMenuItem_Click(object sender, RoutedEventArgs e)
        {
            UpdateOrder updateOrder = new UpdateOrder();
            updateOrder.Show();
        }

       


        private void createClient_Click(object sender, RoutedEventArgs e)
        {
            CreateClient createClient = new CreateClient();
            createClient.Show();
        }

        private void updateClient_Click(object sender, RoutedEventArgs e)
        {
            UpdateClient updateClient = new UpdateClient();
            updateClient.Show();
        }

      

     

        private void addDevice_Click(object sender, RoutedEventArgs e)
        {
            CreateDevice createDevice = new CreateDevice();
            createDevice.Show();
        }

        private void updateDevice_Click(object sender, RoutedEventArgs e)
        {
            UpdateDevice updateDevice = new UpdateDevice();
            updateDevice.Show();
        }
        private void refresh_Click(object sender, RoutedEventArgs e)
        {
            work = new GenericUnitOfWork(new MyContextDb(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString));
            repositoryClient = work.Repository<Client>();
            repositoryDetail = work.Repository<Detail>();
            repositoryDetailType = work.Repository<DetailType>();
            repositoryDevice = work.Repository<Device>();
            repositoryDeviceType = work.Repository<DeviceType>();
            repositoryEmployee = work.Repository<Employee>();
            repositoryOrder = work.Repository<Order>();
            repositoryOrderStatus = work.Repository<OrderStatus>();
            repositoryOrderType = work.Repository<OrderType>();
            repositoryPosition = work.Repository<Position>();
            repositoryUsedDetail = work.Repository<UsedDetail>();


            ordersGrid.ItemsSource = repositoryOrder.GetAll();
            clientsGrid.ItemsSource = repositoryClient.GetAll();
            devicesGrid.ItemsSource = repositoryDevice.GetAll();
            detailsGrid.ItemsSource = repositoryDetail.GetAll();
        }
    }
}
