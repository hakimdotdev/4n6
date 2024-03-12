using AutoRecon.Domain.Entities.Recon;

namespace AutoRecon.Domain.Repositories
{
    public interface IScanRequestRepository
    {
        Task StoreScanRequest(ScanRequest scanRequest);
    }
}