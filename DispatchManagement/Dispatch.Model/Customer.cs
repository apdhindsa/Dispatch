using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dispatch.Model
{
    public class Customer
    {
        // Primary key
        public int CustomerId { get; set; }

        public string Name { get; set; }
        public string Address { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public int Country { get; set; }
        public int State { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public bool IsSameAsMailingAddress { get; set; }
        public string BillingAddress { get; set; }
        public string BillingAddress2 { get; set; }
        public string BillingAddress3 { get; set; }
        public int? BillingCountry { get; set; }
        public int? BillingState { get; set; }
        public string BillingCity { get; set; }
        public string BillingZipCode { get; set; }
        public string PrimaryContact { get; set; }
        public string Telephone { get; set; }
        public string Extension { get; set; }
        public string Fax { get; set; }
        public string TollFree { get; set; }
        public string Email { get; set; }
        public string SecondaryContact { get; set; }
        public string SecondaryMail { get; set; }
        public bool IsBroker { get; set; }
        public short Status { get; set; }
        // Foreign key 
        public int UserId { get; set; }

       
        public DateTime dtCreated { get; set; }
    
        public DateTime dtModified { get; set; }
      

        // Navigation properties 
        public  CustomerAdv CustomerAdv { get; set; }
        
    }
}
