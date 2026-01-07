using System;
using System.Collections.Generic;
using System.Text;

using ContextCompiler.Abstractions.Diagnostics;
using ContextCompiler.Abstractions.Models;
using ContextCompiler.Abstractions.Pipelines;
using ContextCompiler.Abstractions.Pipelines.Document;
using ContextCompiler.Abstractions.Plugins;

namespace ContextCompiler.Core.Pipelines.Document
{
    internal sealed class ReadScopeGuardsPass(IPluginRegistry plugins) : IDocumentPass
    {
        public string Id => "guards.readscope";
        public int Priority => 100;
        public DocumentStage Stage => DocumentStage.FileRead;

        public async ValueTask ExecuteAsync(IDocumentContext ctx, CancellationToken ct)
        {
            var guards = plugins.Guards.Where(g => g.Stage == Stage).OrderBy(g => g.Metadata.Priority).ToList();
            var findings = new List<IPipelineFinding>();
            foreach (var g in guards)
            {
                var f = await g.EvaluateAsync(new GuardContext(ctx), ct);
                if (f.Count > 0) findings.AddRange(f);
            }
        }
    }
}
