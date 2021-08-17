using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_ComputerRepair
{
    public class UsedDetail
    {
        public int Id { get; set; }
        public int IdDetail { get; set; }
        public int IdOrder { get; set; }
        [ForeignKey("IdOrder")]
        public Order Order { get; set; }
        [ForeignKey("IdDetail")]
        public Detail Detail { get; set; }

    }
}
