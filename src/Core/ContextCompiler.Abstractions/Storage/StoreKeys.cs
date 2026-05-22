namespace ContextCompiler.Abstractions.Storage;

public static class StoreKeys
{
    public const string Root = "ctxc.root";
    public const string Output = "ctxc.output";

    public const string Workspace = "ctxc.workspace";
    public const string Modules = "ctxc.workspace.modules";
    public const string Externals = "ctxc.workspace.externals";
    public const string Reports = "ctxc.workspace.reports";
    public const string Diagnostics = "ctxc.workspace.diagnostics";
    public const string Cache = "ctxc.workspace.cache";
    public const string Temp = "ctxc.workspace.temp";
}
