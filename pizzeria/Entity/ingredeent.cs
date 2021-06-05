using pizzeria.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pizzeria
{
    class ingredeent
    {
        public int _ingredeentId { get; set; }
        public string _name { get; set; }
        public ICollection<pizza> pizzas { get; set; } = new List<pizza>();
    }
}
