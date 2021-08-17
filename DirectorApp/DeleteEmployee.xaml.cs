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
    /// Interaction logic for DeleteEmployee.xaml
    /// </summary>
    public partial class DeleteEmployee : Window
    {
        GenericUnitOfWork work;
        IGenericRepository<Employee> repositoryEmployee;
        IGenericRepository<Position> repositoryPosition;
        Employee employee;
        public DeleteEmployee()
        {
            InitializeComponent();
            work = new GenericUnitOfWork(new MyContextDb(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString));
            repositoryEmployee = work.Repository<Employee>();
            repositoryPosition = work.Repository<Position>();
            
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
                employee = repositoryEmployee.FindById(id);
                if (employee != null)
                {
                    employeeNameTextBlock.Text = employee.Name;
                    employeeSurnameTextBlock.Text = employee.Surname;
                    employeeFatherNameTextBlock.Text = employee.FatherName;
                    employeePositionTextBlock.Text = repositoryPosition.FindById(employee.IdPosition).ToString();
                    
                }
            }
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Do you want to delete this Employee?", "Delete Employee", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {

                try
                {
                    repositoryEmployee.Remove(employee);
                    MessageBox.Show("Employee successfully deleted!", "Operation completed");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Not delete!");
                }

            }
        }
    }
}
