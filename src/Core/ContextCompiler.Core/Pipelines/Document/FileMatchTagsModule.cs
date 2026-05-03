using ContextCompiler.Abstractions.Common;
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

        public Task<IResult<IDocumentPipelineRunResult>> Run(IDocumentPipelineRunContext context, CancellationToken ct)
        {
            Matcher cfgMatcher = new();
            cfgMatcher.AddIncludePatterns(context.Document.Source.Includes);
            List<string> tags = [];
            if (cfgMatcher.Match(context.Document.FullPath).HasMatches)
            {
                logger.LogDebug("Apply config tags {Tags} on file {FilePath}", string.Join(',', context.Document.Source.Tags), context.Document.FullPath);
                tags.AddRange(context.Document.Source.Tags);
                foreach (ISubFilesMatchConfigSection sub in context.Document.Source.ConfigSection.Subs)
                {
                    Matcher subMatcher = new();
                    subMatcher.AddIncludePatterns(sub.Includes);
                    subMatcher.AddExcludePatterns(sub.Excludes);
                    if (subMatcher.Match(context.Document.FullPath).HasMatches)
                    {
                        logger.LogDebug("Apply config sub-tags {Tags} on file {FilePath}", string.Join(',', sub.Tags), context.Document.FullPath);
                        tags.AddRange(sub.Tags);
                    }
                }
            }

            return context.Patch(b => b.WithTags(tags))
                          .Success();
        }
    }
}
