using System.Text;

using ContextCompiler.Abstractions.Files;

using UglyToad.PdfPig;

namespace ContextCompiler.Plugins.Readers.Pdf
{
    internal sealed class PdfFileContent : IFileContent
    {
        private int _currentPage;
        private bool disposedValue;

        public required PdfDocument Document { get; init; }

        public Stream NextPart()
        {
            if (_currentPage >= Document.NumberOfPages)
            {
                return Stream.Null;
            }
            _currentPage++;
            return new MemoryStream(Encoding.UTF8.GetBytes(Document.GetPage(_currentPage).Text));
        }

        private void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    Document.Dispose();
                }

                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~PdfFileContent()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
