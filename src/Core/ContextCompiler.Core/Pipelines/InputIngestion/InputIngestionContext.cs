using ContextCompiler.Abstractions.Pipelines.InputIngestion;

namespace ContextCompiler.Core.Pipelines.InputIngestion
{
    internal sealed class InputIngestionContext : IInputIngestionContext
    {
        private readonly List<IInputItemContext> _inputItems = [];

        public required string RootPath { get; init; }

        public IReadOnlyList<IInputItemContext> InputItems => _inputItems;

        public void AddInputItem(IInputItemContext inputItem)
        {
            _inputItems.Add(inputItem);
        }

    }
}
