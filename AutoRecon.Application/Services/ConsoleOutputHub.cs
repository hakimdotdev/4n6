using Microsoft.AspNetCore.SignalR;

namespace AutoRecon.Application.Services
{
    public class ConsoleOutputHub : Hub
    {
 public async Task SendLogEntry(string message, bool isSuccess)
        {
            await Clients.All.SendAsync("ReceiveLogEntry", message, isSuccess);
        }
    }
}