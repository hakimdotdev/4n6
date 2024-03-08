using CliWrap;
using CliWrap.Buffered;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace AutoRecon.Domain.Common
{
    public class CommandService : ICommandExecutor
    {
        public async Task<CommandResult> ExecuteCommandAsync(string command, string[] args, CancellationToken cancellationToken = default)
        {
            var tupleList = new List<(string Flag, string Value)>();
            for (int i = 0; i < args.Length; i += 2)
            {
                if (i + 1 < args.Length)
                {
                    tupleList.Add((args[i], args[i + 1]));
                }
            }

            var x = Cli.Wrap(command);

            foreach (var (Flag, Value) in tupleList)
            {
                x = x.WithArguments(new[] { Flag, Value });
            }

            return await x.ExecuteBufferedAsync(cancellationToken);
        }
    }
}
