using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskManage.Models
{
    public class TaskModel
    {
        public int CustomerID { get; set; }
        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
        public bool IsActive { get; set; }
    }
}
