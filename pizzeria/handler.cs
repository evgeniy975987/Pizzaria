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
    class handler
    {
        
        public  Context context = new Context();


        
        public void DeleteOrder(int numberOrder) {
            var findOrder = context.orders
                .Where(p => p.orderNumber == numberOrder)
                .Include(p => p._person)
                .Include(p => p._products)
                .Include(p => p.orderHistories)
                .First();
            context.orders.Remove(findOrder);
            context.SaveChanges();
        }
        public  void NewOrder()
        {
            Console.Clear();
            Order order = new Order();
            order._timeOrder = DateTime.Now;
            Person person = new Person();
            person.NewPerson();


            while (true)
            {
                Console.WriteLine("что заказать? для выхода введите exit");
                GetAllProducts();
                if (Console.ReadLine() == "exit") break;
                else
                {
                    try
                    {
                        int productID = Convert.ToInt32(Console.ReadLine());
                        pizza pizza = context.pizza.Find(productID);
                        order._products.Add(pizza);
                        Console.WriteLine("Сколько штук? ");
                        OrderHistory History = new OrderHistory();
                        History.order = order;
                        History.pizza = pizza;
                        try { History.countProduct = Convert.ToInt32(Console.ReadLine()); }
                        catch (Exception ex) { Console.WriteLine(ex.Message); }
                        order.orderHistories.Add(History);
                        

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                Console.Clear();
            }

            Console.Clear();
            order._isDone = false;
            order._timeWait = order._timeOrder.AddMinutes(30);
            Console.WriteLine("Состав заказа: ");
            if (context.orders.Count() > 0) order.orderNumber = context.orders.OrderBy(p => p.orderNumber).Last<Order>().orderNumber + 1;
            else order.orderNumber = 1;
            
            
            context.people.Include(p => p.order);
            person.order.Add(order);
            context.people.Add(person);
            context.orders.Add(order);
            context.SaveChanges();

            Console.WriteLine("Заказ сделан: ");
            GetInfoOrder(order.orderNumber);
        }
        public  void NewProducts()
        {

            //  заполнение БД
            Random random = new Random();


            for (int i = 0; i < 10; i++)
            {
                pizza pizza = new pizza();
                pizza._name = $"Здесь должно быть название пиццы {i}";
                pizza._price = random.Next(300, 400); // рандомная цена
                pizza._img = $"Здесь должна быть картинка пиццы {i}";


                for (int j = 0; j < 5; j++)
                {
                    ingredeent ingredeent = new ingredeent();
                    ingredeent.name = $"Сдесь должно быть название ингереента {j}";
                    pizza._ingredeents.Add(ingredeent);
                    context.ingredeents.Add(ingredeent);
                    context.SaveChanges();
                    Console.WriteLine("Добавлен ингедеент:" + ingredeent.name);
                }

                context.pizza.Add(pizza);
                context.SaveChanges();
                Console.WriteLine("Давленна пицца" + pizza._name);
            }

        }
        public void GetAllProducts()
        {
            foreach (var product in context.pizza.Include(p => p._ingredeents).ToList())
            {
                Console.WriteLine($"товар под номером  {product._pizzaID}, название  пиццы: {product._name}, цена: {product._price}. {product._img}");
                
                foreach (var n in product._ingredeents) Console.WriteLine(n.name);
                Console.WriteLine("///////////////////////////////////////");
            }
        }

        public void GetAllOrder() {
            foreach (var t in context.orders.ToList()) GetInfoOrder(t.orderNumber);
        }

        public void GetInfoOrder(int numberOrder) {
            try
            {
                
                var findOrder = context.orders
                    .Where(p => p.orderNumber == numberOrder)
                    .Include(p => p.orderHistories)
                    .Include(p => p._products)
                    .First();
                int fullPrice = 0;


                Console.WriteLine($"время заказа: {findOrder._timeOrder} ");

                foreach (var product in findOrder.orderHistories)
                {
                    Console.WriteLine($"Название: {product.pizza._name}");
                    Console.WriteLine($"Картинка: {product.pizza._img}");
                    Console.WriteLine("\nИнгрееденты: ");
                    var include = context.pizza.Where(p => p == product.pizza).Include(p => p._ingredeents).First();
                    foreach (var t in include._ingredeents) Console.WriteLine(t.name);
                    Console.WriteLine($"Количество : {product.countProduct}");
                    Console.WriteLine($"\nЦена за одну пиццу: {product.pizza._price} \n ___________________________");
                    foreach (var n in findOrder.orderHistories) fullPrice += n.pizza._price * n.countProduct;
                }
                Console.WriteLine($"Полная цена:  {fullPrice}, номер заказа {findOrder.orderNumber}");
                if (findOrder._isDone) Console.WriteLine("Заказ готов");
                else Console.WriteLine($"Заказ не готов, ");


            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }

        }

        public void EditStatus(int numberOrder) {
            context.orders.Where(p => p.orderNumber == numberOrder).FirstOrDefault()._isDone = true;
            
        }
    }

    
}
