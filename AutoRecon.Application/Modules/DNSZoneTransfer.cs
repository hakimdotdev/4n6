using AutoRecon.Domain.Common;
using AutoRecon.Domain.Entities;
using AutoRecon.Domain.Entities.Recon;
using Mediator;

namespace AutoRecon.Application.Modules
{
    public class DNSZoneTransfer : Module, IRequestHandler<ScanRequest, string>, IModule
    {
        private readonly ICommandExecutor _executor;
        public override List<string> Tags { get; set; } = ["dns"];

        public DNSZoneTransfer(ICommandExecutor executor)
        {
            _executor = executor;
            Name = "DNS Zone Transfer";
        }

        public DNSZoneTransfer()
        { }

        public async ValueTask<string> Handle(ScanRequest request, CancellationToken cancellationToken)
        {
            if (request.Domains is null || request.Domains.Count == 0)
            {
                throw new ArgumentException($"Invalid or no domains provided for Module {nameof(DNSZoneTransfer)}");
            }

            if (request.Targets != null)
            {
                foreach (var t in request.Targets.Values)
                {
                    foreach (var d in request.Domains)
                    {
                        foreach (var port in request.Targets.Ports)
                        {
                            var result = await _executor.ExecBufferedAsync("dig AXFR", ["-p", $"{port} @{t} {d}"], cancellationToken);
                        }
                    }
                }
            }
            return String.Empty;
        }
    }
}