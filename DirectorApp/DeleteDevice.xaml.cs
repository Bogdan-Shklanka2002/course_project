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
    /// Interaction logic for DeleteDevice.xaml
    /// </summary>
    public partial class DeleteDevice : Window
    {
        GenericUnitOfWork work;
        IGenericRepository<Device> repositoryDevice;
        IGenericRepository<DeviceType> repositoryDeviceType;
        Device device;
        public DeleteDevice()
        {
            InitializeComponent();
            work = new GenericUnitOfWork(new MyContextDb(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString));
            repositoryDevice = work.Repository<Device>();
            repositoryDeviceType = work.Repository<DeviceType>();
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
                device = repositoryDevice.FindById(id);
                if (device != null)
                {
                    deviceMarkTextBlock.Text = device.Mark;
                    deviceModelTextBlock.Text = device.Model;
                    deviceTypeTextBlock.Text = repositoryDeviceType.FindById(device.IdDeviceType).ToString();


                }
            }
        }

        private void deleteDevice_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Do you want to delete this device?", "Delete device", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    repositoryDevice.Remove(device);
                    MessageBox.Show("Device successfully deleted!", "Operation completed");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Not delete!");
                }
            }
        }
    }
}
