using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pizzeria.data
{
    class Person
    {
        public int _personID { get; set; }
        public string _name { get; set; }
        public string _middleName { get; set; }
        public string _lastName { get; set; }
        public string _addres { get; set; }
        public ICollection<Order> _order { get; set; } = new List<Order>();



        public void NewPerson()
        {
            Console.WriteLine("ВВедите имя: ");
            _name = Console.ReadLine();

            Console.WriteLine("ВВедите фамимилию: ");
            _middleName = Console.ReadLine();

            Console.WriteLine("ВВедите отчество: ");
            _lastName = Console.ReadLine();

            Console.WriteLine("ВВедите аадрес");
            _addres = Console.ReadLine();


        }
    }

    
}
