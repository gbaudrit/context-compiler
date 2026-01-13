using System;
using System.Collections.Generic;
using System.Text;

using ContextCompiler.Abstractions.Configuration;
using ContextCompiler.Abstractions.ReasoningIR;
using ContextCompiler.Abstractions.Views;

namespace ContextCompiler.Abstractions.Plugins.Views.Renderers
{
    public interface IViewRenderersPlugin
    {
        ValueTask<IReadOnlyList<IViewResult>> RenderAsync(ViewConfig def, IReadOnlyList<IFragment> fragments, CancellationToken ct);
    }
}
