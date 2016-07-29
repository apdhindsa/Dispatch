using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dispatch.Model
{
    public class Currency
    {
        public int CurrencyTypeId { get; set; }
        public string CurrencyName { get; set; }
        public string CurrencyShortName { get; set; }
        public string CurrencySymbol { get; set; }
        public int UserId { get; set; }
        public short Status { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}
