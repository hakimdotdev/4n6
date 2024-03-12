namespace AutoRecon.Domain.Entities
{
    public interface IOutputFactory
    {
        public Task Create<IModule>();

        public Task Print(IModule module, string data);

        public Task PrintError(IModule module, string data);
    }
}