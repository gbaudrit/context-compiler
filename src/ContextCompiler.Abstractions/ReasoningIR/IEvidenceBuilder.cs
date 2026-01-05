using System;
using System.Collections.Generic;
using System.Text;

using ContextCompiler.Abstractions.Plugins;

namespace ContextCompiler.Abstractions.ReasoningIR
{
    public interface IEvidenceBuilder
    {
        IEvidence Build();
        IEvidenceBuilder InitNew();
        IEvidenceBuilder ForFile(string filePath);
        IEvidenceBuilder ForTranscodedFragment(ITranscodedFragment transcodedFragment);
    }
}
