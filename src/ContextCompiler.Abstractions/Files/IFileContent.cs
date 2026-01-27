using System;
using System.Collections.Generic;
using System.Text;

namespace ContextCompiler.Abstractions.Files
{
    public interface IFileContent : IDisposable
    {

        public Stream NextPart();

    }
}
