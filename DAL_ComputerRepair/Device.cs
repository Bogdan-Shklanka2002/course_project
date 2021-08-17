using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL_ComputerRepair
{
    [Table ("Devices")]
    public class Device
    {
        public int Id { get; set; }
        public string Mark { get; set; }
        public string Model { get; set; }
        public int IdDeviceType { get; set; }
        public DeviceType  DeviceType { get; set; }

        public ICollection<Order> Orders { get; set; }

        public Device()
        {
            Orders = new List<Order>();
        }
        public override string ToString()
        {
            return Mark + " " + Model; 
        }
    }
}