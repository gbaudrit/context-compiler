using System;
using System.Collections.Generic;
using System.Text;

using ContextCompiler.Abstractions.ReasoningIR;

namespace ContextCompiler.Abstractions.Plugins.GlobalPipeline
{
    public interface IOutputArtifactComposerPlugin : IGlobalPipelinePlugin
    {

        public ValueTask Compose(CancellationToken cancellationToken);

    }
}
