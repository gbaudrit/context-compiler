using System;
using System.Collections.Generic;
using System.Text;

using ContextCompiler.Abstractions.Personas;
using ContextCompiler.Abstractions.Prompt;
using ContextCompiler.Abstractions.Views;

namespace ContextCompiler.Abstractions.Output
{
    public interface IPrompt
    {
        //string Global { get; set; }
        IReadOnlyList<IPersonaResult> Personas { get; set; }
        IReadOnlyList<IViewResult> Views { get; set; }
        IReadOnlyList<IMustConstraint> MustConstraints { get; set; }
        IReadOnlyList<IMustNotConstraint> MustNotConstraints { get; set; }
        string Name { get; set; }
        string Summary { get; set; }
        string Domain { get; set; }
        IReadOnlyList<string> Audiences { get; set; }
        IReadOnlyList<string> Objectives { get; set; }
        IReadOnlyList<string> Assumptions { get; set; }
    }
}
