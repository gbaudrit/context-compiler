using System.Diagnostics;

using Microsoft.Extensions.Configuration;

namespace ContextCompiler.Cli.Handlers;


internal sealed class ServeHandler(IConfiguration configuration) : IServeHandler
{
    public async Task<int> HandleAsync(ServeRequest request)
    {
        IConfiguration settings = configuration.GetSection("Ctxc:Serve");

        if (settings != null)
        {
            string command = settings.GetValue<string>("Command") ?? throw new InvalidOperationException("Serve command not found");

            ProcessStartInfo startInfo = new()
            {
                FileName = command,
                UseShellExecute = true
            };

            try
            {
                _ = Process.Start(startInfo);
                return 0;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Failed to start serve command: {ex.Message}");
                return 1;
            }
        }
        return 0;
    }
}
