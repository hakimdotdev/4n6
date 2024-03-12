using AutoRecon.Domain.Common;
using CliWrap;
using CliWrap.Buffered;

namespace AutoRecon.Domain.Entities.Recon
{
    public class CommandService : ICommandExecutor
    {
        public async Task ExecAsync(string command, string[] args, CancellationToken cancellationToken = default)
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

            await x.ExecuteBufferedAsync(cancellationToken);
        }

        /// <summary>
        /// Executes a command buffered and returns a tuple with the stdout and stderr pipe data
        /// </summary>
        /// <param name="command"></param>
        /// <param name="args"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>StandardOutput, StandardError pipe data as string</returns>
        public async Task<(string, string)> ExecBufferedAsync(string command, string[] args, CancellationToken cancellationToken = default)
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

            var y = await x.ExecuteBufferedAsync(cancellationToken);

            return new(y.StandardOutput, y.StandardError);
        }
    }
}