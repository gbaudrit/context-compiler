using System;
using System.Collections.Generic;
using System.Text;

using ContextCompiler.Abstractions.Diagnostics;
using ContextCompiler.Abstractions.Guards;
using ContextCompiler.Abstractions.Models;
using ContextCompiler.Abstractions.Pipelines.Document;

namespace ContextCompiler.Core.Guards
{
    internal sealed class Guardian : IGuardian
    {
        private List<IPipelineFinding> _findings = new();

        public IReadOnlyList<IPipelineFinding> Findings => _findings;

        public void Load(IDocumentsContext documents)
        {
            _findings = documents.Documents.SelectMany(r => r.Findings).ToList();
        }

        public bool HasBlockingCriticalFindings()
        {
            return _findings.Any(f => f.Action == FindingAction.Block && f.Severity == FindingSeverity.Critical);
        }

        //public void AddFinding(string GuardId,
        //                        GuardStage stage,
        //                        GuardSeverity Severity,
        //                        GuardActionKind Action,
        //                        string Message,
        //                        SourceRef Source,
        //                        IReadOnlyDictionary<string, object>? Data = null)
        //{
        //    var finding = new GuardFinding(GuardId,
        //        Severity,
        //        Action,
        //        Message,
        //        Source,
        //        Data ?? new Dictionary<string, object>());

        //    _findings.Add(finding);
        //}

        //public IReadOnlyList<GuardFinding> GetFindingsByStage(GuardStage stage)
        //{
        //    return _findings.Where(f => f.Stage == stage).ToList();
        //}

    }
}
