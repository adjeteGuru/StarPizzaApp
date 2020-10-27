using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarPizza.DataAccess
{
    public class StarPizzaContext : DbContext
    {
        public StarPizzaContext(DbContextOptions<StarPizzaContext> options) :
            base(options)
        {

        }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<Customer> MyProperty { get; set; }
    }
}
