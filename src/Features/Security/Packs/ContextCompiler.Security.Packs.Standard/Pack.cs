using System.Reflection;

using ContextCompiler.Modules.Abstractions.Loading;

namespace ContextCompiler.Security.Packs.Standard
{
    public class Pack : IPackModule
    {
        public IEnumerable<Assembly> Discover()
        {
            return
            [
                typeof(SecurityReportArtifactModule).Assembly,
                typeof(Modules.Guards.Email.EmailGuardModule).Assembly,
                typeof(Modules.Guards.DataPart.DataPartGuardModule).Assembly
            ];
        }
    }
}
