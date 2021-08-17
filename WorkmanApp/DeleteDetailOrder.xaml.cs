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

namespace WorkmanApp
{
    /// <summary>
    /// Interaction logic for DeleteDetailOrder.xaml
    /// </summary>
    public partial class DeleteDetailOrder : Window
    {
        GenericUnitOfWork work;
        IGenericRepository<Detail> repositoryDetail;
        IGenericRepository<Order> repositoryOrder;
        IGenericRepository<UsedDetail> repositoryUsedDetail;
        UsedDetail usedDetail;
        public DeleteDetailOrder()
        {
            InitializeComponent();
            work = new GenericUnitOfWork(new MyContextDb(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString));
            repositoryDetail = work.Repository<Detail>();
            repositoryOrder = work.Repository<Order>();
            repositoryUsedDetail = work.Repository<UsedDetail>();

           
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
                usedDetail = repositoryUsedDetail.FindById(id);
                if (usedDetail != null)
                {
                    orderIdTextBlock.Text = usedDetail.IdOrder.ToString();

                    detailTextBlock.Text = repositoryDetail.FindById(usedDetail.IdDetail).ToString();
                }
            }
        }


        private void deleteDetailOrder_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Do you want to delete this device?", "Delete device", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    repositoryUsedDetail.Remove(usedDetail);
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
