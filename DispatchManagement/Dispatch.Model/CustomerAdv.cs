using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dispatch.Model
{
    public class CustomerAdv
    {
        public int CustomerAdvId { get; set; }
        public int CurrencyTypeId { get; set; }
        public int MasterId { get; set; }
        public decimal CreditLimit{ get; set; }
        public string CustomerNotes { get; set; }
        public bool IsShipper { get; set; }
        public bool IsConsignee { get; set; }
       
    }
}
