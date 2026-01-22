using System;
using System.Collections.Generic;
using System.Text;

namespace ContextCompiler.Abstractions.Configuration
{
    public interface ICtxcConfig
    {
        ContextConfig Context { get; set; }
        List<FileConfig> Files { get; set; }
        PersonasConfig? Personas { get; set; }
        ViewsConfig Views { get; set; }
        List<string> Renderers { get; set; }
    }
}
