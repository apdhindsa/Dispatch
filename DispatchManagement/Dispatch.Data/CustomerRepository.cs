using Dispatch.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dispatch.Data
{
    public class CustomerRepository : GenericRepository<Customer>
    {
        public CustomerRepository(DbContext context) : base(context) { }


    }
}
