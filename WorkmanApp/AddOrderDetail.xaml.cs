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
    /// Interaction logic for AddOrderDetail.xaml
    /// </summary>
    public partial class AddOrderDetail : Window
    {
        GenericUnitOfWork work;
        IGenericRepository<Detail> repositoryDetail;
        IGenericRepository<Order> repositoryOrder;
        IGenericRepository<UsedDetail> repositoryUsedDetail;
        public AddOrderDetail()
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

        private void addDetailOrder_Click(object sender, RoutedEventArgs e)
        {

            int idOrder = Convert.ToInt32(orderIdTextBox.Text);

            Detail type = detailComboBox.SelectedItem as Detail;
            Order order = repositoryOrder.FindById(idOrder);
            if (!String.IsNullOrEmpty(orderIdTextBox.Text) &&
                type != null)
            {
                int id = repositoryUsedDetail.GetAll().Last().Id + 1;
                repositoryUsedDetail.Add(new UsedDetail
                {
                    Id = id,
                    Order = order,
                    IdOrder = order.Id,
                    Detail = type,
                    IdDetail = type.Id
                });

                MessageBox.Show("Successfully added!", "Operation completed");
            }
            else
            {
                MessageBox.Show("Check is there empty such field as : Order id, Detail. It's required field", "Empty fields");
            }
        }
    }
}
