using ContextCompiler.Abstractions.Compilation;
using ContextCompiler.Abstractions.Configuration;
using ContextCompiler.Abstractions.Configuration.Sections;

namespace ContextCompiler.Core.Compilation;

internal class CompilationContext(IConfigProvider configProvider, IInputFilesDefinitionBuilder inputFilesDefinitionBuilder) : ICompilationContext
{
    public ICompilationContext Add(Action<IInputFilesDefinitionBuilder> build)
    {
        IRootConfigSection rootConfig = configProvider.Current;

        build(inputFilesDefinitionBuilder.InitNew());

        IInputFilesDefinition inputFiles = inputFilesDefinitionBuilder.Build();

        rootConfig.AddFile(inputFiles.Includes, inputFiles.Excludes, [], inputFiles.Tags, null);

        return this;
    }
}
