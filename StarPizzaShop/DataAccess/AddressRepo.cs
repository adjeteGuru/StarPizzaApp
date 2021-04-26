using StarPizzaShop.Database;
using StarPizzaShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarPizzaShop.DataAccess
{
    public class AddressRepo : IAddressRepo
    {
        private readonly StarPizzaContext _context;
        public AddressRepo(StarPizzaContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(_context));
        }
        public IEnumerable<Address> GetAddresses()
        {
            return _context.Addresses.ToList();
        }

        public Address GetAddressById(int id)
        {
            return _context.Addresses.FirstOrDefault(x => x.Id == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void CreateAddress(Address address)
        {
            _context.Add(address);
        }

        public void UpdateAddress(Address address)
        {
            _context.Update(address);
        }

        public void DeleteAddress(Address address)
        {
            _context.Remove(address);
        }



    }
}
