using CliWrap;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AutoRecon.Domain.Entities
{
    public class ServiceScan : Scan
    {
        public List<IModule> Modules { get; set; } = [];
        public List<string> Targets { get; set; } = [];
        public List<ushort> Ports { get; set; } = [];
        public List<string>? Domains { get; set; }
        public bool RunOnce { get; set; }
        public bool RequireSSL { get; set; }
        public int MaxTargetInstances { get; set; }
        public int MaxGlobalInstances { get; set; }
    }
}
