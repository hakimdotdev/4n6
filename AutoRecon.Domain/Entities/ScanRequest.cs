using AutoRecon.Domain.Entities;
using Mediator;
using System.Collections.Generic;

namespace AutoRecon.Domain.Common
{
    public class ScanRequest(Target targets, List<IModule> modules) : BaseAuditableEntity, IRequest<string>
    {
        protected ScanRequest(Target targets, List<IModule> modules, List<string>? domains, List<ushort>? ports, PortProfile? portProfile) : this(targets, modules)
        {
            if (ports is null || ports.Count == 0 && (portProfile == null || portProfile.Ports.Count == 0))
            {
                throw new ArgumentException("No ports specified.");
            };

            Domains = domains;
            Ports = ports;
            PortProfile = portProfile;
        }

        public Target Targets { get; set; } = targets;
        public List<IModule> Modules { get; set; } = modules;

        public List<string> ?Domains { get; set; }

        public List<ushort> ?Ports { get; set; }
        public PortProfile ?PortProfile {  get; set; }

    }
}
