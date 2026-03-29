using ContextCompiler.Modules.Abstractions;

using Microsoft.Extensions.Logging;

namespace ContextCompiler;

public sealed class ContextCompilerBuilder
{
    private readonly List<IModule> _modules = [];

    private ContextCompilerBuilder()
    {
    }

    public static ContextCompilerBuilder Create()
    {
        return new ContextCompilerBuilder();
    }

    /// <summary>
    /// Add a custom module
    /// </summary>
    public ContextCompilerBuilder AddModule(IModule module)
    {
        ArgumentNullException.ThrowIfNull(module);

        _modules.Add(module);
        return this;
    }

    /// <summary>
    /// Add default modules (to be implemented later)
    /// </summary>
    public ContextCompilerBuilder AddDefaultModules()
    {
        // TODO: register built-in modules
        return this;
    }

    /// <summary>
    /// Build the compiler
    /// </summary>
    public ContextCompiler Build()
    {
        throw new NotImplementedException();
    }
}

public sealed class ContextCompiler(ILogger<ContextCompiler> logger)
{

    public Task RunAsync()
    {
        throw new NotImplementedException();
    }
}
