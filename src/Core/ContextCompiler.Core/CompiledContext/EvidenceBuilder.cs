using ContextCompiler.Abstractions.Compiled;
using ContextCompiler.Abstractions.Ports;
using ContextCompiler.Core.CompiledContext.Domain;

namespace ContextCompiler.Core.CompiledContext
{
    internal sealed class EvidenceBuilder(IHasher hasher) : IEvidenceBuilder
    {
        private Uri? _uri;
        private string _content = string.Empty;
        private string _locator = string.Empty;

        public IEvidenceBuilder InitNew()
        {
            _uri = null;
            _content = string.Empty;
            _locator = string.Empty;
            return this;
        }

        public IEvidence Build()
        {
            ArgumentNullException.ThrowIfNull(_uri, nameof(_uri));

            return new Evidence("E-" + hasher.Sha256Hex(_uri.AbsolutePath + "|" + _locator)[..12],
                                "R-" + hasher.Sha256Hex(_uri.AbsolutePath + "|" + _locator + "|" + _content)[..12],
                                "RE-" + hasher.Sha256Hex(_locator ?? "")[..12],
                                "RR-" + hasher.Sha256Hex(_locator + "|" + _content)[..12]);
        }

        public IEvidenceBuilder ForUri(Uri uri)
        {
            _uri = uri;
            return this;
        }

        public IEvidenceBuilder ForContent(string content)
        {
            _content = content;
            return this;
        }

        public IEvidenceBuilder WithLocator(string locator)
        {
            _locator = locator;
            return this;
        }
    }
}
