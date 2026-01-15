using System;
using System.Collections.Generic;
using System.Text;

using ContextCompiler.Abstractions.Configuration;
using ContextCompiler.Abstractions.Output;

namespace ContextCompiler.Plugins.BuiltIn.GlobalPipeline.PrompComposer
{
    internal interface IPromptComposerContext
    {

        public IPrompt Prompt { get; }

        public ContextConfig Config { get; }

    }
}
