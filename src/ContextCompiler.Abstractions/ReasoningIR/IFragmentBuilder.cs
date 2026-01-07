using System;
using System.Collections.Generic;
using System.Text;

using ContextCompiler.Abstractions.Plugins;

namespace ContextCompiler.Abstractions.ReasoningIR
{
    public interface IFragmentBuilder
    {
        IFragment Build();
        IFragmentBuilder InitNew();
        IFragmentBuilder WithFilePath(string filePath);
        IFragmentBuilder WithLocator(string locator);
        IFragmentBuilder WithTags(IReadOnlyList<ITag> tags);
        IFragmentBuilder WithTranscodedFragment(ITranscodedFragment transcodedFragment);
    }
}
