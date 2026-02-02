using ContextCompiler.Abstractions.Configuration;
using ContextCompiler.Abstractions.Pipelines;
using ContextCompiler.Abstractions.Pipelines.Document;
using ContextCompiler.Abstractions.ReasoningIR;
using ContextCompiler.Abstractions.Tags;

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

            foreach (FileConfig cfgMatch in cfgProvider.Current.Files)
            {
                IReadOnlyList<ITag> cfgFilesMatchTags = [];
                Matcher cfgMatcher = new();
                cfgMatcher.AddIncludePatterns(cfgMatch.Includes);
                if (cfgMatcher.Match(ctx.FullPath).HasMatches)
                {
                    logger.LogDebug("Apply config tags {Tags} on file {FilePath}", string.Join(',', cfgMatch.Tags), ctx.FullPath);
                    ctx.AddTags(cfgMatch.Tags);

                    foreach (SubFilesMatchConfig sub in cfgMatch.Subs)
                    {
                        Matcher subMatcher = new();
                        subMatcher.AddIncludePatterns(sub.Includes);
                        subMatcher.AddExcludePatterns(sub.Excludes);
                        if (subMatcher.Match(ctx.FullPath).HasMatches)
                        {
                            logger.LogDebug("Apply config sub-tags {Tags} on file {FilePath}", string.Join(',', sub.Tags), ctx.FullPath);
                            ctx.AddTags(sub.Tags);
                        }
                    }
                }
            }

            await Task.CompletedTask;
        }
    }
}
