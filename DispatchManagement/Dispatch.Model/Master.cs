using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dispatch.Model
{
    public class Master
    {
        public int MasterId { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public decimal Value { get; set; }
        public string Description { get; set; }
        public short MasterType { get; set; }
        public int UserId { get; set; }
        public short Status { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
      
    }
}
