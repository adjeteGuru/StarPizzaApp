using Microsoft.EntityFrameworkCore;
using StarPizzaShop.Database;
using StarPizzaShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarPizzaShop.DataAccess
{
    public class CustomerRepo : ICustomerRepo
    {
        private readonly StarPizzaContext _context;
        public CustomerRepo(StarPizzaContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(_context));
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public IEnumerable<Customer> GetCustomers()
        {
            return _context.Customers
                .Include(x =>x.Addresses)
                .ToList();
        }

        public Customer GetCustomerById(int id)
        {
            return _context.Customers.FirstOrDefault(x => x.Id == id);
        }

        public void CreateCustomer(Customer customer)
        {
            _context.Add(customer);
        }

        public void UpdateCustomer(Customer customer)
        {
            _context.Update(customer);
        }

        public void DeleteCustomer(Customer customer)
        {
            _context.Remove(customer);
        }
    }
}
