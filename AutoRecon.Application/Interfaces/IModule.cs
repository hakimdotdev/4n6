using AutoRecon.Domain.Entities.Recon;

namespace AutoRecon.Domain.Entities
{
    public interface IModule
    {
        public async Task Handle(Target target) { }
    }
}