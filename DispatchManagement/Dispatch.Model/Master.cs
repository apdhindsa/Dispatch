using System;

namespace Dispatch.Model
{
    public class Master
    {
        // Primary key
        public int MasterId { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public decimal Value { get; set; }
        public string Description { get; set; }
        // Foreign key
        public int MasterType { get; set; }
        // Foreign key
        public int UserId { get; set; }
        public short Status { get; set; }
        public DateTime dtCreated { get; set; }
        public DateTime dtModified { get; set; }

        // Navigation properties 
        public virtual MasterTypes MasterTypes { get; set; }
        public  CustomerAdv CustomerAdv { get; set; }
    }
}
