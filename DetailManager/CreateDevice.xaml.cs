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
    /// Interaction logic for CreateDevice.xaml
    /// </summary>
    public partial class CreateDevice : Window
    {
        GenericUnitOfWork work;
        IGenericRepository<Device> repositoryDevice;
        IGenericRepository<DeviceType> repositoryDeviceType;
        public CreateDevice()
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

        private void addDevice_Click(object sender, RoutedEventArgs e)
        {
            string mark = deviceMarkTextBox.Text;
            string model = deviceModelTextBox.Text;
            
            DeviceType type = deviceTypeComboBox.SelectedItem as DeviceType;

            if (!String.IsNullOrEmpty(mark) &&
                !String.IsNullOrEmpty(model) &&
                type != null)
            {
                int id = repositoryDevice.GetAll().Last().Id + 1;
                repositoryDevice.Add(new Device
                {
                    Id = id,
                    Mark = mark,
                    Model = model,
                    IdDeviceType = type.Id,
                    DeviceType = type

                }) ;

                MessageBox.Show("Successfully added!", "Operation completed");
            }
            else
            {
                MessageBox.Show("Check is there empty such field as : Mark, Model, Device type. It's required field", "Empty fields");
            }
        }
    }
}
