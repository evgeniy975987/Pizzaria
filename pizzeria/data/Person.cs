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
        public string name { get; set; }
        public string middleName { get; set; }
        public string lastName { get; set; }
        public string addres { get; set; }
        public ICollection<Order> order { get; set; } = new List<Order>();



        public void NewPerson()
        {
            Console.WriteLine("ВВедите имя: ");
            name = Console.ReadLine();

            Console.WriteLine("ВВедите фамимилию: ");
            middleName = Console.ReadLine();

            Console.WriteLine("ВВедите отчество: ");
            lastName = Console.ReadLine();

            Console.WriteLine("ВВедите аадрес");
            addres = Console.ReadLine();


        }
    }

    
}
