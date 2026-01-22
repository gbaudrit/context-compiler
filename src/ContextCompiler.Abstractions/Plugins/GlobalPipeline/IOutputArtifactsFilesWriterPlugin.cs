using System;
using System.Collections.Generic;
using System.Text;

using ContextCompiler.Abstractions.Output;

namespace ContextCompiler.Abstractions.Plugins.GlobalPipeline
{
    public interface IOutputArtifactsFilesWriterPlugin : IGlobalPipelinePlugin
    {
        //ValueTask Run(CancellationToken ct);
    }
}
