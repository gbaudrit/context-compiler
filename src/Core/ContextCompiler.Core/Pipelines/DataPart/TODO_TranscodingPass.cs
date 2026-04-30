//using ContextCompiler.Abstractions.Pipelines.DataPart;
//using ContextCompiler.Abstractions.Pipelines.Document;
//using ContextCompiler.Abstractions.ReasoningIR;
//using ContextCompiler.Abstractions.Tags;
//using ContextCompiler.Modules.Abstractions;

//namespace ContextCompiler.Core.Pipelines.DataPart
//{
//    internal sealed class TODO_TranscodingPass(IModulesRegistry modules, IFragmentBuilder fragmentBuilder, ITagsBuilder tagsBuilder) : IDataPartPass
//    {
//        public string Id => "pass.transcoding";
//        public int Priority => 100;
//        public DocumentStage Stage => DocumentStage.TranscodeFragment;

//        public async ValueTask<IDocumentContextDataPatch> ExecuteAsync(IDocumentContext ctx, IDocumentContextDataPatchBuilder patcher, IDataPart part, CancellationToken ct)
//        {
//            if (ctx.Data.DataEnvelope is null)
//            {
//                return patcher.AddFinding(
//                    FindingSeverity.Warning,
//                    FindingAction.Skip,
//                    Id,
//                    $"No data available in context for part '{part.PartId}'. Skipping transcoding.").Build();
//            }

//            ITranscoderModule? transcoder = modules.Transcoders.FirstOrDefault(t => t.CanTranscode(ctx.Data.DataEnvelope));

//            if (transcoder is null)
//            {
//                return patcher.AddFinding(
//                    FindingSeverity.Warning,
//                    FindingAction.Skip,
//                    Id,
//                    $"No transcoder found for data '{ctx.Data.DataEnvelope.Shape}'. Skipping transcoding.").Build();
//            }

//            IReadOnlyList<TranscodedFragment> transcoded = await transcoder.TranscodeAsync(ctx.Data.DataEnvelope, part, ct);

//            IEnumerable<IFragmentProcessorModule> fragmentProcessorModules = modules.FragmentProcessors;

//            List<IFragment> fragments = [];

//            foreach (TranscodedFragment tf in transcoded)
//            {
//                string locator = CombineLocator(part.Source.Locator ?? string.Empty, tf.Locator);

//                _ = tagsBuilder.InitNewFrom(ctx.Data.Tags).AddRange(tf.Tags);

//                if (!string.IsNullOrWhiteSpace(part.PartId))
//                {
//                    _ = tagsBuilder.Add("extractId", part.PartId);
//                }


//                if (!string.IsNullOrWhiteSpace(part.Label))
//                {
//                    _ = tagsBuilder.Add("extractLabel", part.Label);
//                }

//                IFragment fragment = fragmentBuilder.InitNew().WithTranscodedFragment(tf).WithFilePath(ctx.FullPath).WithLocator(locator).WithTags(tagsBuilder.Build()).Build();
//                fragments.Add(fragment);

//                foreach (IFragmentProcessorModule fragmentProcessorModule in fragmentProcessorModules)
//                {
//                    await fragmentProcessorModule.Process(fragment, part, ct);
//                }
//            }

//            return documentContextDataPatchBuilder.InitNew().WithFragments(fragments).Build();


//        }

//        private static string CombineLocator(string prefix, string? locator)
//        {
//            return string.IsNullOrEmpty(locator) ? prefix : string.IsNullOrEmpty(prefix) ? locator ?? string.Empty : prefix + "/" + locator;
//        }
//    }
//}
