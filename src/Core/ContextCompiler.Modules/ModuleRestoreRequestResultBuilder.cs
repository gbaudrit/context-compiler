using ContextCompiler.Modules.Abstractions;

namespace ContextCompiler.Modules
{
    internal sealed class ModuleRestoreRequestResultBuilder : IModuleRestoreRequestResultBuilder
    {

        internal sealed record ModuleRestoreRequestResult : IModuleRestoreRequestResult
        {
            public required bool Success { get; init; }
            public required string RestoredPath { get; init; }
            public required IModuleMetadatas Metadatas { get; init; }
        }


        private bool _success;
        private string _restoredPath = string.Empty;
        private IModuleMetadatas? _metadatas;

        public IModuleRestoreRequestResultBuilder InitNew()
        {
            _success = false;
            _restoredPath = string.Empty;
            _metadatas = null;
            return this;
        }

        public IModuleRestoreRequestResultBuilder InitNewFrom(IModuleRestoreRequestResult result)
        {
            _success = result.Success;
            _restoredPath = result.RestoredPath;
            _metadatas = result.Metadatas;
            return this;
        }

        public IModuleRestoreRequestResultBuilder WithSuccess(bool success)
        {
            _success = success;
            return this;
        }

        public IModuleRestoreRequestResultBuilder WithRestoredPath(string restoredPath)
        {
            _restoredPath = restoredPath;
            return this;
        }

        public IModuleRestoreRequestResultBuilder WithMetadatas(IModuleMetadatas metadatas)
        {
            _metadatas = metadatas;
            return this;
        }

        public IModuleRestoreRequestResult Build()
        {
            return new ModuleRestoreRequestResult
            {
                Success = _success,
                RestoredPath = _restoredPath,
                Metadatas = _metadatas ?? throw new InvalidOperationException("Metadatas must be set before building.")
            };
        }
    }
}
