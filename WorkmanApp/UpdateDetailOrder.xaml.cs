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
    /// Interaction logic for UpdateDetailOrder.xaml
    /// </summary>
    public partial class UpdateDetailOrder : Window
    {
        GenericUnitOfWork work;
        IGenericRepository<Detail> repositoryDetail;
        IGenericRepository<Order> repositoryOrder;
        IGenericRepository<UsedDetail> repositoryUsedDetail;
        UsedDetail usedDetail;
        public UpdateDetailOrder()
        {
            InitializeComponent();
            work = new GenericUnitOfWork(new MyContextDb(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString));
            repositoryDetail = work.Repository<Detail>();
            repositoryOrder = work.Repository<Order>();
            repositoryUsedDetail = work.Repository<UsedDetail>();

            FillCombo();
        }

        private void FillCombo()
        {
            detailComboBox.ItemsSource = repositoryDetail.GetAll();
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
                    orderIdTextBox.Text = usedDetail.IdOrder.ToString();
                    
                    detailComboBox.SelectedItem = repositoryDetail.FindById(usedDetail.IdDetail);
                }
            }
        }

        private void addDetailOrder_Click(object sender, RoutedEventArgs e)
        {

            int idOrder = Convert.ToInt32(orderIdTextBox.Text);

            Detail type = detailComboBox.SelectedItem as Detail;
            Order order = repositoryOrder.FindById(idOrder);
            if (!String.IsNullOrEmpty(orderIdTextBox.Text) &&
                type != null)
            {
                usedDetail.IdDetail = type.Id;
                usedDetail.Detail = type;
                usedDetail.IdOrder = order.Id;
                usedDetail.Order = order;
                repositoryUsedDetail.Update(usedDetail);

                MessageBox.Show("Successfully added!", "Operation completed");
            }
            else
            {
                MessageBox.Show("Check is there empty such field as : Order id, Detail. It's required field", "Empty fields");
            }
        }
    }
}
