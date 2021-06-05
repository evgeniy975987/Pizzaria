using Microsoft.EntityFrameworkCore;
using pizzeria.data;
using pizzeria.EntityContext;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace pizzeria
{
    class Program
    {
       
        public static handler handler = new handler();
        static void Main(string[] args)
        {

            
            Pizzeria();


        }

        public static void Pizzeria() {
            Console.WriteLine("выберете что нужно сделать ");
            Console.WriteLine("1.Сделать заказ");
            Console.WriteLine("2.Посмотреть ассортимент: ");
            Console.WriteLine("3.Отменить заказ: ");
            Console.WriteLine("4. посмотреть статус заказа  ");
            Console.WriteLine("5. Изменить статус заказа  ");
            Console.WriteLine("6. Посмотеть все заказы  ");

            switch (Convert.ToInt32(Console.ReadLine()))
            {

                case 1:
                    Console.Clear();
                    handler.NewOrder();
                    break;
                case 2:
                    Console.Clear();
                    handler.GetAllProducts();
                    break;
                case 3:
                    Console.Clear();
                    Console.WriteLine("Введите номер заказа");
                    int numberOrder = Convert.ToInt32(Console.ReadLine());
                    handler.DeleteOrder(numberOrder);
                    break;
                case 4:
                    Console.Clear();
                    Console.WriteLine("Введите номер заказа");
                    numberOrder = Convert.ToInt32(Console.ReadLine());
                    handler.GetInfoOrder(numberOrder);
                    break;

                case 5:
                    Console.Clear();
                    Console.WriteLine("Введите номер заказа");
                     numberOrder = Convert.ToInt32(Console.ReadLine());
                    handler.EditStatus(numberOrder);

                    break;
                case 6:
                    Console.Clear();
                    handler.GetAllOrder();
                    break;
            }
            Console.ReadLine();
            Console.Clear();
            Pizzeria();

        }

       

        

        
    }
}
