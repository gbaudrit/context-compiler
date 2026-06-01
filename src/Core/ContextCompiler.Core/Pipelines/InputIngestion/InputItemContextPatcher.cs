using ContextCompiler.Abstractions.Pipelines;
using ContextCompiler.Abstractions.Pipelines.InputIngestion;

namespace ContextCompiler.Core.Pipelines.InputIngestion;

internal sealed class InputItemContextPatcher(
    IInputItemContextDataBuilder inputItemContextDataBuilder,
    IInputItemContextBuilder inputItemContextBuilder) : IInputItemContextPatcher
{
    public Task<IInputItemContext> Patch(IInputItemContext context, IInputItemContextPatch patch)
    {
        if (patch is not InputItemContextPatch typedPatch)
        {
            return Task.FromResult(context);
        }

        IInputItemContextDataBuilder dataBuilder = inputItemContextDataBuilder
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

        IInputItemContextData updatedData = dataBuilder.Build();

        IInputItemContext updatedContext = inputItemContextBuilder
            .InitFrom(context)
            .WithData(updatedData)
            .Build();

        return Task.FromResult(updatedContext);
    }
}
