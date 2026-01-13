using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Extensions.DependencyInjection;

namespace ContextCompiler.Abstractions.Plugins
{
    public interface IPluginRegistration
    {
        IServiceCollection RegisterServices(IServiceCollection services);
    }
}
