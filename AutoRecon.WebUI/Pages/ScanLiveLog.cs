using AutoRecon.Application.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.SignalR;

namespace AutoRecon.WebUI.Pages;

public class ScanLiveLog(IHubContext<ConsoleOutputHub> logHubContext) : PageModel
{
    private readonly IHubContext<ConsoleOutputHub> _logHubContext =
        logHubContext ?? throw new ArgumentNullException(nameof(logHubContext));

    public List<LogEntry> LogEntries { get; private set; } = [];

    public async Task OnGetAsync()
    {
    }

    public async Task<IActionResult> OnPostAsync(string vmName, string command)
    {
        try
        {
            var commandResult = await ExecuteCommandAsync(vmName, command);

            //TODO: success based on module command result validation
            var isSuccess = true;
            var logEntry = new LogEntry { Message = commandResult, IsSuccess = isSuccess };

            LogEntries.Add(logEntry);

            await _logHubContext.Clients.All.SendAsync("ReceiveLogEntry", logEntry.Message, logEntry.IsSuccess);
        }
        catch (Exception ex)
        {
        }

        return Page();
    }

    private async Task<string> ExecuteCommandAsync(string vmName, string command)
    {
        ExExtensions.ThrowIfAnyNullOrWhiteSpace([vmName, command]);
        return "ddd";
    }
}

public class LogEntry
{
    public required string Message { get; set; }
    public bool IsSuccess { get; set; }
}

public static class ExExtensions
{
    public static void ThrowIfAnyNullOrWhiteSpace(string[] arguments)
    {
        foreach (var arg in arguments)
            if (string.IsNullOrWhiteSpace(arg))
                throw new ArgumentException(nameof(arg));
    }
}