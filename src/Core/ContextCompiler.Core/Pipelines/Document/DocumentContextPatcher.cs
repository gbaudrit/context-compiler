using ContextCompiler.Abstractions.Pipelines;
using ContextCompiler.Abstractions.Pipelines.Document;

namespace ContextCompiler.Core.Pipelines.Document;

internal sealed class DocumentContextPatcher(
    IDocumentContextDataBuilder documentContextDataBuilder,
    IDocumentContextBuilder documentContextBuilder) : IDocumentContextPatcher
{
    public Task<IDocumentContext> Patch(IDocumentContext context, IDocumentContextPatch patch)
    {
        if (patch is not DocumentContextPatch typedPatch)
        {
            return Task.FromResult(context);
        }

        IDocumentContextDataBuilder dataBuilder = documentContextDataBuilder
            .InitFrom(context.Data);

        if (typedPatch.DataEnvelope is not null)
        {
            dataBuilder = dataBuilder.WithDataEnvelope(typedPatch.DataEnvelope);
        }

        if (typedPatch.Findings.Count > 0)
        {
            dataBuilder = dataBuilder.WithFindings(context.Data.Findings.Concat(typedPatch.Findings));
        }

        if (typedPatch.Fragments.Count > 0)
        {
            dataBuilder = dataBuilder.WithFragments(context.Data.Fragments.Concat(typedPatch.Fragments));
        }

        if (typedPatch.Tags.Count > 0)
        {
            dataBuilder = dataBuilder.WithTags(context.Data.Tags.Concat(typedPatch.Tags));
        }

        IDocumentContextData updatedData = dataBuilder.Build();

        IDocumentContext updatedContext = documentContextBuilder
            .InitFrom(context)
            .WithData(updatedData)
            .Build();

        return Task.FromResult(updatedContext);
    }
}
