using System;

namespace Dispatch.Model
{
    public class Currency
    {
        // Primary key
        public int CurrencyTypeId { get; set; }
        public string CurrencyName { get; set; }
        public string CurrencyShortName { get; set; }
        public string CurrencySymbol { get; set; }
        // Foreign key
        public int UserId { get; set; }
        public short Status { get; set; }
        public DateTime dtCreated { get; set; }
        public DateTime dtModified { get; set; }

        // Navigation properties 
        public  CustomerAdv CustomerAdv { get; set; }
        
    }
}
