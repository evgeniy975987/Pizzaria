using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pizzeria.data
{
    class pizza
    {

        public int _pizzaID { get; set; }
        public int _price { get; set; }
        public string _name { get; set; }
        public string _img { get; set; }
        public ICollection<ingredeent> _ingredeents { get; set; } = new List<ingredeent>();

        
    }

    
}
