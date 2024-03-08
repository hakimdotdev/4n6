using AutoRecon.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoRecon.Domain.Entities.Azure
{
    public class Blob : BaseAuditableEntity
    {
        public virtual ICollection<AzureVm> AzureVms { get; set; }  
    }
}
