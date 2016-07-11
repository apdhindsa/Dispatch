using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dispatch.Model
{
    public class Customer
    {
        
        public int Id { get; set; }
        public string Status { get; set; }
        public string Address { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public bool IsSameAsMailingAddress { get; set; }
        public string BillingAddress { get; set; }
        public string BillingAddress2 { get; set; }
        public string BillingAddress3 { get; set; }
        public string BillingCountry { get; set; }
        public string BillingState { get; set; }
        public string BillingCity { get; set; }
        public string BillingZipCode { get; set; }
        public string PrimaryContact { get; set; }
        public string Telephone { get; set; }
        public string Extension { get; set; }
        public string Fax { get; set; }
        public string TollFree { get; set; }
        public string SecondaryContact { get; set; }
        public string SecondaryMail { get; set; }
        public bool IsBroker { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}
