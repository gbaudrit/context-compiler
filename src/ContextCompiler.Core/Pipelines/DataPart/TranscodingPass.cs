using ContextCompiler.Abstractions.Pipelines.DataPart;
using ContextCompiler.Abstractions.Pipelines.Document;
using ContextCompiler.Abstractions.ReasoningIR;
using ContextCompiler.Abstractions.Tags;
using ContextCompiler.Modules.Abstractions;

namespace ContextCompiler.Core.Pipelines.DataPart
{
    internal sealed class TranscodingPass(IModulesRegistry modules, IFragmentBuilder fragmentBuilder, ITagsBuilder tagsBuilder) : IDataPartPass
    {
        public string Id => "pass.transcoding";
        public int Priority => 100;
        public DocumentStage Stage => DocumentStage.TranscodeFragment;

        public async ValueTask ExecuteAsync(IDocumentContext ctx, IDataPart part, CancellationToken ct)
        {
            if (ctx.Data is null)
            {
                _ = ctx.AddFinding(
                    FindingSeverity.Warning,
                    FindingAction.Skip,
                    Id,
                    $"No data available in context for part '{part.PartId}'. Skipping transcoding.");
                return;
            }

            ITranscoderModule? transcoder = modules.Transcoders.FirstOrDefault(t => t.CanTranscode(ctx.Data));

            if (transcoder is null)
            {
                _ = ctx.AddFinding(
                    FindingSeverity.Warning,
                    FindingAction.Skip,
                    Id,
                    $"No transcoder found for data '{ctx.Data.Shape}'. Skipping transcoding.");
                return;
            }

            IReadOnlyList<TranscodedFragment> transcoded = await transcoder.TranscodeAsync(ctx.Data, part, ct);
            foreach (TranscodedFragment tf in transcoded)
            {
                string locator = CombineLocator(part.Source.Locator ?? string.Empty, tf.Locator);

                _ = tagsBuilder.InitNewFrom(ctx.Tags).AddRange(tf.Tags);

                if (!string.IsNullOrWhiteSpace(part.PartId))
                {
                    _ = tagsBuilder.Add("extractId", part.PartId);
                }


                if (!string.IsNullOrWhiteSpace(part.Label))
                {
                    _ = tagsBuilder.Add("extractLabel", part.Label);
                }

                ctx.AddFragment(fragmentBuilder.InitNew().WithTranscodedFragment(tf).WithFilePath(ctx.FullPath).WithLocator(locator).WithTags(tagsBuilder.Build()).Build());
            }
            ;


        }

        private static string CombineLocator(string prefix, string? locator)
        {
            return string.IsNullOrEmpty(locator) ? prefix : string.IsNullOrEmpty(prefix) ? locator ?? string.Empty : prefix + "/" + locator;
        }
    }
}
