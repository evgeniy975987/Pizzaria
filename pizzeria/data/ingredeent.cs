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
        public int ingredeentId { get; set; }
        public string name { get; set; }
        public ICollection<pizza> pizzas { get; set; } = new List<pizza>();
    }
}
