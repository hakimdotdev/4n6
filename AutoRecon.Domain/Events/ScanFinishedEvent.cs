using AutoRecon.Domain.Common;
using AutoRecon.Domain.Entities.Recon;

namespace AutoRecon.Domain.Entities;

public class ScanFinishedEvent(Scan scan) : BaseEvent
{
    public Scan Scan { get; } = scan;
}