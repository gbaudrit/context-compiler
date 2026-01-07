using System;
using System.Collections.Generic;
using System.Text;

using ContextCompiler.Abstractions.Diagnostics;
using ContextCompiler.Abstractions.Models;
using ContextCompiler.Abstractions.Pipelines;
using ContextCompiler.Abstractions.Pipelines.Document;
using ContextCompiler.Abstractions.Plugins;
using ContextCompiler.Core.ReasoningIR;

namespace ContextCompiler.Core.Pipelines.Document
{
    internal sealed class ReadDocumentPass(IPluginRegistry plugins) : IDocumentPass
    {
        public string Id => "pass.read";
        public int Priority => 200;
        public DocumentStage Stage => DocumentStage.FileRead;

        public async ValueTask ExecuteAsync(IDocumentContext ctx, CancellationToken ct)
        {
            var reader = plugins.FileReaders.FirstOrDefault(r => r.CanRead(ctx.FullPath));
            if (reader is null) return;

            var doc = await reader.ReadAsync(ctx.FullPath, ct);

            var dataReader = plugins.DataReaders.FirstOrDefault(r => r.CanRead(doc));
            if (dataReader is null) return;

            var envelope = await dataReader.ReadAsync(doc, ct);
            ctx.SetData(envelope);

            await Task.CompletedTask;
        }
    }
}
