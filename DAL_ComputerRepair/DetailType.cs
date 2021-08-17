using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_ComputerRepair
{
    public class DetailType
    {
        public int Id { get; set; }
        public string TypeName { get; set; }

        public ICollection<Detail> Details { get; set; }

        public DetailType()
        {
            Details = new List<Detail>();
        }
        public override string ToString()
        {
            return TypeName;
        }

    }
}
