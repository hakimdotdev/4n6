using AutoRecon.Application.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.SignalR;
namespace AutoRecon.WebUI.Pages;
public class ScanLiveLog : PageModel
{
    private readonly IHubContext<ConsoleOutputHub> _logHubContext;

    public List<LogEntry> LogEntries { get; private set; }

    public ScanLiveLog(IHubContext<ConsoleOutputHub> logHubContext)
    {
        _logHubContext = logHubContext ?? throw new ArgumentNullException(nameof(logHubContext));
        LogEntries = new List<LogEntry>();
    }

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
        return "ddd";
    }
}

public class LogEntry
{
    public string Message { get; set; }
    public bool IsSuccess { get; set; }
}