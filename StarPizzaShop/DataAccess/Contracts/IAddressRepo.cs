using StarPizzaShop.Models;
using System.Collections.Generic;

namespace StarPizzaShop.DataAccess
{
    public interface IAddressRepo
    {
        void CreateAddress(Address address);
        void DeleteAddress(Address address);
        Address GetAddressById(int id);
        IEnumerable<Address> GetAddresses();
        bool SaveChanges();
        void UpdateAddress(Address address);
    }
}