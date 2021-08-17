using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_ComputerRepair
{
    [Table("Employees")]
    public class Employee
    {
        public int Id { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string FatherName { get; set; }
        public int IdPosition { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public Position Position { get; set; }

        
        public ICollection<Order> Orders { get; set; }

        public Employee()
        {
            Orders = new List<Order>();
        }
        public override string ToString()
        {
            return Surname + " " + Name + " " + FatherName;
        }
    }
}
