using ContextCompiler.Abstractions.Diagnostics;

namespace ContextCompiler.Modules.Security.Guards;

internal interface IInjectionGuard
{
    GuardFinding? Scan(string path, string content);
}
