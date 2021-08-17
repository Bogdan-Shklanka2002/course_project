using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_ComputerRepair
{
    [Table("Positions")]
    public class Position
    {
        public int Id { get; set; }
        public string PositionName { get; set; }

        public ICollection<Employee> Employees { get; set; }
        public Position()
        {
            Employees = new List<Employee>();
        }
        public override string ToString()
        {
            return PositionName;
        }
    }
}
