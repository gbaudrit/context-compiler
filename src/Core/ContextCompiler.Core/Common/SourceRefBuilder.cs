using ContextCompiler.Abstractions.Common;
using ContextCompiler.Abstractions.Models;
using ContextCompiler.Abstractions.Ports;

namespace ContextCompiler.Core.Common
{
    internal sealed class SourceRefBuilder(IHasher hasher) : ISourceRefBuilder
    {
        private string? _path;
        private string _locator = string.Empty;

        public ISourceRefBuilder InitNew()
        {
            _path = null;
            _locator = string.Empty;
            return this;
        }

        public ISourceRefBuilder WithPath(string path)
        {
            _path = path;
            return this;
        }

        public ISourceRefBuilder WithLocator(string locator)
        {
            _locator = locator;
            return this;
        }

        public ISourceRef Build()
        {
            ArgumentNullException.ThrowIfNull(_path);

            return new SourceRef("S-" + hasher.Sha256Hex(_path)[..10], _path, _locator);
        }
    }
}
