using System.Diagnostics;
using System.Text;

namespace ContextCompiler.Connectors.Modules.Git;

public interface IGitProcessClient
{
    Task<GitMaterializationResult> MaterializeAsync(GitMaterializationRequest request, CancellationToken cancellationToken);
}

public sealed record GitMaterializationRequest(
    string RepositoryUrl,
    string TargetPath,
    string? Branch,
    bool Refresh,
    int? Depth);

public sealed record GitMaterializationResult(
    string TargetPath,
    bool Cloned,
    bool Updated);

internal sealed class GitProcessClient : IGitProcessClient
{
    public async Task<GitMaterializationResult> MaterializeAsync(GitMaterializationRequest request, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        ArgumentException.ThrowIfNullOrWhiteSpace(request.RepositoryUrl);
        ArgumentException.ThrowIfNullOrWhiteSpace(request.TargetPath);

        string targetPath = Path.GetFullPath(request.TargetPath);
        string? parentDirectory = Path.GetDirectoryName(targetPath);
        if (!string.IsNullOrWhiteSpace(parentDirectory))
        {
            _ = Directory.CreateDirectory(parentDirectory);
        }

        bool gitDirectoryExists = Directory.Exists(Path.Combine(targetPath, ".git"));
        if (!gitDirectoryExists)
        {
            await CloneAsync(request, cancellationToken);
            return new GitMaterializationResult(targetPath, Cloned: true, Updated: false);
        }

        if (!request.Refresh)
        {
            return new GitMaterializationResult(targetPath, Cloned: false, Updated: false);
        }

        await UpdateAsync(request, cancellationToken);
        return new GitMaterializationResult(targetPath, Cloned: false, Updated: true);
    }

    private static async Task CloneAsync(GitMaterializationRequest request, CancellationToken cancellationToken)
    {
        List<string> args = ["clone"];

        if (request.Depth is > 0)
        {
            args.Add("--depth");
            args.Add(request.Depth.Value.ToString(System.Globalization.CultureInfo.InvariantCulture));
        }

        if (!string.IsNullOrWhiteSpace(request.Branch))
        {
            args.Add("--branch");
            args.Add(request.Branch);
            args.Add("--single-branch");
        }

        args.Add(request.RepositoryUrl);
        args.Add(request.TargetPath);

        await RunGitAsync(args, workingDirectory: null, cancellationToken);
    }

    private static async Task UpdateAsync(GitMaterializationRequest request, CancellationToken cancellationToken)
    {
        if (!string.IsNullOrWhiteSpace(request.Branch))
        {
            await RunGitAsync(["checkout", request.Branch], request.TargetPath, cancellationToken);
            await RunGitAsync(["pull", "--ff-only", "origin", request.Branch], request.TargetPath, cancellationToken);
            return;
        }

        await RunGitAsync(["pull", "--ff-only"], request.TargetPath, cancellationToken);
    }

    private static async Task RunGitAsync(List<string> arguments, string? workingDirectory, CancellationToken cancellationToken)
    {
        ProcessStartInfo startInfo = new()
        {
            FileName = "git",
            RedirectStandardError = true,
            RedirectStandardOutput = true,
            UseShellExecute = false,
            CreateNoWindow = true,
            WorkingDirectory = string.IsNullOrWhiteSpace(workingDirectory)
                ? Environment.CurrentDirectory
                : workingDirectory
        };

        foreach (string argument in arguments)
        {
            startInfo.ArgumentList.Add(argument);
        }

        using Process process = new()
        {
            StartInfo = startInfo
        };

        if (!process.Start())
        {
            throw new InvalidOperationException("Unable to start git process.");
        }

        Task<string> standardOutputTask = process.StandardOutput.ReadToEndAsync(cancellationToken);
        Task<string> standardErrorTask = process.StandardError.ReadToEndAsync(cancellationToken);

        await process.WaitForExitAsync(cancellationToken);

        string standardOutput = await standardOutputTask;
        string standardError = await standardErrorTask;

        if (process.ExitCode == 0)
        {
            return;
        }

        StringBuilder message = new();
        _ = message.Append("Git command failed");
        if (arguments.Count > 0)
        {
            _ = message.Append(" (");
            _ = message.Append(string.Join(" ", arguments));
            _ = message.Append(')');
        }

        if (!string.IsNullOrWhiteSpace(standardError))
        {
            _ = message.Append(": ");
            _ = message.Append(standardError.Trim());
        }
        else if (!string.IsNullOrWhiteSpace(standardOutput))
        {
            _ = message.Append(": ");
            _ = message.Append(standardOutput.Trim());
        }

        throw new InvalidOperationException(message.ToString());
    }
}
