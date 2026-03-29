using ContextCompiler.Abstractions.Models;

namespace ContextCompiler.Abstractions.Diagnostics;

public enum GuardSeverity { Info, Warning, Error, Critical }
public enum GuardActionKind { None, Warn, Skip, Redact, Quarantine, Block }
public enum GuardStage { Discovery, Read, Fragment, View, Preflight }

public sealed record GuardFinding(
    string GuardId,
    GuardSeverity Severity,
    GuardActionKind Action,
    string Message,
    ISourceRef Source,
    IReadOnlyDictionary<string, object>? Data = null
);
