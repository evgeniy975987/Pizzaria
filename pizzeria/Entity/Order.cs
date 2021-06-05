using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pizzeria.data
{
    class Order
    {
        
        public int _orderID { get; set; }

       
        public int _price { get; set; }

        public int _orderNumber { get; set; }
        public ICollection<pizza> _products { get; set; } = new List<pizza>();

        public ICollection<OrderHistory> orderHistories { get; set; } = new List<OrderHistory>();

        public Person _person { get; set; }
        public DateTime _timeOrder { get; set; }

        public DateTime _timeWait;
        
        public bool _isDone { get; set; }



        

    }
}
