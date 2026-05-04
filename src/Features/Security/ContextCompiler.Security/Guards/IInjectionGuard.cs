using ContextCompiler.Abstractions.Diagnostics;

namespace ContextCompiler.Security.Guards;

internal interface IInjectionGuard
{
    GuardFinding? Scan(string path, string content);
}
