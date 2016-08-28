using System;

namespace Dispatch.Model
{
    public interface IAuditInfo
    {
        DateTime dtCreated { get; set; }
        DateTime dtModified { get; set; }
    }
}
