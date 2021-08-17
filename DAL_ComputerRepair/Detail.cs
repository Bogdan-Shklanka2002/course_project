using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_ComputerRepair
{
    [Table("Details")]
    public class Detail
    {
        public int Id { get; set; }
        public string DetailName { get; set; }
        public int IdDetailType { get; set; }
        public int Price { get; set; }
        public int AvaibleQuantity { get; set; }

        public DetailType DetailType { get; set; }

        public ICollection<UsedDetail> UsedDetails { get; set; }
        public Detail()
        {
            UsedDetails = new List<UsedDetail>();
        }
        public override string ToString()
        {
            return DetailType.TypeName + ": " + DetailName;
        }
    }
}
