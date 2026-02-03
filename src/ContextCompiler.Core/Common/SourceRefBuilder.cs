using ContextCompiler.Abstractions.Common;
using ContextCompiler.Abstractions.Models;

namespace ContextCompiler.Core.Common
{
    internal sealed class SourceRefBuilder : ISourceRefBuilder
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

            return new SourceRef(_path, _locator);
        }
    }
}
