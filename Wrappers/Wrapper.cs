using DAL_ComputerRepair;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Wrappers
{
    public class Wrapper
    {
        public IPAddress Address { get; set; }
        public Type EntityType { get; set; }
    }
}
