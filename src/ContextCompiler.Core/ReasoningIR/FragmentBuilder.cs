using ContextCompiler.Abstractions.Common;
using ContextCompiler.Abstractions.Plugins;
using ContextCompiler.Abstractions.ReasoningIR;

namespace ContextCompiler.Core.ReasoningIR
{
    internal sealed class FragmentBuilder(IEvidenceBuilder evidenceBuilder, ISourceRefBuilder sourceRefBuilder) : IFragmentBuilder
    {

        private ITranscodedFragment? _transcodedFragment;
        private string _filePath = string.Empty;
        private string _locator = string.Empty;
        private IReadOnlyList<ITag> _tags = new List<ITag>();

        public IFragmentBuilder InitNew()
        {
            _transcodedFragment = null;
            _filePath = string.Empty;
            _locator = string.Empty;
            _tags = new List<ITag>();
            return this;
        }

        public IFragmentBuilder WithTranscodedFragment(ITranscodedFragment transcodedFragment)
        {
            _transcodedFragment = transcodedFragment;
            return this;
        }

        public IFragmentBuilder WithFilePath(string filePath)
        {
            _filePath = filePath;
            return this;
        }

        public IFragmentBuilder WithLocator(string locator)
        {
            _locator = locator;
            return this;
        }

        public IFragmentBuilder WithTags(IReadOnlyList<ITag> tags)
        {
            _tags = tags;
            return this;
        }

        public IFragment Build()
        {
            ArgumentNullException.ThrowIfNull(_transcodedFragment);

            return new Fragment
            {
                Content = _transcodedFragment.Content ?? string.Empty,
                Evidence = evidenceBuilder.InitNew().ForTranscodedFragment(_transcodedFragment).ForFile(_filePath).Build(),
                Source = sourceRefBuilder.InitNew().WithPath(_filePath).WithLocator(_locator).Build(),
                Tags = _tags.DistinctBy(t => t.Name + t.Value).ToArray(),
            };
        }

    }
}
