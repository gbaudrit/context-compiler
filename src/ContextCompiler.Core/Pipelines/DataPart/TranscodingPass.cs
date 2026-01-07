using System;
using System.Collections.Generic;
using System.Text;

using ContextCompiler.Abstractions;
using ContextCompiler.Abstractions.Pipelines;
using ContextCompiler.Abstractions.Pipelines.DataPart;
using ContextCompiler.Abstractions.Pipelines.Document;
using ContextCompiler.Abstractions.Plugins;
using ContextCompiler.Abstractions.ReasoningIR;
using ContextCompiler.Core.ReasoningIR;
using ContextCompiler.Core.Services;

namespace ContextCompiler.Core.Pipelines.DataPart
{
    internal sealed class TranscodingPass(IPluginRegistry plugins, IFragmentBuilder fragmentBuilder, ITagsBuilder tagsBuilder) : IDataPartPass
    {
        public string Id => "pass.transcoding";
        public int Priority => 100;
        public DocumentStage Stage => DocumentStage.TranscodeFragment;

        public async ValueTask ExecuteAsync(IDocumentContext ctx, IDataPart part, CancellationToken ct)
        {
            if (ctx.Data is null)
            {
                ctx.AddFinding(
                    FindingSeverity.Warning,
                    FindingAction.Skip,
                    Id,
                    $"No data available in context for part '{part.PartId}'. Skipping transcoding.");
                return;
            }

            var transcoder = plugins.Transcoders.FirstOrDefault(t => t.CanTranscode(ctx.Data));

            if (transcoder is null)
            {
                ctx.AddFinding(
                    FindingSeverity.Warning,
                    FindingAction.Skip,
                    Id,
                    $"No transcoder found for data '{ctx.Data.Shape}'. Skipping transcoding.");
                return;
            }

            var transcoded = await transcoder.TranscodeAsync(ctx.Data, part.Source, ct);
            foreach (var tf in transcoded)
            {
                var locator = CombineLocator(part.Source.Locator ?? string.Empty, tf.Locator);

                tagsBuilder.InitNewFrom(ctx.Tags).AddRange(tf.Tags);

                if (!string.IsNullOrWhiteSpace(part.PartId))
                {
                    tagsBuilder.Add("extractId", part.PartId);
                }


                if (!string.IsNullOrWhiteSpace(part.Label))
                {
                    tagsBuilder.Add("extractLabel", part.Label!);
                }

                ctx.AddFragment(fragmentBuilder.InitNew().WithTranscodedFragment(tf).WithFilePath(ctx.FullPath).WithLocator(locator).WithTags(tagsBuilder.Build()).Build());
            }
            ;


        }

        private static string CombineLocator(string prefix, string? locator)
        {
            if (string.IsNullOrEmpty(locator)) return prefix;
            if (string.IsNullOrEmpty(prefix)) return locator ?? string.Empty;
            return prefix + "/" + locator;
        }
    }
}
