using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dispatch.Model
{
    public interface IAuditInfo
    {
        [Column(TypeName = "datetime2")]
        DateTime dtCreated { get; set; }
        [Column(TypeName = "datetime2")]
        DateTime dtModified { get; set; }
    }
}
