namespace Dispatch.Model
{
    public class CustomerAdv
    {
        // Primary key
        public int CustomerAdvId { get; set; }
        // Foreign key
        public int CustomerId { get; set; }
        // Foreign key 
        public int CurrencyTypeId { get; set; }
        // Foreign key
        public int MasterId { get; set; }
        public decimal? CreditLimit{ get; set; }
        public string CustomerNotes { get; set; }
        public bool IsShipper { get; set; }
        public bool IsConsignee { get; set; }

        // Navigation properties 
        public virtual Currency Currency { get; set; }
        public virtual Master Master { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
