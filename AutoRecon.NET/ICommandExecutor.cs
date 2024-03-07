using CliWrap;
using CliWrap.Buffered;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace AutoRecon.NET
{
    public interface ICommandExecutor
    {
        Task<CommandResult> ExecuteCommandAsync(string command, string[] args, CancellationToken cancellationToken = default);
    }
}
