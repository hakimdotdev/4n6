using AutoRecon.Domain.Common;
using Mediator;

namespace AutoRecon.Domain.Entities.Recon
{
    public class ScanRequest(Target targets, List<Module> modules) : BaseAuditableEntity, IRequest<string>
    {
        protected ScanRequest(Target targets, List<Module> modules, List<string>? domains, List<ushort>? ports, PortProfile? portProfile) : this(targets, modules)
        {
            if (ports is null || ports.Count == 0 && (portProfile == null || portProfile.Ports.Count == 0))
            {
                throw new ArgumentException("No ports specified.");
            }

            Domains = domains;
            Ports = ports;
            PortProfile = portProfile;
        }

        public Target Targets { get; set; } = targets;
        public List<Module> Modules { get; set; } = modules;

        public List<string>? Domains { get; set; }

        public List<ushort>? Ports { get; set; }
        public PortProfile? PortProfile { get; set; }
    }
}