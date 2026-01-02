using ContextCompiler.Abstractions.Diagnostics;

namespace ContextCompiler.Plugins.BuiltIn.Guards
{
    internal interface IInjectionGuard
    {
        GuardFinding? Scan(string path, string content);
    }
}
