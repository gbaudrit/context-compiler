using ContextCompiler.Abstractions.Configuration;
using ContextCompiler.Abstractions.Configuration.Sections;
using ContextCompiler.Abstractions.Pipelines.Document;
using ContextCompiler.Abstractions.Tags;
using ContextCompiler.Modules.Abstractions;

using Microsoft.Extensions.FileSystemGlobbing;
using Microsoft.Extensions.Logging;

namespace ContextCompiler.Core.Pipelines.Document
{
    internal sealed class FileMatchTagsModule(
        IModulesRegistry modules,
        IConfigProvider cfgProvider,
        ITagsBuilder tagsBuilder,
        ILogger<FileMatchTagsModule> logger) : IDocumentPipelineModule
    {
        public DocumentModuleMetadata Metadata => IDocumentPipelineModule.Meta(
            "pass.filematchtags",
            DocumentPipelineModuleKinds.FileMatchTags,
            priority: 100);

        public bool CanProcess(IDocumentContext documentContext)
        {
            return true;
        }

        public Task<IDocumentContextPatch> Run(IDocumentContext ctx, IDocumentContextPatchBuilder patcher, CancellationToken ct)
        {
            Matcher cfgMatcher = new();
            cfgMatcher.AddIncludePatterns(ctx.Source.Includes);
            List<string> tags = [];
            if (cfgMatcher.Match(ctx.FullPath).HasMatches)
            {
                logger.LogDebug("Apply config tags {Tags} on file {FilePath}", string.Join(',', ctx.Source.Tags), ctx.FullPath);
                tags.AddRange(ctx.Source.Tags);
                foreach (ISubFilesMatchConfigSection sub in ctx.Source.ConfigSection.Subs)
                {
                    Matcher subMatcher = new();
                    subMatcher.AddIncludePatterns(sub.Includes);
                    subMatcher.AddExcludePatterns(sub.Excludes);
                    if (subMatcher.Match(ctx.FullPath).HasMatches)
                    {
                        logger.LogDebug("Apply config sub-tags {Tags} on file {FilePath}", string.Join(',', sub.Tags), ctx.FullPath);
                        tags.AddRange(sub.Tags);
                    }
                }
            }

            return patcher.WithTags(tags).BuildAsTask();
        }
    }
}
