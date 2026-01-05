using System;
using System.Collections.Generic;
using System.Text;

using ContextCompiler.Abstractions.Plugins;

namespace ContextCompiler.Abstractions.Models
{
    public class Prompt
    {
        public string Global { get; set; } = string.Empty;
        public string Personas { get; set; } = string.Empty;
        public List<ViewResult> Views { get; set; } = new();
    }
}
