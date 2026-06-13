using System.Diagnostics;
using System.Reflection;

using Microsoft.Extensions.Logging;

namespace ContextCompiler.Cli.Handlers;

public record CtxcAutopilotCommandLine(
    string Input,
    string Output,
    string Name,
    string? Goal,
    string? Description,
    bool Force);

internal sealed class CtxcAutopilotHandler(
    ILogger<CtxcAutopilotHandler> logger) : ICtxcAutopilotHandler
{
    public async Task<int> HandleAsync(CtxcAutopilotCommandLine commandLine)
    {
        int rc = await RunStepAsync("analyze", BuildAnalyzeArgs(commandLine));
        if (rc != 0)
        {
            return rc;
        }

        rc = await RunStepAsync("modules restore --scope prepare", BuildRestoreArgs("prepare", commandLine.Force));
        if (rc != 0)
        {
            return rc;
        }

        rc = await RunStepAsync("prepare", BuildPrepareArgs(commandLine));
        if (rc != 0)
        {
            return rc;
        }

        rc = await RunStepAsync("modules restore --scope compile", BuildRestoreArgs("compile", commandLine.Force));
        return rc != 0 ? rc : await RunStepAsync("compile", BuildCompileArgs(commandLine));
    }

    private async Task<int> RunStepAsync(string name, IReadOnlyList<string> args)
    {
        logger.LogInformation("Autopilot step: {Step}", name);
        using Process process = StartCurrentCli(args);
        await process.WaitForExitAsync();
        int rc = process.ExitCode;
        if (rc != 0)
        {
            logger.LogError("Autopilot step failed: {Step} (rc={Rc})", name, rc);
        }

        return rc;
    }

    private static Process StartCurrentCli(IReadOnlyList<string> args)
    {
        string? processPath = Environment.ProcessPath;
        string entryAssemblyPath = Assembly.GetEntryAssembly()?.Location
            ?? throw new InvalidOperationException("Unable to determine current CLI assembly.");

        ProcessStartInfo startInfo = new()
        {
            UseShellExecute = false,
        };

        if (processPath is not null && string.Equals(Path.GetFileNameWithoutExtension(processPath), "dotnet", StringComparison.OrdinalIgnoreCase))
        {
            startInfo.FileName = processPath;
            startInfo.ArgumentList.Add(entryAssemblyPath);
        }
        else
        {
            startInfo.FileName = processPath ?? entryAssemblyPath;
        }

        foreach (string arg in args)
        {
            startInfo.ArgumentList.Add(arg);
        }

        return Process.Start(startInfo) ?? throw new InvalidOperationException("Unable to start CLI process.");
    }

    private static List<string> BuildAnalyzeArgs(CtxcAutopilotCommandLine commandLine)
    {
        List<string> args = ["analyze", "--input", commandLine.Input];
        AddOptional(args, "--goal", commandLine.Goal);
        AddOptional(args, "--description", commandLine.Description);
        return args;
    }

    private static List<string> BuildPrepareArgs(CtxcAutopilotCommandLine commandLine)
    {
        List<string> args = ["prepare", "--input", commandLine.Input];
        AddOptional(args, "--goal", commandLine.Goal);
        AddOptional(args, "--description", commandLine.Description);
        return args;
    }

    private static List<string> BuildRestoreArgs(string scope, bool force)
    {
        List<string> args = ["modules", "restore", "--scope", scope];
        if (force)
        {
            args.Add("--force");
        }

        return args;
    }

    private static List<string> BuildCompileArgs(CtxcAutopilotCommandLine commandLine)
    {
        List<string> args = ["compile", "--input", commandLine.Input];
        AddOptional(args, "--output", commandLine.Output);
        AddOptional(args, "--context", commandLine.Name);
        return args;
    }

    private static void AddOptional(List<string> args, string name, string? value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            return;
        }

        args.Add(name);
        args.Add(value);
    }
}
