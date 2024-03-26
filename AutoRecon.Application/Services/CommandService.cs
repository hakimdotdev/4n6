using AutoRecon.Application.Interfaces;
using CliWrap;
using CliWrap.Buffered;
using Microsoft.AspNetCore.SignalR;

namespace AutoRecon.Application.Services;

public class CommandService : ICommandExecutor
{
    private readonly IHubContext<ConsoleOutputHub> _hubContext;
    private readonly IUserContext _userContext;

    public CommandService(IHubContext<ConsoleOutputHub> hubContext, IUserContext userContext)
    {
        _hubContext = hubContext;
        _userContext = userContext;
    }


    public async Task ExecAsync(string command, string[] args, CancellationToken cancellationToken = default)
    {
        var (stdout, stderr) = await ExecBufferedAsync(command, args, cancellationToken);

        // Send stdout and stderr to the current user only
        await _hubContext.Clients.User(_userContext.UserId)
            .SendAsync("ReceiveConsoleOutput", stdout, stderr, cancellationToken);
    }

    public async Task<(string, string)> ExecBufferedAsync(string command, string[] args,
        CancellationToken cancellationToken = default)
    {
        var tupleList = new List<(string Flag, string Value)>();
        for (var i = 0; i < args.Length; i += 2)
            if (i + 1 < args.Length)
                tupleList.Add((args[i], args[i + 1]));

        var x = Cli.Wrap(command);

        foreach (var (Flag, Value) in tupleList) x = x.WithArguments(new[] { Flag, Value });

        var y = await x.ExecuteBufferedAsync(cancellationToken);

        return new ValueTuple<string, string>(y.StandardOutput, y.StandardError);
    }
}