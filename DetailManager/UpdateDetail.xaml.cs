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
using System.Windows.Shapes;

namespace DirectorApp
{
    /// <summary>
    /// Interaction logic for UpdateDetail.xaml
    /// </summary>
    public partial class UpdateDetail : Window
    {
        GenericUnitOfWork work;
        IGenericRepository<Detail> repositoryDetail;
        IGenericRepository<DetailType> repositoryDetailType;
        Detail detail;
        public UpdateDetail()
        {
            InitializeComponent();

            work = new GenericUnitOfWork(new MyContextDb(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString));
            repositoryDetail = work.Repository<Detail>();
            repositoryDetailType = work.Repository<DetailType>();

            FillCombo();
        }

        private void FillCombo()
        {
            detailTypeComboBox.ItemsSource = repositoryDetailType.GetAll();
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
                    detailNameTextBox.Text = detail.DetailName;
                    detailPriceTextBox.Text = detail.Price.ToString();
                    detailTypeComboBox.SelectedItem = repositoryDetailType.FindById(detail.IdDetailType);
                    detailAvaibleCountTextBox.Text = detail.AvaibleQuantity.ToString();

                }
            }
        }

        private void updateDetail_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(detailNameTextBox.Text) &&
              !string.IsNullOrEmpty(detailPriceTextBox.Text) &&
              !string.IsNullOrEmpty(detailAvaibleCountTextBox.Text) &&
              detailTypeComboBox.SelectedItem != null)
            {
                DetailType type = detailTypeComboBox.SelectedItem as DetailType;

                detail.DetailName = detailNameTextBox.Text;
                detail.Price = Convert.ToInt32(detailPriceTextBox.Text);
                detail.AvaibleQuantity = Convert.ToInt32(detailAvaibleCountTextBox.Text);
                detail.IdDetailType = type.Id;
                detail.DetailType = type;

                try
                {
                    repositoryDetail.Update(detail);
                    MessageBox.Show("Device successfully updated!", "Operation completed");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Not update!");
                }
            }
            else
                MessageBox.Show("Check is there empty such field as : Mark, Model, Device type. It's required field!", 
                    "Empty fields!");
        }
    }
}
