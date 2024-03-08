using AutoRecon.Domain.Common;

namespace AutoRecon.Domain.Entities
{
    public interface IModule
    {
        public async Task Handle(Target target) { }
    }
}