using ContextCompiler.Abstractions.Compilation;
using ContextCompiler.Abstractions.Configuration;
using ContextCompiler.Abstractions.Configuration.Sections;

namespace ContextCompiler.Core.Compilation;

internal sealed class CompilationContext(IConfigProvider configProvider, ISourceFilesDefinitionBuilder inputFilesDefinitionBuilder) : ICompilationContext
{
    public ICompilationContext Add(Func<ISourceFilesDefinitionBuilder, ISourceFilesDefinitionBuilder> build)
    {
        IRootConfigSection rootConfig = configProvider.Current;

        _ = build(inputFilesDefinitionBuilder.InitNew());

        IInputFilesDefinition inputFiles = inputFilesDefinitionBuilder.Build();

        rootConfig.AddFile(inputFiles.Includes, inputFiles.Excludes, [], inputFiles.Tags, null);

        return this;
    }
}
