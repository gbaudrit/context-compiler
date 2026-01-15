using System;
using System.Collections.Generic;
using System.Text;

using ContextCompiler.Abstractions.Plugins;

namespace ContextCompiler.Plugins.BuiltIn.GlobalPipeline.PrompComposer
{
    internal interface IPromptComposerPlugin : IGlobalPipelinePlugin
    {

        public ValueTask Run(IPromptComposerContext context, CancellationToken cancellationToken);

    }
}
