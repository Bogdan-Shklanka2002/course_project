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
    /// Interaction logic for AddDetail.xaml
    /// </summary>
    public partial class AddDetail : Window
    {
        GenericUnitOfWork work;
        IGenericRepository<Detail> repositoryDetail;
        IGenericRepository<DetailType> repositoryDetailType;
        public AddDetail()
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

        private void addDetail_Click(object sender, RoutedEventArgs e)
        {
            string name = detailNameTextBox.Text;
            int price = Convert.ToInt32(detailPriceTextBox.Text);
            int count = Convert.ToInt32(detailAvaibleCountTextBox.Text);

            DetailType type = detailTypeComboBox.SelectedItem as DetailType;

            if (!String.IsNullOrEmpty(name) &&
                !String.IsNullOrEmpty(detailPriceTextBox.Text) &&
                !String.IsNullOrEmpty(detailAvaibleCountTextBox.Text) &&
                type != null)
            {
                int id = repositoryDetail.GetAll().Last().Id + 1;
                repositoryDetail.Add(new Detail
                {
                    Id = id,
                    DetailName = name,
                    Price = price,
                    IdDetailType = type.Id,
                    DetailType = type,
                    AvaibleQuantity = count  
                });

                MessageBox.Show("Successfully added!", "Operation completed");
            }
            else
            {
                MessageBox.Show("Check is there empty such field as : Detail Name, Price, Avaible count, Detail type. It's required field", "Empty fields");
            }
        }
    }
}
