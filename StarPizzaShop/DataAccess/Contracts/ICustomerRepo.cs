using StarPizzaShop.Models;
using System.Collections.Generic;

namespace StarPizzaShop.DataAccess
{
    public interface ICustomerRepo
    {
        void CreateCustomer(Customer customer);
        void DeleteCustomer(Customer customer);
        Customer GetCustomerById(int id);
        IEnumerable<Customer> GetCustomers();
        bool SaveChanges();
        void UpdateCustomer(Customer customer);
    }
}