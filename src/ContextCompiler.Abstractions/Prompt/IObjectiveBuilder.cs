using System;
using System.Collections.Generic;
using System.Text;

namespace ContextCompiler.Abstractions.Prompt
{
    public interface IObjectiveBuilder
    {
        IObjective Build();
        IObjectiveBuilder InitNew();
        IObjectiveBuilder WithDescription(string description);
        IObjectiveBuilder WithName(string name);
    }
}
