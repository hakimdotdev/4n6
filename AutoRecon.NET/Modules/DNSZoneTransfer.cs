using CliWrap;
using System;
using System.Net;
using System.Threading.Tasks;

namespace AutoRecon.NET.Modules
{
    public class DNSZoneTransfer : ServiceScan
    {
        private readonly ICommandExecutor _executor;
        public DNSZoneTransfer(ICommandExecutor executor)
        {
            _executor = executor;
            Name = "DNS Zone Transfer";
            Tags.Add("dns");
        }

        public async Task Run()
        {
            var domain = GetGlobal("domain");
            if (domain != null)
            {
                foreach (var target in Targets.Values)
                {
                    foreach (var port in Ports)
                    {
                        await _executor.ExecuteCommandAsync("dig AXFR", ["-p", $"{port} @{target} {domain}"]);
                    }
                }
            }

            foreach (var target in Targets.Values)
            {
                foreach (var port in Ports)
                {
                    await _executor.ExecuteCommandAsync("dig AXFR", ["-p", $"{port} @{target} {target}"]);
                }
            }
        }

        private object GetGlobal(string v)
        {
            throw new NotImplementedException();
        }
    }
}
