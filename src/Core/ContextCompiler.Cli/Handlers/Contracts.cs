namespace ContextCompiler.Cli.Handlers;

public interface ICtxcCompileHandler
{
    Task<int> HandleAsync(CtxcCompileCommandLine compileCommandLine);
}

public interface ICtxcPrepareHandler
{
    Task<int> HandleAsync(CtxcPrepareCommandLine commandLine);
}

public interface ICtxcNewProjectHandler
{
    Task<int> HandleAsync(string path);
}

public interface ICtxcDiffHandler
{
    Task<int> HandleAsync(string left, string right, string format, string? outFile);
}

public interface ICtxcExplainHandler
{
    Task<int> HandleAsync(string input, string? outFile, string format);
}

public interface ICtxcHealthHandler
{
    Task<int> HandleAsync(string input, string format, int? failBelow);
}

public interface ICtxcViewsListHandler
{
    Task<int> HandleAsync(string input, bool json);
}

public interface ICtxcViewsRenderHandler
{
    Task<int> HandleAsync(string id, string input, string? outFile);
}

public interface ICtxcGuardsReportHandler
{
    Task<int> HandleAsync(string input, string format, string? outFile);
}

public interface ICtxcModulesListHandler
{
    Task<int> HandleAsync(bool json);
}

public interface ICtxcModulesAddHandler
{
    Task<int> HandleAsync(string packageId, string? version, string? source);
}

public interface ICtxcModulesRemoveHandler
{
    Task<int> HandleAsync(string packageId);
}

public interface ICtxcGraphExportHandler
{
    Task<int> HandleAsync(string input, string format, string? outFile);
}

public interface ICtxcConfigFilesAddHandler
{
    Task<int> HandleAsync(string path, string relativePath);
}
