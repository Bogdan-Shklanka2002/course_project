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

namespace DetailManager
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

            Login login = new Login(work, 4);
            System.Windows.Forms.DialogResult result = login.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                return;
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
            devicesGrid.ItemsSource = repositoryDevice.GetAll();
            detailsGrid.ItemsSource = repositoryDetail.GetAll();

        }

      
       
        private void addDetail_Click(object sender, RoutedEventArgs e)
        {
            DirectorApp.AddDetail addDetail = new DirectorApp.AddDetail();
            addDetail.Show();
        }

        private void updateDetail_Click(object sender, RoutedEventArgs e)
        {
            DirectorApp.UpdateDetail updateDetail = new DirectorApp.UpdateDetail();
            updateDetail.Show();
        }

        private void deleteDetail_Click(object sender, RoutedEventArgs e)
        {
            DirectorApp.DeleteDetail deleteDetail = new DirectorApp.DeleteDetail();
            deleteDetail.Show();
        }

        private void addDevice_Click(object sender, RoutedEventArgs e)
        {
            DirectorApp.CreateDevice createDevice = new DirectorApp.CreateDevice();
            createDevice.Show();
        }

        private void updateDevice_Click(object sender, RoutedEventArgs e)
        {
            DirectorApp.UpdateDevice updateDevice = new DirectorApp.UpdateDevice();
            updateDevice.Show();
        }

        private void deleteDevice_Click(object sender, RoutedEventArgs e)
        {
            DirectorApp.DeleteDevice deleteDevice = new DirectorApp.DeleteDevice();
            deleteDevice.Show();
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
            devicesGrid.ItemsSource = repositoryDevice.GetAll();
            detailsGrid.ItemsSource = repositoryDetail.GetAll();
        }
    }
}
