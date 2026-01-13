using System;
using System.Collections.Generic;
using System.Text;

namespace ContextCompiler.Abstractions.Pipelines.Document
{
    public interface IDataEnvelopeBuilder
    {
        IDataEnvelopeBuilder InitNew();
        IDataEnvelopeBuilder WithDataShape(DataShape shape);
        IDataEnvelopeBuilder WithMetadata(IReadOnlyDictionary<string, string> metadata);
        IDataEnvelope Build();
        IDataEnvelopeBuilder InitNewFrom(IDataEnvelope dataEnvelope);
        IDataEnvelopeBuilder WithSinglePart(IDataPart part);
        IDataEnvelopeBuilder WithParts(IEnumerable<IDataPart> parts);
    }
}
