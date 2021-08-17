using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_ComputerRepair
{
    public class Order
    {
        public int Id { get; set; }
        
        public DateTime OrderDate { get; set; }
        
        public int TotalPrice { get; set; }
        public string Description { get; set; }

        public int IdDevice { get; set; }
        public int IdOrderStatus { get; set; }
        public int IdWorkman { get; set; }
        public int IdOrderType { get; set; }
        public int IdClient { get; set; }

        public Device Device { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public Employee Workman { get; set; }
        public OrderType OrderType { get; set; }
        public Client Client { get; set; }
        
        
        
        
       

        public ICollection<UsedDetail> UsedDetails { get; set; }
        public Order()
        {
            UsedDetails = new List<UsedDetail>();
        }

    }
}
