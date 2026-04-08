using System.Diagnostics.CodeAnalysis;

using ContextCompiler.Abstractions;
using ContextCompiler.Abstractions.Common;
using ContextCompiler.Modules.Artifacts.Registry.Abstractions;
using ContextCompiler.Modules.Artifacts.Registry.Models;

namespace ContextCompiler.Modules.Artifacts.Registry
{
    internal sealed class ArtifactsStore(ICompiledWorkingFolder compiledWorkingFolder, IJsonIndexSerializer jsonIndexSerializer) : IArtifactsStore
    {

        private const string _filename = "artifacts.index.json";

        private ArtifactsIndex? _index;

        [MemberNotNull(nameof(_index))]
        private void EnsureLoaded()
        {
            string filename = Path.Combine(compiledWorkingFolder.Path, _filename);

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

        public Task<IResult<Artifact>> TryGet(string id, CancellationToken cancellationToken)
        {
            EnsureLoaded();

            Artifact? artifact = _index.Artifacts.FirstOrDefault(a => a.Filename == id);
            return artifact is null ? Task.FromResult(IResult.Failure<Artifact>("Not found")) : Task.FromResult(IResult.Success(artifact));
        }
    }
}
