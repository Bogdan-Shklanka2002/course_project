using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_ComputerRepair
{
    public class OrderStatus
    {
        public int Id { get; set; }
        public string StatusName { get; set; }

        public ICollection<Order> Orders { get; set; }

        public OrderStatus()
        {
            Orders = new List<Order>();
        }
        public override string ToString()
        {
            return StatusName;
        }
    }
}
