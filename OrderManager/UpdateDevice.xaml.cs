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
    /// Interaction logic for UpdateDevice.xaml
    /// </summary>
    public partial class UpdateDevice : Window
    {
        GenericUnitOfWork work;
        IGenericRepository<Device> repositoryDevice;
        IGenericRepository<DeviceType> repositoryDeviceType;
        Device device;
        public UpdateDevice()
        {
            InitializeComponent();
            work = new GenericUnitOfWork(new MyContextDb(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString));
            repositoryDevice = work.Repository<Device>();
            repositoryDeviceType = work.Repository<DeviceType>();

            FillCombo();
        }

        private void FillCombo()
        {
            deviceTypeComboBox.ItemsSource = repositoryDeviceType.GetAll();
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
                    deviceMarkTextBox.Text = device.Mark;
                    deviceModelTextBox.Text = device.Model;
                    deviceTypeComboBox.SelectedItem = repositoryDeviceType.FindById(device.IdDeviceType);


                }
            }
        }

        private void updateDevice_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(deviceMarkTextBox.Text) &&
               !string.IsNullOrEmpty(deviceModelTextBox.Text) &&
               deviceTypeComboBox.SelectedItem != null)
            {
                DeviceType type = deviceTypeComboBox.SelectedItem as DeviceType;

                device.Mark = deviceMarkTextBox.Text;
                device.Model = deviceModelTextBox.Text;
                device.IdDeviceType = type.Id;
                device.DeviceType = type;
                
                try
                {
                    repositoryDevice.Update(device);
                    MessageBox.Show("Device successfully updated!", "Operation completed");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Not update!");
                }
            }
            else
            {
                MessageBox.Show("Check is there empty such field as : Mark, Model, Device type. It's required field!", "Empty fields!");
            }
        }
    }
}
