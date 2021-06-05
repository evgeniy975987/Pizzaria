using Microsoft.EntityFrameworkCore;
using pizzeria.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pizzeria.EntityContext
{
    class Context : DbContext
    {
        public DbSet<ingredeent> ingredeents { get; set; }
        public DbSet<pizza> pizza { get; set; }
        public DbSet<Order> orders { get; set; }
        public DbSet<OrderHistory> histories { get; set; }
        public DbSet<Person>  people { get; set; }
        public Context ()
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<pizza>().HasKey(p => p._pizzaID);
            modelBuilder.Entity<pizza>().HasMany(p => p._ingredeents).WithMany(p => p._pizzas);
            modelBuilder.Entity<ingredeent>().HasKey(p => p._ingredeentId);
            modelBuilder.Entity<ingredeent>().HasMany(p => p._pizzas).WithMany(p => p._ingredeents);
            modelBuilder.Entity<Order>().HasKey(p => p._orderID);
            modelBuilder.Entity<OrderHistory>().HasKey(p => p._orderHistoryID);
            modelBuilder.Entity<OrderHistory>().HasOne(p => p._order).WithMany(P => P._orderHistories);
            modelBuilder.Entity<Person>().HasKey(p => p._personID);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
                optionsBuilder.UseSqlServer(@"Data Source=WIN-JT2C2OT04D4\SQLEXPRESS;Initial Catalog=pizzaria2;User ID=admin;Password=serverSQLtest!!!123!");
        }
    }

    
}
