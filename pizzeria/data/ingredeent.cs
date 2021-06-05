using pizzeria.data;
using System.Collections.Generic;

namespace pizzeria
{
    class ingredeent
    {
        public int _ingredeentId { get; set; }
        public string _name { get; set; }
        public ICollection<pizza> _pizzas { get; set; } = new List<pizza>();
    }
}
