using ContextCompiler.Abstractions.Common;
using ContextCompiler.Abstractions.Pipelines.DataPart;
using ContextCompiler.Abstractions.Pipelines.Document;
using ContextCompiler.Modules.Abstractions;

using Microsoft.Extensions.Logging;

using MimeKit;

namespace ContextCompiler.Modules.Readers.Eml;

public sealed class EmlFileReaderModule(
    IDataEnvelopeBuilder dataEnvelopeBuilder,
    IDataPartBuilder dataPartBuilder,
    ISourceRefBuilder sourceRefBuilder,
    ILogger<EmlFileReaderModule> logger) : IFileReaderModule
{
    public DocumentModuleMetadata Metadata => IDocumentPipelineModule.Meta("readers.eml", DocumentPipelineModuleKinds.ReadDocument, priority: 12);

    public bool CanProcess(IDocumentContext documentContext)
    {
        return Path.GetExtension(documentContext.FullPath).Equals(".eml", StringComparison.OrdinalIgnoreCase);
    }

    public async Task<IDocumentContextPatch> Run(IDocumentContext documentContext, IDocumentContextPatchBuilder patcher, CancellationToken ct)
    {
        ct.ThrowIfCancellationRequested();

        logger.LogInformation("Reading EML file: {Path}", documentContext.FullPath);

        await using FileStream stream = File.OpenRead(documentContext.FullPath);
        MimeMessage message = await MimeMessage.LoadAsync(stream, ct);
        List<IDataPart> parts = [];

        AddTextPart(parts, documentContext, "subject", "Subject", message.Subject, DataPartType.Text);
        AddTextPart(parts, documentContext, "message-id", "Message-Id", message.MessageId, DataPartType.Metadata);
        AddTextPart(parts, documentContext, "in-reply-to", "In-Reply-To", message.InReplyTo, DataPartType.Metadata);
        AddTextPart(parts, documentContext, "date", "Date", message.Date == default ? null : message.Date.ToString("O"), DataPartType.Metadata);
        AddEmailAddresses(parts, documentContext, "from", "From", message.From.Mailboxes);
        AddEmailAddresses(parts, documentContext, "to", "To", message.To.Mailboxes);
        AddEmailAddresses(parts, documentContext, "cc", "Cc", message.Cc.Mailboxes);
        AddEmailAddresses(parts, documentContext, "bcc", "Bcc", message.Bcc.Mailboxes);
        AddEmailAddresses(parts, documentContext, "reply-to", "Reply-To", message.ReplyTo.Mailboxes);
        AddTextPart(parts, documentContext, "text-body", "Text Body", NormalizeBody(message.TextBody), DataPartType.Text);
        AddTextPart(parts, documentContext, "html-body", "Html Body", NormalizeBody(message.HtmlBody), DataPartType.Text);

        int attachmentIndex = 0;
        foreach (MimeEntity attachment in message.Attachments)
        {
            string attachmentPayload = FormatAttachmentPayload(attachment);

            AddTextPart(parts,
                        documentContext,
                        $"attachment-{attachmentIndex}",
                        $"Attachment {attachmentIndex + 1}",
                        attachmentPayload,
                        DataPartType.Metadata,
                        $"attachment:{attachmentIndex}");
            attachmentIndex++;
        }

        return patcher.WithDataEnvelope(dataEnvelopeBuilder.InitNew()
                                  .WithDataShape(DataShape.Linear)
                                  .WithParts(parts)
                                  .Build()).Build();
    }

    private static string FormatAttachmentPayload(MimeEntity entity)
    {
        string? fileName = entity switch
        {
            MessagePart => null,
            MimePart mimePart => mimePart.FileName,
            _ => entity.ContentDisposition?.FileName
        };

        bool isEmbeddedMessage = entity is MessagePart;

        return $"FileName: {fileName ?? "(none)"}{Environment.NewLine}" +
               $"ContentType: {entity.ContentType.MimeType}{Environment.NewLine}" +
               $"IsEmbeddedMessage: {isEmbeddedMessage}";
    }

    private static string? NormalizeBody(string? body)
    {
        return string.IsNullOrWhiteSpace(body) ? null : body.Trim();
    }

    private void AddTextPart(List<IDataPart> parts,
                             IDocumentContext documentContext,
                             string id,
                             string label,
                             string? payload,
                             DataPartType type,
                             string? locator = null,
                             string? groupId = null)
    {
        if (string.IsNullOrWhiteSpace(payload))
        {
            return;
        }

        parts.Add(dataPartBuilder.InitNew()
                                 .WithId(id)
                                 .WithLabel(label)
                                 .WithType(type)
                                 .WithSource(sourceRefBuilder.InitNew()
                                                             .WithPath(documentContext.FullPath)
                                                             .WithLocator(locator ?? id)
                                                             .Build())
                                 .WithPayload(payload)
                                 .WithTags(documentContext.Data.Tags)
                                 .WithGroupId(groupId)
                                 .Build());
    }

    private void AddEmailAddresses(List<IDataPart> parts,
                                   IDocumentContext documentContext,
                                   string idPrefix,
                                   string labelPrefix,
                                   IEnumerable<MailboxAddress> mailboxes)
    {
        int index = 0;
        foreach (MailboxAddress mailbox in mailboxes)
        {
            string indexSuffix = index > 0 ? $"-{index}" : "";
            string groupId = $"{idPrefix}:{index}";

            // Add name as a separate part if present
            if (!string.IsNullOrWhiteSpace(mailbox.Name))
            {
                AddTextPart(parts,
                           documentContext,
                           $"{idPrefix}{indexSuffix}-name",
                           $"{labelPrefix} Name",
                           mailbox.Name,
                           DataPartType.PersonalDataName,
                           $"{idPrefix}:{index}:name",
                           groupId);
            }

            // Add email address as a separate part
            if (!string.IsNullOrWhiteSpace(mailbox.Address))
            {
                AddTextPart(parts,
                           documentContext,
                           $"{idPrefix}{indexSuffix}-email",
                           $"{labelPrefix} Email",
                           mailbox.Address,
                           DataPartType.PersonalDataEmail,
                           $"{idPrefix}:{index}:email",
                           groupId);
            }

            index++;
        }
    }
}
