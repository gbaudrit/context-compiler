using ContextCompiler.Abstractions.Compiled;
using ContextCompiler.Abstractions.Ports;
using ContextCompiler.Core.CompiledContext.Domain;

namespace ContextCompiler.Core.CompiledContext
{
    internal sealed class EvidenceBuilder(IHasher hasher) : IEvidenceBuilder
    {
        private string _filePath = string.Empty;
        private string _content = string.Empty;
        private string _locator = string.Empty;

        public IEvidenceBuilder InitNew()
        {
            _filePath = string.Empty;
            _content = string.Empty;
            _locator = string.Empty;
            return this;
        }

        public IEvidence Build()
        {
            return new Evidence("E-" + hasher.Sha256Hex(_filePath + "|" + _locator)[..12],
                                "R-" + hasher.Sha256Hex(_filePath + "|" + _locator + "|" + _content)[..12],
                                "RE-" + hasher.Sha256Hex(_locator ?? "")[..12],
                                "RR-" + hasher.Sha256Hex(_locator + "|" + _content)[..12]);
        }

        public IEvidenceBuilder ForFile(string filePath)
        {
            _filePath = filePath;
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
