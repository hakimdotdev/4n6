using AutoRecon.Domain.Common;

namespace AutoRecon.Domain.Entities.Recon
{
    public class PortProfile : BaseAuditableEntity
    {
        public List<ushort> Ports { get; set; } = [];

        public PortProfile(List<string> ports)
        {
            foreach (var port in ports)
            {
                if (port is null || !ushort.TryParse(port, out var p))
                {
                    break;
                    throw new ArgumentException("Invalid port in collection. Null reference or unable to cast to unsigned integer.");
                }
                Ports.Add(p);
            }
        }
    }
}