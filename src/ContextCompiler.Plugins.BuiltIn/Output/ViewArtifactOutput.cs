using ContextCompiler.Abstractions.Output;
using ContextCompiler.Abstractions.Views;

namespace ContextCompiler.Plugins.BuiltIn.Output
{
    internal sealed class ViewArtifactOutput : IOutputArtifactCreator<IViewResult>
    {
        public IOutputArtifact Create(IViewResult input)
        {
            throw new NotImplementedException();
        }
    }
}
