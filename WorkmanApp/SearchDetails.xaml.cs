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
    /// Interaction logic for SearchDetails.xaml
    /// </summary>
    public partial class SearchDetails : Window
    {
        GenericUnitOfWork work;
        IGenericRepository<Detail> repositoryDetail;
        IGenericRepository<Order> repositoryOrder;
        IGenericRepository<UsedDetail> repositoryUsedDetail;
        UsedDetail usedDetail;
        public SearchDetails()
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
                var allDetails = repositoryDetail.GetAll();
                List<Detail> details = new List<Detail>();
                foreach (var item in repositoryUsedDetail.FindAll(x => x.IdOrder == id).Select(x => x.IdDetail).ToList())
                {
                    details.Add(allDetails.Where(x => x.Id == item).FirstOrDefault());
                }
                if (details.Count > 0)
                {
                    detailsGrid.ItemsSource = details;
                }
                else
                {
                    MessageBox.Show("Details not found!");
                }

                
            }


        }
    }
}
