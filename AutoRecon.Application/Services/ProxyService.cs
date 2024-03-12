using Renci.SshNet;

namespace AutoRecon.Application.Services
{
    public class ProxyService(SshClient sshClient)
    {
        private readonly SshClient _sshClient = sshClient;

        public void RunCommand(string command)
        {
            using var cmd = _sshClient.CreateCommand(command);
            var asyncExecute = cmd.BeginExecute();
            cmd.OutputStream.CopyTo(Console.OpenStandardOutput());
            cmd.EndExecute(asyncExecute);
        }
    }
}