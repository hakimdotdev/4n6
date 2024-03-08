using AutoRecon.Domain.Entities;
using System.Collections.Generic;

namespace AutoRecon.Domain.Common
{
    public class ScanRequest(Target targets, List<IScanModule> modules)
    {
        public Target Targets { get; set; } = targets;
        public List<IScanModule> Modules { get; set; } = modules;
    }
}
