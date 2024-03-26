using AutoRecon.Application.Interfaces;
using AutoRecon.Application.Commands.AzureVm;
using Mediator;

namespace AutoRecon.Application.Services;

public class CommandFactory : ICommandFactory
{
    private readonly IMediator _mediator;
    private readonly Dictionary<string, Func<string, string, IRequest<Unit>>> _vmServiceCreators = new();

    public CommandFactory(IMediator mediator, Func<CreateAzureVmCommand> azureVmServiceCreator)
    {
        _mediator = mediator;
        _vmServiceCreators.Add("Azure", (vmName, vhdFilePath) => azureVmServiceCreator());
    }

    public Func<Task<Unit>> GetVmCreationCommandExecutor(string provider, string vmName, string vhdFilePath)
    {
        if (_vmServiceCreators.TryGetValue(provider, out var creator))
            return async () => await _mediator.Send(creator(vmName, vhdFilePath));

        throw new NotSupportedException($"Provider '{provider}' is not supported.");
    }
}