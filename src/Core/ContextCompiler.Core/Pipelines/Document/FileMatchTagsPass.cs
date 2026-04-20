using ContextCompiler.Abstractions.Configuration;
using ContextCompiler.Abstractions.Configuration.Sections;
using ContextCompiler.Abstractions.Pipelines.Document;
using ContextCompiler.Abstractions.Tags;
using ContextCompiler.Modules.Abstractions;

using Microsoft.Extensions.FileSystemGlobbing;
using Microsoft.Extensions.Logging;

namespace ContextCompiler.Core.Pipelines.Document
{
    internal sealed class FileMatchTagsPass(IModulesRegistry modules, IConfigProvider cfgProvider, ITagsBuilder tagsBuilder, ILogger<FileMatchTagsPass> logger) : IDocumentPass
    {
        public string Id => "pass.filematchtags";
        public int Priority => 100;
        public DocumentStage Stage => DocumentStage.FileRead;

        public async ValueTask ExecuteAsync(IDocumentContext ctx, CancellationToken ct)
        {

            //foreach (ISourceConfigSection cfgMatch in cfgProvider.Current.Sources)
            //{
            //IReadOnlyList<ITag> cfgFilesMatchTags = [];
            Matcher cfgMatcher = new();
            cfgMatcher.AddIncludePatterns(ctx.Source.Includes);
            if (cfgMatcher.Match(ctx.FullPath).HasMatches)
            {
                logger.LogDebug("Apply config tags {Tags} on file {FilePath}", string.Join(',', ctx.Source.Tags), ctx.FullPath);
                ctx.AddTags(ctx.Source.Tags);
                foreach (ISubFilesMatchConfigSection sub in ctx.Source.ConfigSection.Subs)
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
            //}

            await Task.CompletedTask;
        }
    }
}
