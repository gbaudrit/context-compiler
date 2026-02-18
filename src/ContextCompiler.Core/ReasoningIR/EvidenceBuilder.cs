using ContextCompiler.Abstractions.Ports;
using ContextCompiler.Abstractions.ReasoningIR;
using ContextCompiler.Core.ReasoningIR.Domain;

namespace ContextCompiler.Core.ReasoningIR
{
    internal sealed class EvidenceBuilder(IHasher hasher) : IEvidenceBuilder
    {
        private string _filePath = string.Empty;
        private ITranscodedFragment? _transcodedFragment;

        public IEvidenceBuilder InitNew()
        {
            _filePath = string.Empty;
            _transcodedFragment = null;
            return this;
        }

        public IEvidence Build()
        {
            return new Evidence("E-" + hasher.Sha256Hex(_filePath + "|" + _transcodedFragment?.Locator)[..12],
                                "R-" + hasher.Sha256Hex(_filePath + "|" + _transcodedFragment?.Locator + "|" + _transcodedFragment?.Content)[..12]);
        }

        public IEvidenceBuilder ForFile(string filePath)
        {
            _filePath = filePath;
            return this;
        }

        public IEvidenceBuilder ForTranscodedFragment(ITranscodedFragment transcodedFragment)
        {
            _transcodedFragment = transcodedFragment;
            return this;
        }
    }
}
