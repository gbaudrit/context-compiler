using System.Text.RegularExpressions;

using ContextCompiler.Abstractions.Common;
using ContextCompiler.Abstractions.Models;
using ContextCompiler.Abstractions.Pipelines.Document;
using ContextCompiler.Modules.Abstractions;

namespace ContextCompiler.Modules.Security.Guards.Email;

public sealed partial class EmailGuardModule(
    IDataEnvelopeBuilder dataEnvelopeBuilder,
    IDataPartBuilder dataPartBuilder,
    ISourceRefBuilder sourceRefBuilder) : IDocumentPipelineModule
{
    public DocumentModuleMetadata Metadata => IDocumentPipelineModule.Meta("security.guard.email", DocumentPipelineModuleKinds.ReadScopeGuards, priority: 5);
    //public DocumentStage Stage => DocumentStage.ContentGuards;

    private static readonly Regex Email = EmailPattern();

    public bool CanProcess(IDocumentContext documentContext)
    {
        return true;
    }

    public Task<IResult<IDocumentPipelineRunResult>> Run(IDocumentPipelineRunContext context, CancellationToken ct)
    {
        ct.ThrowIfCancellationRequested();

        if (context.Document.Data.DataEnvelope is null)
        {
            return context.NothingToDo();
        }

        List<IDataPart> updatedParts = [];

        foreach (IDataPart part in context.Document.Data.DataEnvelope.Parts)
        {
            string payload = part.Payload?.ToString() ?? string.Empty;
            MatchCollection matches = Email.Matches(payload);

            if (matches.Count == 0)
            {
                updatedParts.Add(part);
                continue;
            }

            string obfuscatedPayload = Email.Replace(payload, static match => ObfuscateEmail(match.Value));
            updatedParts.Add(CreatePart(part, obfuscatedPayload));

            context.AddFinding(FindingSeverity.Warning,
                               FindingAction.Redact,
                               "CtxGuard.Email",
                               $"Obfuscated {matches.Count} email address(es) in part '{part.PartId}'.",
                               CreateEvidenceRef(part.Source));
        }

        IDataEnvelopeBuilder builder = dataEnvelopeBuilder.InitNew()
                                                          .WithDataShape(context.Document.Data.DataEnvelope.Shape)
                                                          .WithParts(updatedParts);

        if (context.Document.Data.DataEnvelope.Metadata is not null)
        {
            _ = builder.WithMetadata(context.Document.Data.DataEnvelope.Metadata);
        }

        return context.Patch(b => b.WithDataEnvelope(builder.Build()))
                      .Success();
    }

    private IDataPart CreatePart(IDataPart part, string payload)
    {
        IDataPartBuilder builder = dataPartBuilder.InitNew()
                                                 .WithId(part.PartId)
                                                 .WithSource(part.Source)
                                                 .WithLabel(part.Label)
                                                 .WithPayload(payload);

        if (part.Tags is not null)
        {
            _ = builder.WithTags(part.Tags);
        }

        return builder.Build();
    }

    private ISourceRef CreateEvidenceRef(ISourceRef source)
    {
        ISourceRefBuilder builder = sourceRefBuilder.InitNew()
                                                    .WithPath(source.Path);

        if (!string.IsNullOrWhiteSpace(source.Locator))
        {
            _ = builder.WithLocator(source.Locator);
        }

        return builder.Build();
    }

    private static string ObfuscateEmail(string email)
    {
        int atIndex = email.IndexOf('@');
        if (atIndex <= 0 || atIndex == email.Length - 1)
        {
            return "***@***";
        }

        string local = email[..atIndex];
        string domain = email[(atIndex + 1)..];

        string obfuscatedLocal = local.Length switch
        {
            0 => "***",
            1 => $"{local[0]}***",
            2 => $"{local[0]}***{local[^1]}",
            _ => $"{local[0]}***{local[^1]}"
        };

        return $"{obfuscatedLocal}@{ObfuscateDomain(domain)}";
    }

    private static string ObfuscateDomain(string domain)
    {
        string[] segments = domain.Split('.', StringSplitOptions.RemoveEmptyEntries);
        if (segments.Length == 0)
        {
            return "***";
        }

        for (int i = 0; i < segments.Length - 1; i++)
        {
            segments[i] = segments[i].Length switch
            {
                0 => "***",
                1 => $"{segments[i][0]}***",
                _ => $"{segments[i][0]}***{segments[i][^1]}"
            };
        }

        return string.Join('.', segments);
    }

    [GeneratedRegex(@"[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,}", RegexOptions.IgnoreCase | RegexOptions.Compiled, "fr-FR")]
    private static partial Regex EmailPattern();
}
