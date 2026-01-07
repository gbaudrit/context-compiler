using System;
using System.Collections.Generic;
using System.Text;

using ContextCompiler.Abstractions.Diagnostics;
using ContextCompiler.Abstractions.Models;
using ContextCompiler.Abstractions.Pipelines;
using ContextCompiler.Abstractions.Pipelines.DataPart;
using ContextCompiler.Abstractions.Pipelines.Document;
using ContextCompiler.Abstractions.Plugins;

namespace ContextCompiler.Core.Pipelines.Document
{
    internal sealed class FragmentGuardsPass(IPluginRegistry plugins) : IDataPartPass
    {
        public string Id => "guards.fragment";
        public int Priority => 100;
        public DocumentStage Stage => DocumentStage.Fragment;

        public async ValueTask ExecuteAsync(IDocumentContext ctx, IDataPart part, CancellationToken ct)
        {
            var guards = plugins.Guards.Where(g => g.Stage == Stage).OrderBy(g => g.Metadata.Priority).ToList();
            var findings = new List<IPipelineFinding>();
            foreach (var g in guards)
            {
                var f = await g.EvaluateAsync(new GuardContext(ctx, part), ct);
                if (f.Count > 0) findings.AddRange(f);
            }
        }
    }
}
