using ContextCompiler.Abstractions.Pipelines.InputIngestion;

namespace ContextCompiler.Core.Pipelines.InputIngestion
{
    internal sealed class DataEnvelopeBuilder : IDataEnvelopeBuilder
    {
        private DataShape _shape;
        private IReadOnlyDictionary<string, string>? _metadata;
        private readonly List<IDataPart> _parts = [];

        public IDataEnvelopeBuilder InitNew()
        {
            _shape = DataShape.Linear;
            _metadata = null;
            return this;
        }

        public IDataEnvelopeBuilder InitNewFrom(IDataEnvelope dataEnvelope)
        {
            _shape = dataEnvelope.Shape;
            _metadata = dataEnvelope.Metadata;
            return this;
        }

        public IDataEnvelopeBuilder WithDataShape(DataShape Shape)
        {
            _shape = Shape;
            return this;
        }

        public IDataEnvelopeBuilder WithMetadata(IReadOnlyDictionary<string, string>? Metadata)
        {
            _metadata = Metadata;
            return this;
        }

        public IDataEnvelopeBuilder AddPart(IDataPart part)
        {
            _parts.Add(part);
            return this;
        }

        public IDataEnvelopeBuilder WithSinglePart(IDataPart part)
        {
            _parts.Add(part);
            return this;
        }

        public IDataEnvelopeBuilder WithParts(IEnumerable<IDataPart> parts)
        {
            _parts.AddRange(parts);
            return this;
        }

        public IDataEnvelope Build()
        {

            return new DataEnvelope(_shape)
            {
                Metadata = _metadata,
                Parts = _parts.AsReadOnly()
            };
        }
    }
}
