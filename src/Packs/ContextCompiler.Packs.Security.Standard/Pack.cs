using System.Reflection;

using ContextCompiler.Modules.Abstractions.Loading;

namespace ContextCompiler.Packs.Security.Standard
{
    public class Pack : IPackModule
    {
        public IEnumerable<Assembly> Discover()
        {
            return
            [
                typeof(Modules.Security.SecurityReportArtifactModule).Assembly,
                typeof(Modules.Security.Guards.Email.EmailGuardModule).Assembly,
                typeof(Modules.Security.Guards.DataPart.DataPartGuardModule).Assembly
            ];
        }
    }
}
