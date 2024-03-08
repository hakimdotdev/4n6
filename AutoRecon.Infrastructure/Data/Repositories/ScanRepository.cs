using AutoRecon.Domain.Entities;

namespace AutoRecon.Domain.Repositories
{
    public class ScanRepository
    {
        private readonly AutoReconDbContext _dbContext;

        public ScanRepository()
        {
            _dbContext = new AutoReconDbContext();
        }

        public void SaveScan(Scan scan)
        {
            _dbContext.Scans.Add(scan);
            _dbContext.SaveChanges();
        }
    }
}
