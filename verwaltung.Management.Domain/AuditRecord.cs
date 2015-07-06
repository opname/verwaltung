using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace opname.verwaltung.Management.Domain
{
    public class AuditRecord
    {
        // Audit Properties
     public Guid AuditID { get; set; }
     public string UserName { get; set; } 
     public string IPAddress { get; set; }
     public string AreaAccessed { get; set; }
     public DateTime Timestamp { get; set; }

     // Default Constructor
     public AuditRecord() { }
    }
}
