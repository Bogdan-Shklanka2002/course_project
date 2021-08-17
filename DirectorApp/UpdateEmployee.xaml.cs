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
    /// Interaction logic for UpdateEmployee.xaml
    /// </summary>
    public partial class UpdateEmployee : Window
    {
        GenericUnitOfWork work;
        IGenericRepository<Employee> repositoryEmployee;
        IGenericRepository<Position> repositoryPosition;
        Employee employee;
        public UpdateEmployee()
        {
            InitializeComponent();
            work = new GenericUnitOfWork(new MyContextDb(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString));
            repositoryEmployee = work.Repository<Employee>();
            repositoryPosition = work.Repository<Position>();

            FillCombo();
        }

        private void FillCombo()
        {
            employeePositionComboBox.ItemsSource = repositoryPosition.GetAll();
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
                    employeeNameTextBox.Text = employee.Name;
                    employeeSurnameTextBox.Text = employee.Surname;
                    employeeFatherNameTextBox.Text = employee.FatherName;
                    employeePositionComboBox.SelectedItem = repositoryPosition.FindById(employee.IdPosition);
                    employeeLoginTextBox.Text = employee.Login;
                    employeePasswordTextBox.Text = employee.Password;
                }
            }
        }

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(employeeNameTextBox.Text) &&
              !string.IsNullOrEmpty(employeeSurnameTextBox.Text) &&
              !string.IsNullOrEmpty(employeeFatherNameTextBox.Text) &&
              !string.IsNullOrEmpty(employeeLoginTextBox.Text) && 
              !string.IsNullOrEmpty(employeePasswordTextBox.Text) && 
               employeePositionComboBox.SelectedItem != null)
            {
                Position position = employeePositionComboBox.SelectedItem as Position;
                
                employee.Name = employeeNameTextBox.Text;
                employee.Surname = employeeSurnameTextBox.Text;
                employee.FatherName = employeeFatherNameTextBox.Text;
                employee.Login = employeeLoginTextBox.Text;
                employee.Password = employeePasswordTextBox.Text;
                employee.IdPosition = position.Id;
                employee.Position = position;

                try
                {
                    repositoryEmployee.Update(employee);
                    MessageBox.Show("Employee successfully updated!", "Operation completed");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Not update!");
                }
            }
            else
            {
                MessageBox.Show("Check is there empty such field as : Name, Surname, FatherName, Login, Password, Position. It's required field!", "Empty fields!");
            }
        }
    }
}
