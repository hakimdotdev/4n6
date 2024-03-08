using System.Threading.Tasks;
using AutoRecon.Domain.Common;

namespace AutoRecon.Domain.Repositories
{
    public interface IScanRequestRepository
    {
        Task StoreScanRequest(ScanRequest scanRequest);
    }
}
