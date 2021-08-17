using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_ComputerRepair
{
    public class OrderType
    {
        public int Id { get; set; }
        public string TypeName { get; set; }

        public ICollection<Order> Orders { get; set; }

        public OrderType()
        {
            Orders = new List<Order>();
        }
        public override string ToString()
        {
            return TypeName;
        }
    }
}
