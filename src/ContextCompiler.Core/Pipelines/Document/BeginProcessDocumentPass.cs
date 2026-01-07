using System;
using System.Collections.Generic;
using System.Text;

using ContextCompiler.Abstractions.Diagnostics;
using ContextCompiler.Abstractions.Models;
using ContextCompiler.Abstractions.Pipelines;
using ContextCompiler.Abstractions.Pipelines.Document;
using ContextCompiler.Abstractions.Plugins;
using ContextCompiler.Core.ReasoningIR;

using Microsoft.Extensions.Logging;

namespace ContextCompiler.Core.Pipelines.Document
{
    internal sealed class BeginProcessDocumentPass(ILogger<BeginProcessDocumentPass> logger) : IDocumentPass
    {
        public string Id => "pass.beginprocess";
        public int Priority => 200;
        public DocumentStage Stage => DocumentStage.StartProcess;

        public async ValueTask ExecuteAsync(IDocumentContext ctx, CancellationToken ct)
        {
            logger.LogInformation("Beginning processing of document: {DocumentPath}", ctx.FullPath);

            await Task.CompletedTask;
        }
    }
}
