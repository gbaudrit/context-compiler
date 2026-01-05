using System;
using System.Collections.Generic;
using System.Text;

using ContextCompiler.Abstractions.Diagnostics;
using ContextCompiler.Abstractions.Models;
using ContextCompiler.Abstractions.Pipelines;

namespace ContextCompiler.Abstractions.Guards
{
    public interface IGuardian
    {

        IReadOnlyList<GuardFinding> Findings { get; }

        void AddFinding(string GuardId, GuardStage stage, GuardSeverity Severity, GuardActionKind Action, string Message, SourceRef Source, IReadOnlyDictionary<string, object>? Data = null);
        //IReadOnlyList<GuardFinding> GetFindingsByStage(GuardStage stage);
        bool HasBlockingCriticalFindings();
        void Load(IReadOnlyList<IDocumentCompileResult> documents);
    }
}
