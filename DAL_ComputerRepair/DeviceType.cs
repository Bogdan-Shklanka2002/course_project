using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_ComputerRepair
{
    public class DeviceType
    {
        public int Id { get; set; }
        public string TypeName { get; set; }

        public ICollection<Device> Devices { get; set; }

        public DeviceType()
        {
            Devices = new List<Device>();
        }
        public override string ToString()
        {
            return TypeName;
        }
    }
}
