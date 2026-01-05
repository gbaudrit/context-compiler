using System;
using System.Collections.Generic;
using System.Text;

using ContextCompiler.Abstractions.Configuration;

namespace ContextCompiler.Abstractions.Views
{
    public interface IViewsProvider
    {

        IReadOnlyList<ViewConfig> Views { get; }

    }
}
