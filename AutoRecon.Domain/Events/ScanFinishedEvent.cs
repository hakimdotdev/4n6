using AutoRecon.Domain.Common;

namespace AutoRecon.Domain.Entities;

public class ScanFinishedEvent(Scan scan) : BaseEvent
{
    public Scan Scan { get; } = scan;
}
