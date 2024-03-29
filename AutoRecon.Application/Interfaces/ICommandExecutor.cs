﻿namespace AutoRecon.Application.Interfaces;

public interface ICommandExecutor
{
    public Task ExecAsync(string command, string[] args, CancellationToken cancellationToken = default);

    public Task<(string, string)> ExecBufferedAsync(string command, string[] args,
        CancellationToken cancellationToken = default);
}