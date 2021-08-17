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
    /// Interaction logic for DeleteDetail.xaml
    /// </summary>
    public partial class DeleteDetail : Window
    {
        GenericUnitOfWork work;
        IGenericRepository<Detail> repositoryDetail;
        IGenericRepository<DetailType> repositoryDetailType;
        Detail detail;
        public DeleteDetail()
        {
            InitializeComponent();

            work = new GenericUnitOfWork(new MyContextDb(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString));
            repositoryDetail = work.Repository<Detail>();
            repositoryDetailType = work.Repository<DetailType>();

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
                detail = repositoryDetail.FindById(id);
                if (detail != null)
                {
                    detailNameTextBlock.Text = detail.DetailName;
                    detailPriceTextBlock.Text = detail.Price.ToString();
                    detailTypeTextBlock.Text = repositoryDetailType.FindById(detail.IdDetailType).ToString();
                    detailAvaibleCountTextBlock.Text = detail.AvaibleQuantity.ToString();

                }
            }
        }

        private void deleteDetail_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Do you want to delete this device?", "Delete device", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    repositoryDetail.Remove(detail);
                    MessageBox.Show("Detail successfully deleted!", "Operation completed");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Not delete!");
                }
            }
        }
    }
}
