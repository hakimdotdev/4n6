using CliWrap;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AutoRecon.Domain.Common
{
    public class ServiceScan : Scan
    {
        public Dictionary<string, List<int>> Ports { get; set; } = [];
        public Dictionary<string, List<int>> IgnorePorts { get; set; } = [];
        public List<string> ServiceNames { get; set; } = [];
        public List<string> IgnoreServiceNames { get; set; } = [];
        public bool RunOnce { get; set; }
        public bool RequireSSL { get; set; }
        public int MaxTargetInstances { get; set; }
        public int MaxGlobalInstances { get; set; }
    }
}
