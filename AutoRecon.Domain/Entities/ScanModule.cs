using AutoRecon.Domain.Common;

namespace AutoRecon.Domain.Entities
{
    public interface IScanModule
    {
        public async Task Run(Target target) { }
    }
}