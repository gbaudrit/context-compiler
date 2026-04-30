using ContextCompiler.Abstractions.Common;
using ContextCompiler.Abstractions.Pipelines.Document;
using ContextCompiler.Abstractions.ReasoningIR;
using ContextCompiler.Abstractions.Tags;

namespace ContextCompiler.Core.ReasoningIR
{
    internal sealed class FragmentBuilder(IEvidenceBuilder evidenceBuilder, ISourceRefBuilder sourceRefBuilder, ITagsBuilder tagsBuilder) : IFragmentBuilder
    {
        private IDataPart? _datapart;
        private string _content = string.Empty;
        private string _filePath = string.Empty;
        private string _locator = string.Empty;
        private IReadOnlyList<ITag> _tags = [];

        public IFragmentBuilder InitNew()
        {
            _datapart = null;
            _content = string.Empty;
            _filePath = string.Empty;
            _locator = string.Empty;
            _tags = [];
            return this;
        }

        public IFragmentBuilder ForDataPart(IDataPart datapart)
        {
            _datapart = datapart;
            return this;
        }

        public IFragmentBuilder WithContent(string content)
        {
            _content = content;
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
            ArgumentNullException.ThrowIfNull(_datapart, nameof(_datapart));

            _ = tagsBuilder.InitNewFrom(_datapart.Tags).AddRange(_tags);

            if (!string.IsNullOrWhiteSpace(_datapart.PartId))
            {
                _ = tagsBuilder.Add("extractId", _datapart.PartId);
            }


            if (!string.IsNullOrWhiteSpace(_datapart.Label))
            {
                _ = tagsBuilder.Add("extractLabel", _datapart.Label);
            }

            return new Fragment
            {
                Content = _content,
                Evidence = evidenceBuilder.InitNew().ForContent(_content).WithLocator(CombineLocator(_datapart?.Source?.Locator ?? string.Empty, _locator)).ForFile(_filePath).Build(),
                Source = sourceRefBuilder.InitNew().WithPath(_filePath).WithLocator(_locator).Build(),
                Tags = [.. _tags.DistinctBy(t => t.Name + t.Value)],
            };
        }

        private static string CombineLocator(string prefix, string? locator)
        {
            return string.IsNullOrEmpty(locator) ? prefix : string.IsNullOrEmpty(prefix) ? locator ?? string.Empty : prefix + "/" + locator;
        }

    }
}
