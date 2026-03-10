using ContextCompiler.Abstractions;
using ContextCompiler.Modules.Artifacts.Registry.Abstractions;
using ContextCompiler.Modules.Artifacts.Registry.Models;

namespace ContextCompiler.Modules.Artifacts.Registry
{
    internal sealed class ArtifactsStore(ICompiledWorkingFolder compiledWorkingFolder, IJsonIndexSerializer jsonIndexSerializer) : IArtifactsStore
    {

        private const string _filename = "artifacts.index.json";

        private ArtifactsIndex? _index;

        [System.Diagnostics.CodeAnalysis.MemberNotNull(nameof(_index))]
        private void EnsureLoaded()
        {
            string filename = Path.Combine(compiledWorkingFolder.Path(), _filename);

            if (!Path.Exists(filename))
            {
                throw new InvalidOperationException("Failed to load artifacts index.");
            }

            _index = jsonIndexSerializer.Deserialize(File.ReadAllText(filename));
        }

        public Task<IReadOnlyList<Artifact>> List(CancellationToken cancellationToken)
        {
            EnsureLoaded();

            return Task.FromResult(_index.Artifacts);
        }

    }
}
