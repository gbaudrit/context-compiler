using System.Threading;
using ContextCompiler.Abstractions.Configuration;
using ContextCompiler.Abstractions.Models;
using ContextCompiler.Core.Pipelines;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ContextCompiler.Core.Tests.Pipeline;

[TestClass]
public class CompositeEnvelopePipelineTests
{
    private sealed class DummyFs : ContextCompiler.Abstractions.Ports.IFileSystem
    {
        public IEnumerable<string> EnumerateFiles(string rootPath) => new[] { "/workspace/file.xlsx" };
        public bool FileExists(string path) => true;
        public string ReadAllText(string path) => string.Empty;
        public byte[] ReadAllBytes(string path) => Array.Empty<byte>();
        public void WriteAllText(string path, string content) { }
        public void WriteAllBytes(string path, byte[] bytes) { }
        public void EnsureDirectory(string path) { }
    }

    private sealed class DummyHasher : ContextCompiler.Abstractions.Ports.IHasher
    {
        public string Sha256Hex(string input) => new string('a', 64);
        public string SimHashHex(string input) => new string('b', 16);
    }

    private sealed class DummyPlugins : ContextCompiler.Core.Pipelines.IPluginRegistry
    {
        public IReadOnlyList<ContextCompiler.Abstractions.Plugins.IFileReaderPlugin> FileReaders => new[] { new DummyFileReader() };
        public IReadOnlyList<ContextCompiler.Abstractions.Plugins.IDataReaderPlugin> DataReaders => new[] { new DummyDataReader() };
        public IReadOnlyList<ContextCompiler.Abstractions.Plugins.IEngineeringModulePlugin> EngineeringModules => Array.Empty<ContextCompiler.Abstractions.Plugins.IEngineeringModulePlugin>();
        public IReadOnlyList<ContextCompiler.Abstractions.Plugins.ITranscoderPlugin> Transcoders => new[] { new DummyTranscoder() };
        public IReadOnlyList<ContextCompiler.Abstractions.Plugins.IGuardPlugin> Guards => Array.Empty<ContextCompiler.Abstractions.Plugins.IGuardPlugin>();
        public IReadOnlyList<ContextCompiler.Abstractions.Plugins.IViewPlugin> Views => Array.Empty<ContextCompiler.Abstractions.Plugins.IViewPlugin>();
        public IReadOnlyList<ContextCompiler.Abstractions.Plugins.ITemplatePlugin> Templates => Array.Empty<ContextCompiler.Abstractions.Plugins.ITemplatePlugin>();
        public IReadOnlyList<ContextCompiler.Abstractions.Plugins.IGraphExporterPlugin> GraphExporters => Array.Empty<ContextCompiler.Abstractions.Plugins.IGraphExporterPlugin>();
    }

    private sealed class DummyFileReader : ContextCompiler.Abstractions.Plugins.IFileReaderPlugin
    {
        public ContextCompiler.Abstractions.Plugins.PluginMetadata Metadata => ContextCompiler.Plugins.BuiltIn.BuiltInMetadata.Meta("dummy.file", ContextCompiler.Abstractions.Plugins.PluginKinds.FileReader);
        public bool CanRead(string path) => path.EndsWith(".xlsx");
        public Task<DocumentContent> ReadAsync(string path, CancellationToken ct) => Task.FromResult(new DocumentContent(path, "application/x", Array.Empty<byte>()));
    }

    private sealed class DummyDataReader : ContextCompiler.Abstractions.Plugins.IDataReaderPlugin
    {
        public ContextCompiler.Abstractions.Plugins.PluginMetadata Metadata => ContextCompiler.Plugins.BuiltIn.BuiltInMetadata.Meta("dummy.data", ContextCompiler.Abstractions.Plugins.PluginKinds.DataReader);
        public bool CanRead(DocumentContent doc) => true;
        public Task<DataEnvelope> ReadAsync(DocumentContent doc, CancellationToken ct)
        {
            var part = new DataPart("extractA", new SourceRef(doc.Path, "extract:extractA/sheet:Sheet1"), new DataEnvelope(DataShape.Linear, new { text = "hello" }));
            var composite = new CompositeDataEnvelope(new[] { part });
            return Task.FromResult(new DataEnvelope(DataShape.Composite, composite));
        }
    }

    private sealed class DummyTranscoder : ContextCompiler.Abstractions.Plugins.ITranscoderPlugin
    {
        public ContextCompiler.Abstractions.Plugins.PluginMetadata Metadata => ContextCompiler.Plugins.BuiltIn.BuiltInMetadata.Meta("dummy.transcoder", ContextCompiler.Abstractions.Plugins.PluginKinds.Transcoder);
        public bool CanTranscode(DataEnvelope envelope) => true;
        public Task<IReadOnlyList<TranscodedFragment>> TranscodeAsync(DataEnvelope envelope, SourceRef source, CancellationToken ct)
        {
            return Task.FromResult<IReadOnlyList<TranscodedFragment>>(new[] { new TranscodedFragment("row:0", "content", new Dictionary<string,string>()) });
        }
    }

    [TestMethod]
    public async Task Pipeline_Handles_Composite_Parts()
    {
        var runner = new DocumentPipelineRunner(new NullLogger<DocumentPipelineRunner>(), new DummyFs(), new DummyHasher(), new DummyPlugins(), new CtxcConfig());
        var results = await runner.RunAsync("/workspace", CancellationToken.None);
        Assert.AreEqual(1, results.Count);
        Assert.AreEqual("/workspace/file.xlsx", results[0].Path);
        Assert.AreEqual(1, results[0].Fragments.Count);
        Assert.IsTrue(results[0].Fragments[0].Source.Locator!.StartsWith("extract:extractA"));
        Assert.AreEqual("content", results[0].Fragments[0].Content);
    }
}
