using AutoRecon.Domain.Common;

namespace AutoRecon.Domain.Entities.Recon
{
    public class Scan : BaseAuditableEntity
    {
        public string Name { get; set; } = Guid.NewGuid().ToString();
        public List<Module> Modules { get; set; } = [];

        public long Duration { get; set; }
        public int Priority { get; set; }
        public List<Target> Targets { get; set; } = [];
        public List<ushort> Ports { get; set; } = [];
        public List<string>? Domains { get; set; }
    }
}