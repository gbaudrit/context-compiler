using ContextCompiler.Abstractions.DependencyInjection;

namespace ContextCompiler.Core.DependencyInjectionBuilders
{
    public class ContextCompilerStorageBuilder : IContextCompilerStorageBuilder
    {
        private readonly Dictionary<string, string> _storeNamesOverrides = [];

        public IContextCompilerStorageBuilder UpdateStoreName(string storeKey, string newName)
        {
            _storeNamesOverrides[storeKey] = newName;
            return this;
        }
    }
}
