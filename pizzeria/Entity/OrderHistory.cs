using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pizzeria.data
{
    class OrderHistory
    {
        public int _orderHistoryID { get; set; }
        public pizza pizza { get; set; }
        public Order order { get; set; }
        public int _countProduct { get; set; }


    }
}
