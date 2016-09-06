using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Dispatch.Test.Controllers_Api
{
    public class CustomerController : ApiController
    {
        public IHttpActionResult Get()
        {
            IHttpActionResult ret = null;
            CustomerViewModel vm = new CustomerViewModel();
            vm.Get();
            if (vm.Customers.Count > 0)
            {
                ret = Ok(vm.Customers);
            }
            else
            {
                ret = NotFound();
            }

            return ret;
        }

        [System.Web.Http.HttpPost()]
        [System.Web.Http.Route("api/Customer/Search")]
        public IHttpActionResult Search(CustomerSearch searchEntity)
        {
            IHttpActionResult ret = null;
            CustomerViewModel vm = new CustomerViewModel();
            vm.SearchEntity = searchEntity;
            vm.Search();
            if (vm.Customers.Count > 0)
            {
                ret = Ok(vm.Customers);
            }
            else
            {
                ret = NotFound();
            }

            return ret;
        }

        // GET api/<controller>/1
        [System.Web.Http.HttpGet()]
        public IHttpActionResult Get(int id)
        {
            IHttpActionResult ret;
            Customer customer = new Customer();
            CustomerViewModel vm = new CustomerViewModel();
            customer = vm.Get(id);
            if (customer != null)
            {
                ret = Ok(customer);
            }
            else
            {
                ret = NotFound();
            }

            return ret;
        }

        private ModelStateDictionary ConvertToModelState(System.Web.Mvc.ModelStateDictionary state)
        {
            ModelStateDictionary ret = new ModelStateDictionary();

            foreach (var list in state.ToList())
            {
                for (int i = 0; i < list.Value.Errors.Count; i++)
                {
                    ret.AddModelError(list.Key, list.Value.Errors[i].ErrorMessage);
                }
            }

            return ret;
        }

        [System.Web.Http.HttpPost()]
        public IHttpActionResult Post(Customer customer)
        {
            IHttpActionResult ret = null;
            CustomerViewModel vm = new CustomerViewModel();

            vm.Entity = customer;
            vm.PageMode = PageConstants.ADD;
            vm.Save();

            if (vm.IsValid)
            {
                ret = Created<Customer>(
                        Request.RequestUri +
                        customer.CustomerId.ToString(),
                          customer);
            }
            else if (vm.Messages.Count > 0)
            {
                ret = BadRequest(ConvertToModelState(vm.Messages));
            }
            else
            {
                ret = NotFound();
            }

            return ret;
        }

        [HttpPut()]
        public IHttpActionResult Put(int id, Customer customer)
        {
            IHttpActionResult ret = null;
            CustomerViewModel vm = new CustomerViewModel();
            vm.Entity = customer;
            vm.PageMode = PageConstants.EDIT;
            vm.Save();
            if (vm.IsValid)
            {
                ret = Ok(customer);
            }
            else if (vm.Messages.Count > 0)
            {
                ret = BadRequest(ConvertToModelState(vm.Messages));
            }
            else
            {
                ret = NotFound();
            }

            return ret;
        }

        [HttpDelete()]
        public IHttpActionResult Delete(int id)
        {
            IHttpActionResult ret = null;
            CustomerViewModel vm = new CustomerViewModel();
            vm.Entity = vm.Get(id);
            if (vm.Entity.CustomerId > 0)
            {
                vm.Delete(id);
                ret = Ok(true);
            }
            else
            {
                ret = NotFound();
            }

            return ret;
        }
    }

}