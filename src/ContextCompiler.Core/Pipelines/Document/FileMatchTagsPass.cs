using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

using ContextCompiler.Abstractions;
using ContextCompiler.Abstractions.Configuration;
using ContextCompiler.Abstractions.Diagnostics;
using ContextCompiler.Abstractions.Models;
using ContextCompiler.Abstractions.Pipelines;
using ContextCompiler.Abstractions.Pipelines.Document;
using ContextCompiler.Abstractions.Plugins;
using ContextCompiler.Abstractions.ReasoningIR;
using ContextCompiler.Core.ReasoningIR;
using ContextCompiler.Core.Services;

using Microsoft.Extensions.FileSystemGlobbing;
using Microsoft.Extensions.Logging;

namespace ContextCompiler.Core.Pipelines.Document
{
    internal sealed class FileMatchTagsPass(IPluginRegistry plugins, ICtxcConfigProvider cfgProvider, ITagsBuilder tagsBuilder, ILogger<FileMatchTagsPass> logger) : IDocumentPass
    {
        public string Id => "pass.filematchtags";
        public int Priority => 100;
        public DocumentStage Stage => DocumentStage.FileRead;

        public async ValueTask ExecuteAsync(IDocumentContext ctx, CancellationToken ct)
        {
            
            foreach (var cfgMatch in cfgProvider.Current.Files)
            {
                IReadOnlyList<ITag> cfgFilesMatchTags = Array.Empty<ITag>();
                Matcher cfgMatcher = new();
                cfgMatcher.AddIncludePatterns(cfgMatch.Includes);
                if (cfgMatcher.Match(ctx.FullPath).HasMatches)
                {
                    logger.LogDebug("Apply config tags {Tags} on file {FilePath}", string.Join(',', cfgMatch.Tags), ctx.FullPath);
                    ctx.AddTags(cfgMatch.Tags);
                }
            }

            await Task.CompletedTask;
        }
    }
}
