using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering_system
{
    internal class OrderingHistory
    {
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerNumber { get; set; }
        public string OrderDate { get; set; }


        public OrderingHistory(string customerName, string customerAddress, string customerNumber, string orderDate)
        {
            CustomerName = customerName;
            CustomerAddress = customerAddress;
            CustomerNumber = customerNumber;
            OrderDate = orderDate;
        }
    }
}
