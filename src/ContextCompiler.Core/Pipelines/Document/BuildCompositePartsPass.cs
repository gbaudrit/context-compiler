using ContextCompiler.Abstractions.Pipelines;
using ContextCompiler.Abstractions.Pipelines.DataPart;
using ContextCompiler.Abstractions.Pipelines.Document;

namespace ContextCompiler.Core.Pipelines.Document
{
    internal sealed class BuildCompositePartsPass(IPluginRegistry plugins, IDataPartPipelineRunner dataPartPipelineRunner) : IDocumentPass
    {
        public string Id => "pass.buildcompositeparts";
        public int Priority => 100;
        public DocumentStage Stage => DocumentStage.DataRead;

        public async ValueTask ExecuteAsync(IDocumentContext ctx, CancellationToken ct)
        {
            //if (ctx.Data is null || (await ctx.GetContentStream()).Length == 0)
            //    return;
            if (ctx.Data is null)
            {
                return;
            }

            //var compositeParts = TryGetCompositeParts(ctx.Data);
            //if (compositeParts is not null)
            //{
            foreach (IDataPart part in ctx.Data.Parts)
            {
                _ = await dataPartPipelineRunner.RunAsync(ctx, part, ct);
                //var partEnv = part.Envelope;
                //foreach (var mod in plugins.EngineeringModules.OrderBy(m => m.Metadata.Priority))
                //    partEnv = await mod.ApplyAsync(partEnv, ct);

                //var fragFindings = await RunGuardsAsync(GuardStage.Fragment, new GuardContext(rootPath, filePath, doc.Text, doc, partEnv), ct);
                //if (fragFindings.Any(f => f.Action is GuardActionKind.Block))
                //{
                //    results.Add(new DocumentCompileResult(filePath, Array.Empty<Fragment>(), readFindings.Concat(fragFindings).ToList()));
                //    continue;
                //}

                //var transcoder = plugins.Transcoders.FirstOrDefault(t => t.CanTranscode(partEnv));
                //if (transcoder is null)
                //{
                //    results.Add(new DocumentCompileResult(filePath, Array.Empty<Fragment>(), readFindings.Concat(fragFindings).ToList()));
                //    continue;
                //}

                //var transcoded = await transcoder.TranscodeAsync(partEnv, part.Source, ct);
                //var fragments = transcoded.Select(tf =>
                //{
                //    var locator = CombineLocator(part.Source.Locator ?? string.Empty, tf.Locator);
                //    IList<ITag> fragmentTags = tf.Tags is null ? new List<ITag>() : new List<ITag>(tf.Tags);
                //    fragmentTags.Add(new Tag("extractId", part.PartId));
                //    fragmentTags = tagBuilder.AddRange(fragmentTags, cfgFilesMatchTags);
                //    if (!string.IsNullOrWhiteSpace(part.Label)) fragmentTags.Add(new Tag("extractLabel", part.Label!));

                //    return fragmentBuilder.InitNew().WithTranscodedFragment(tf).WithFilePath(filePath).WithLocator(locator).WithTags(fragmentTags).Build();
                //}).ToList();

                //results.Add(new DocumentCompileResult(filePath, fragments, readFindings.Concat(fragFindings).ToList()));
            }
            //continue; // handled composite
            //}
        }

        //private static IReadOnlyList<DataPart>? TryGetCompositeParts(IDataEnvelope env)
        //{
        //    if (env.Shape != DataShape.Composite) return null;
        //    if (env.Payload is CompositeDataEnvelope c) return c.Parts;
        //    return null;
        //}
    }
}
