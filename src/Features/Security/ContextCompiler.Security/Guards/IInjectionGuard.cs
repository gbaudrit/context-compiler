using ContextCompiler.Abstractions.Diagnostics;

namespace ContextCompiler.Security.Guards;

internal interface IInjectionGuard
{
    GuardFinding? Scan(Uri uri, string content);
}
