using Microsoft.Azure.Management.Compute.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoRecon.Application.Interfaces
{
    public interface IAzureVmService
    {
        Task Startsync(string vmName);
        Task StopAsync(string vmName);

        Task CreateAsync(VirtualMachine vmParams);
        Task DeleteAsync(VirtualMachine vmParams);

    }
}
