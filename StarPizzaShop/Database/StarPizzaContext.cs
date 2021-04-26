using Microsoft.EntityFrameworkCore;
using StarPizzaShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarPizzaShop.Database
{
    public class StarPizzaContext : DbContext
    {
        public StarPizzaContext(DbContextOptions<StarPizzaContext> options) : base(options)
        {

        }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<OrderMenus> OrderMenus { get; set; }    
        
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Orders>()
        //        .Property(d => d.DeliveryCharge)
        //        .HasColumnType("decimal(3,2)")
        //        .HasDefaultValue(2);

        //    modelBuilder.Entity<Menu>()
        //        .Property(p => p.Price)
        //        .HasColumnType("decimal(3,2)");
        //}


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<OrderMenus>()
            //    .HasKey(t => new { t.OrderId, t.MenuId });

            //modelBuilder.Entity<OrderMenus>()
            //    .HasOne(pt => pt.Order)
            //    .WithMany(p => p.OrderMenus)
            //    .HasForeignKey(pt => pt.OrderId);

            //modelBuilder.Entity<OrderMenus>()
            //    .HasOne(pt => pt.Menu)
            //     .WithMany(t => t.OrderMenus)
            //    .HasForeignKey(pt => pt.MenuId);

            modelBuilder.Entity<Orders>()
               .Property(d => d.DeliveryCharge)
               .HasColumnType("decimal(3,2)")
               .HasDefaultValue(2);

            modelBuilder.Entity<Menu>()
                .Property(p => p.Price)
                .HasColumnType("decimal(3,2)");

        }
            

    }
}
