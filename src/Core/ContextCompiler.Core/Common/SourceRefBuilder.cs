using ContextCompiler.Abstractions.Common;
using ContextCompiler.Abstractions.Models;
using ContextCompiler.Abstractions.Ports;

namespace ContextCompiler.Core.Common
{
    internal sealed class SourceRefBuilder(IHasher hasher) : ISourceRefBuilder
    {
        private Uri? _uri;
        private string _locator = string.Empty;

        public ISourceRefBuilder InitNew()
        {
            _uri = null;
            _locator = string.Empty;
            return this;
        }

        public ISourceRefBuilder WithUri(Uri uri)
        {
            _uri = uri;
            return this;
        }

        public ISourceRefBuilder WithLocator(string locator)
        {
            _locator = locator;
            return this;
        }

        public ISourceRef Build()
        {
            ArgumentNullException.ThrowIfNull(_uri);

            return new SourceRef("S-" + hasher.Sha256Hex(_uri.AbsoluteUri)[..10], _uri, _locator);
        }
    }
}
