using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace UserManagementSystem.Common
{
    public class OrderItem
    {
        public string Key { get; set; }

        public Direction Direction { get; set; }
    }

    public enum Direction
    {       
        Asc = 0,
        Desc = 1
    }
}
