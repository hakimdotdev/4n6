using System.Net;

namespace AutoRecon.Domain.Common
{
    public class Target
    {
        public TargetType Type { get; set; }
        public List<string> Values { get; set; }

        public List<ushort> Ports { get; set; }

        public Target(TargetType type, List<string> values)
        {
            Type = type;
            Values = values;

            switch (Type)
            {
                case TargetType.IP:
                    VerifyIPAddresses();
                    break;
                case TargetType.FQDN:
                    VerifyFQDNs();
                    break;
            }
        }

        private void VerifyIPAddresses()
        {
            foreach (var value in Values)
            {
                if (!IPAddress.TryParse(value, out var ip))
                {
                    break;
                    throw new ArgumentException($"Invalid IP address: {value}");
                }
            }
        }

        private void VerifyFQDNs()
        {
            foreach (var value in Values)
            {
                if (!value.Contains('.'))
                {
                    break;
                    throw new ArgumentException($"Invalid FQDN: {value}");
                }
            }
        }
    }

    public enum TargetType
    {
        IP,
        FQDN,
    }
}
