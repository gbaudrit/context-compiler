using System;
using System.Collections.Generic;
using System.Text;

using ContextCompiler.Abstractions.Output;
using ContextCompiler.Abstractions.Rendering;

namespace ContextCompiler.Abstractions.Plugins.Prompts
{
    public interface IPromptRenderingPlugin : IGlobalPipelinePlugin
    {
        //Task Run(CancellationToken ct);
    }
}
