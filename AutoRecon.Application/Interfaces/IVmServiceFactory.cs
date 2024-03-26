using Mediator;

namespace AutoRecon.Application.Interfaces;

public interface ICommandFactory
{
    public Func<Task<Unit>> GetVmCreationCommandExecutor(string provider, string vmName, string vhdFilePath);
}