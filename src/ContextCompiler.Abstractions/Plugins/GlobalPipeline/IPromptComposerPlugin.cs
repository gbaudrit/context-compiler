using System;
using System.Collections.Generic;
using System.Text;

using ContextCompiler.Abstractions.Plugins;

namespace ContextCompiler.Abstractions.Plugins.GlobalPipeline
{
    public interface IPromptComposerPlugin : IGlobalPipelinePlugin
    {

        public ValueTask Run(CancellationToken cancellationToken);

    }
}
