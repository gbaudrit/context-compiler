using System;
using System.Collections.Generic;
using System.Text;

using ContextCompiler.Abstractions.Diagnostics;
using ContextCompiler.Abstractions.Guards;
using ContextCompiler.Abstractions.Models;
using ContextCompiler.Abstractions.Pipelines;

namespace ContextCompiler.Core.Guards
{
    internal sealed class Guardian : IGuardian
    {
        private List<GuardFinding> _findings = new();

        public IReadOnlyList<GuardFinding> Findings => _findings;

        public void Load(IReadOnlyList<IDocumentCompileResult> documents)
        {
            _findings = documents.SelectMany(r => r.Findings).ToList();
        }

        public bool HasBlockingCriticalFindings()
        {
            return _findings.Any(f => f.Action == GuardActionKind.Block && f.Severity == GuardSeverity.Critical);
        }

        public void AddFinding(string GuardId,
                                GuardStage stage,
                                GuardSeverity Severity,
                                GuardActionKind Action,
                                string Message,
                                SourceRef Source,
                                IReadOnlyDictionary<string, object>? Data = null)
        {
            var finding = new GuardFinding(GuardId,
                Severity,
                Action,
                Message,
                Source,
                Data ?? new Dictionary<string, object>());

            _findings.Add(finding);
        }

        //public IReadOnlyList<GuardFinding> GetFindingsByStage(GuardStage stage)
        //{
        //    return _findings.Where(f => f.Stage == stage).ToList();
        //}

    }
}
