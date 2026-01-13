//using System.Text.RegularExpressions;

//using ContextCompiler.Abstractions.Pipelines.Document;
//using ContextCompiler.Abstractions.Plugins;

//namespace ContextCompiler.Plugins.BuiltIn.EngineeringModules;

//public sealed class BasicNormalizeModule(IDataEnvelopeBuilder dataEnvelopeBuilder) : IEngineeringModulePlugin
//{
//    public PluginMetadata Metadata => BuiltInMetadata.Meta("builtin.engineering.normalize", PluginKinds.EngineeringModule, priority: 0);

//    public Task<IDataEnvelope> ApplyAsync(IDataEnvelope envelope, CancellationToken ct)
//    {
//        ct.ThrowIfCancellationRequested();

//        foreach(var part in envelope.Parts)
//        {
//            if (part.Payload is string s)
//            {
//                s = s.Replace("\r\n", "\n");
//                s = Regex.Replace(s, "[ \t]{2,}", " ");
//                part.Payload = s;
//            }
//        }
//        if (envelope.Shape == DataShape.Linear && envelope.Payload is string s)
//        {
//            s = s.Replace("\r\n", "\n");
//            s = Regex.Replace(s, "[ \t]{2,}", " ");
//            return Task.FromResult(dataEnvelopeBuilder.InitNewFrom(envelope).WithPayload(s).Build());
//        }

//        return Task.FromResult(envelope);
//    }
//}
