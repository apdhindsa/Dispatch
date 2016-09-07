using Dispatch.Data;
using Dispatch.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.ModelBinding;

namespace Dispatch.Test.ViewModel
{
    public class CustomerViewModel
    {

        private ApplicationUnit _unit = new ApplicationUnit();

        #region Properties

        public List<Customer> Customers { get; set; }
        public string PageMode { get; set; }
        public bool IsDetailAreaVisible { get; set; }
        public bool IsListAreaVisible { get; set; }
        public bool IsSearchAreaVisible { get; set; }
        public string EventCommand { get; set; }
        public CustomerSearch SearchEntity { get; set; }
        public Customer Entity { get; set; }
        public string EventArgument { get; set; }
        public ModelStateDictionary Messages { get; set; }
        public bool IsValid { get; set; }
        #endregion

        #region Database Methods

        public void Get()
        {
            Customers = _unit.Customer.GetAll().OrderBy(p => p.Name).ToList();

            SetUIState(PageConstants.LIST);
        }

        public Customer Get(int customerId)
        {
            Entity = _unit.Customer.GetById(customerId);
            return Entity;
        }


        #endregion

        #region Public Methods

        public void HandleRequest()
        {

            switch (EventCommand.ToLower())
            {
                case "":
                case "list":
                    Get();
                    break;

                case "search":
                    Search();
                    break;

                case "resetsearch":
                    ResetSearch();
                    break;

                case "cancel":
                    Get();
                    break;

                case "add":
                    AddMode();
                    break;

                case "edit":
                    EditMode(Convert.ToInt32(EventArgument));
                    break;

                case "save":
                    Save();
                    break;

                case "delete":
                    Delete(Convert.ToInt32(EventArgument));
                    break;

                default:
                    break;
            }
        }

        #endregion

        #region Private Methods

        public void AddMode()
        {
            Entity = new Customer();
            Entity.UserId = 1;
            SetUIState(PageConstants.ADD);
        }

        protected void SetUIState(string state)
        {
            PageMode = state;

            IsDetailAreaVisible = (PageMode == "Add" || PageMode == "Edit");
            IsListAreaVisible = (PageMode == "List");
            IsSearchAreaVisible = (PageMode == "List");
        }

        public void ResetSearch()
        {
            SearchEntity = new CustomerSearch();
            Get();
        }

        public void Search()
        {
            Customers = _unit.Customer.GetAll().Where(p =>
                   p.Name.Contains(SearchEntity.ProductName)).
              OrderBy(p => p.Name).ToList();
            SetUIState(PageConstants.LIST);
        }

        public void EditMode(int customerId)
        {
            Entity = Get(customerId);
            SetUIState(PageConstants.EDIT);
        }

        public void Save()
        {
            Messages.Clear();
            try
            {

                if (PageMode == PageConstants.EDIT)
                {
                    _unit.Customer.Update(Entity);
                }
                else if (PageMode == PageConstants.ADD)
                {
                    _unit.Customer.Add(Entity);
                }
                _unit.SaveChanges();
                Get();
            }
            catch (DbEntityValidationException ex)
            {
                IsValid = false;
                foreach (var errors in ex.EntityValidationErrors)
                {
                    foreach (var item in errors.ValidationErrors)
                    {
                        Messages.AddModelError(item.PropertyName, item.ErrorMessage);
                    }
                }
                SetUIState(PageMode);
            }
        }

        public void Delete(int customerId)
        {
            _unit.Customer.Delete(customerId);
            _unit.SaveChanges();
            Get();
        }
        #endregion
    }

}