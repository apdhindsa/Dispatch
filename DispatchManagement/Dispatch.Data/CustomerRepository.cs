using Dispatch.Model;
using System.Data.Entity;

namespace Dispatch.Data
{
    public class CustomerRepository : GenericRepository<Customer>
    {
        public CustomerRepository(DbContext context) : base(context) { }


    }
}
