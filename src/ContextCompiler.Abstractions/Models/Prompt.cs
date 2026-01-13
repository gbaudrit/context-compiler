using System;
using System.Collections.Generic;
using System.Text;

using ContextCompiler.Abstractions.Output;
using ContextCompiler.Abstractions.Personas;
using ContextCompiler.Abstractions.Plugins;
using ContextCompiler.Abstractions.Prompt;
using ContextCompiler.Abstractions.Views;

namespace ContextCompiler.Abstractions.Models
{
    public class Prompt : IPrompt
    {
        public string Global { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Summary { get; set; } = string.Empty;
        public string Domain { get; set; } = string.Empty;

        public IReadOnlyList<string> Audiences { get; set; } = new List<string>();
        public IReadOnlyList<string> Objectives { get; set; } = new List<string>();
        public IReadOnlyList<string> Assumptions { get; set; } = new List<string>();
        public IReadOnlyList<IMustConstraint> MustConstraints { get; set; } = new List<IMustConstraint>();
        public IReadOnlyList<IMustNotConstraint> MustNotConstraints { get; set; } = new List<IMustNotConstraint>();
        public IReadOnlyList<IPersonaResult> Personas { get; set; } = new List<IPersonaResult>();
        public IReadOnlyList<IViewResult> Views { get; set; } = new List<IViewResult>();
    }
}
