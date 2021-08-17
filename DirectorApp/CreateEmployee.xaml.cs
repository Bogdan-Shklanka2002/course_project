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
    /// Interaction logic for CreateEmployee.xaml
    /// </summary>
    public partial class CreateEmployee : Window
    {
        GenericUnitOfWork work;
        IGenericRepository<Employee> repositoryEmployee;
        IGenericRepository<Position> repositoryPosition;
        public CreateEmployee()
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

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            string name = employeeNameTextBox.Text;
            string surname = employeeSurnameTextBox.Text;
            string fatherName = employeeFatherNameTextBox.Text;
            string login = employeeLoginTextBox.Text;
            string pass = employeePasswordTextBox.Text;
            Position position = employeePositionComboBox.SelectedItem as Position;
            
            if (!String.IsNullOrEmpty(name) && 
                !String.IsNullOrEmpty(surname) && 
                !String.IsNullOrEmpty(fatherName) && 
                !String.IsNullOrEmpty(login) &&
                !String.IsNullOrEmpty(pass) &&
                position != null)
            {
                int id = repositoryEmployee.GetAll().Last().Id + 1;
                repositoryEmployee.Add(new Employee
                {
                    Id = id,
                    Name = name,
                    Surname = surname,
                    FatherName = fatherName,
                    IdPosition = position.Id,
                    Position = position,
                    Login = login,
                    Password = pass

                }); ;
                
                MessageBox.Show("Successfully added!", "Operation completed");
            }
            else
            {
                MessageBox.Show("Check is there empty such field as : Name, Surname, FatherName, Phone. It's required field", "Empty fields");
            }
        }
    }
}
