using StarPizzaShop.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarPizzaShop.DataAccess
{
    public class OrdersRepo
    {
        private readonly StarPizzaContext _context;
        public OrdersRepo(StarPizzaContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(_context));
        }
    }
}
