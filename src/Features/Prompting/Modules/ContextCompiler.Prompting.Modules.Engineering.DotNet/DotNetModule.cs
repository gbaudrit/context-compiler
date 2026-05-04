using ContextCompiler.Abstractions.Common;
using ContextCompiler.Abstractions.Configuration;
using ContextCompiler.Abstractions.Pipelines;
using ContextCompiler.Modules.Abstractions;
using ContextCompiler.Modules.Abstractions.GlobalPipeline;
using ContextCompiler.Prompting.Abstractions.Commands;
using ContextCompiler.Prompting.Abstractions.Prompt;

using Microsoft.Extensions.Logging;

namespace ContextCompiler.Prompting.Modules.Engineering.DotNet;

public sealed class DotNetModule(IConfigProvider cfgProvider,
                                        ICommandsProvider commandsProvider,
                                        ICommandBuilder commandBuilder,
                                        ILogger<DotNetModule> logger) : IConfigurationModule
{
    public ModuleMetadata Metadata => IGlobalPipelineModule.Meta("engineering.dotnet", GlobalPipelineModuleKinds.Setup, priority: 10);

    public Task<IResult<IGlobalPipelineRunResult>> Run(IGlobalPipelineRunContext context, CancellationToken cancellationToken)
    {
        cfgProvider.Current.AddFile(["Directory.Packages.props", "**/*.csproj", "**/libman.json", "**/package.json"], [], [], ["concern:dependency", "concern:security"], null);
        cfgProvider.Current.AddFile(["**/appsettings*.json"], [], [], ["concern:config", "concern:security"], null);

        cfgProvider.Current.AddView("dependency", "Dependencies", ["concern:dependency"], [], [], ["yaml", "index.json"]);

        commandsProvider.AddCommand(commandBuilder.InitNew()
                                    .WithName("dotnet dependencies list")
                                    .WithDescription("list all dependencies using view.dependency.yaml")
                                    .Build());

        commandsProvider.AddCommand(commandBuilder.InitNew()
                                    .WithName("dotnet dependencies graph")
                                    .WithDescription("generate textual graph with all dependencies using view.dependency.yaml")
                                    .Build());



        return context.Success();
    }
}

//public sealed class PdfFileReader(ICtxcConfigProvider cfgProvider, IDataEnvelopeBuilder dataEnvelopeBuilder, IDataPartBuilder dataPartBuilder, ITagsBuilder tagsBuilder) : IFileReader
//{
//    private PdfFileContent? _pdfFileContent;
//    private bool disposedValue;

//    public ValueTask<IFileContent> ReadAsync(string path, CancellationToken ct)
//    {
//        ct.ThrowIfCancellationRequested();
//        _pdfFileContent = new PdfFileContent
//        {
//            Document = PdfDocument.Open(path)
//        };
//        return ValueTask.FromResult<IFileContent>(_pdfFileContent);
//    }



//    private void Dispose(bool disposing)
//    {
//        if (!disposedValue)
//        {
//            if (disposing)
//            {
//                _pdfFileContent?.Dispose();
//            }

//            _pdfFileContent = null;
//            disposedValue = true;
//        }
//    }

//    // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
//    // ~PdfFileReader()
//    // {
//    //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
//    //     Dispose(disposing: false);
//    // }

//    public void Dispose()
//    {
//        // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
//        Dispose(disposing: true);
//        GC.SuppressFinalize(this);
//    }
//}
