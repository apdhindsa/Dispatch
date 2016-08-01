using Dispatch.Model;
using System;

namespace Dispatch.Data
{
    public class ApplicationUnit : IDisposable
    {
        private DispatchDataContext dataContext = new DispatchDataContext();

        private IRepository<Customer> customer = null;
      

        public IRepository<Customer> Customer
        {
            get
            {
                if (customer == null)
                {
                    customer = new CustomerRepository(dataContext);
                }
                return this.customer;
            }
        }

        public void SaveChanges()
        {
            dataContext.SaveChanges();
        }

        public void Dispose()
        {
            if (dataContext != null)
            {
                dataContext.Dispose();
            }
        }
    }
}
