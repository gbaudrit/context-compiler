using ContextCompiler.Abstractions.Views;

namespace ContextCompiler.Core.Views
{
    internal sealed class ViewResultBuilder : IViewResultBuilder
    {
        private string? _id;
        private string? _title;
        private string? _filename;
        private string? _content;
        private string? _mime;

        private IReadOnlyDictionary<string, string>? _metadata;

        public IViewResultBuilder InitNew()
        {
            return this;
        }

        public IViewResultBuilder WithId(string viewId)
        {
            _id = viewId;
            return this;
        }

        public IViewResultBuilder WithTitle(string title)
        {
            _title = title;
            return this;
        }

        public IViewResultBuilder WithFilename(string filename)
        {
            _filename = filename;
            return this;
        }

        public IViewResultBuilder WithContent(string content)
        {
            _content = content;
            return this;
        }

        public IViewResultBuilder WithMime(string mime)
        {
            _mime = mime;
            return this;
        }

        //public IViewResultBuilder AsMarkdown()
        //{
        //    _mime = "text/markdown";
        //    _extension = "md";
        //    return this;
        //}

        //public IViewResultBuilder AsJson()
        //{
        //    _mime = "application/json";
        //    _extension = "json";
        //    return this;
        //}

        public IViewResultBuilder WithMetadata(IReadOnlyDictionary<string, string> metadata)
        {
            _metadata = metadata;
            return this;
        }

        public IViewResult Build()
        {
            ArgumentException.ThrowIfNullOrEmpty(_id, nameof(_id));
            ArgumentException.ThrowIfNullOrEmpty(_content, nameof(_content));
            ArgumentException.ThrowIfNullOrEmpty(_mime, nameof(_mime));
            ArgumentException.ThrowIfNullOrEmpty(_filename, nameof(_filename));

            return new ViewResult(
                _id,
                _title ?? "",
                _filename,
                _content,
                _mime,
                _metadata ?? new Dictionary<string, string>());

        }

    }
}
