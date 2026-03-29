using ContextCompiler.Abstractions.Diagnostics;

namespace ContextCompiler.Modules.BuiltIn.Guards
{
    internal interface IInjectionGuard
    {
        GuardFinding? Scan(string path, string content);
    }
}
