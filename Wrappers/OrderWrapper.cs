using DAL_ComputerRepair;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wrappers
{
    public class OrderWrapper:Wrapper
    {
        public Order Order { get; set; }
        public string WhatToDo { get; set; }
    }
}
