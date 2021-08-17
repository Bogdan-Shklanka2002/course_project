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

namespace WorkmanApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        GenericUnitOfWork work;

        IGenericRepository<Detail> repositoryDetail;
        IGenericRepository<DetailType> repositoryDetailType;
        IGenericRepository<Device> repositoryDevice;
        IGenericRepository<DeviceType> repositoryDeviceType;
        IGenericRepository<Order> repositoryOrder;
        IGenericRepository<OrderStatus> repositoryOrderStatus;
        IGenericRepository<OrderType> repositoryOrderType;
        IGenericRepository<UsedDetail> repositoryUsedDetail;
        IGenericRepository<Employee> repositoryEmployee;

        //+380672683963
        public MainWindow()
        {
            InitializeComponent();

            work = new GenericUnitOfWork(new MyContextDb(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString));
            repositoryEmployee = work.Repository<Employee>();
            
            Login login = new Login(work, 2);
            System.Windows.Forms.DialogResult result = login.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                return;
            }
            else
            {

                Close();
            }


            repositoryDetail = work.Repository<Detail>();
            repositoryDetailType = work.Repository<DetailType>();
            repositoryDevice = work.Repository<Device>();
            repositoryDeviceType = work.Repository<DeviceType>();
            repositoryOrder = work.Repository<Order>();
            repositoryOrderStatus = work.Repository<OrderStatus>();
            repositoryOrderType = work.Repository<OrderType>();
            repositoryUsedDetail = work.Repository<UsedDetail>();

            AddToGrids();
        }

        private void AddToGrids()
        {
            ordersGrid.ItemsSource = repositoryOrder.GetAll();

            devicesGrid.ItemsSource = repositoryDevice.GetAll();
            detailsGrid.ItemsSource = repositoryDetail.GetAll();

        }

        private void updateOrderMenuItem_Click(object sender, RoutedEventArgs e)
        {
            DirectorApp.UpdateOrder updateOrder = new DirectorApp.UpdateOrder();
            updateOrder.Show();
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



        private void refresh_Click(object sender, RoutedEventArgs e)
        {
            work = new GenericUnitOfWork(new MyContextDb(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString));

            repositoryDetail = work.Repository<Detail>();
            repositoryDetailType = work.Repository<DetailType>();
            repositoryDevice = work.Repository<Device>();
            repositoryDeviceType = work.Repository<DeviceType>();
            repositoryOrder = work.Repository<Order>();
            repositoryOrderStatus = work.Repository<OrderStatus>();
            repositoryOrderType = work.Repository<OrderType>();
            repositoryUsedDetail = work.Repository<UsedDetail>();



            ordersGrid.ItemsSource = repositoryOrder.GetAll();
            devicesGrid.ItemsSource = repositoryDevice.GetAll();
            detailsGrid.ItemsSource = repositoryDetail.GetAll();
            usedDetailsGrid.ItemsSource = repositoryUsedDetail.GetAll();
        }

        private void addDetailOrder_Click(object sender, RoutedEventArgs e)
        {
            AddOrderDetail add = new AddOrderDetail();
            add.Show();
        }

        private void updateDetailOrder_Click(object sender, RoutedEventArgs e)
        {
            UpdateDetailOrder update = new UpdateDetailOrder();
            update.Show();
        }

        private void deleteDetailOrder_Click(object sender, RoutedEventArgs e)
        {
            DeleteDetailOrder delete = new DeleteDetailOrder();
            delete.Show();
        }

        private void searchDetails_Click(object sender, RoutedEventArgs e)
        {
            SearchDetails details = new SearchDetails();
            details.Show();
        }
    }
}
