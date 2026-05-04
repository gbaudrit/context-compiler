using ContextCompiler.Abstractions.Common;
using ContextCompiler.Abstractions.Pipelines.DataPart;
using ContextCompiler.Abstractions.Pipelines.Document;
using ContextCompiler.Modules.Abstractions;

using Microsoft.Extensions.Logging;

using MimeKit;

namespace ContextCompiler.Readers.Modules.Eml;

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

    public async Task<IResult<IDocumentPipelineRunResult>> Run(IDocumentPipelineRunContext context, CancellationToken ct)
    {
        ct.ThrowIfCancellationRequested();

        logger.LogInformation("Reading EML file: {Path}", context.Document.FullPath);

        await using FileStream stream = File.OpenRead(context.Document.FullPath);
        MimeMessage message = await MimeMessage.LoadAsync(stream, ct);
        List<IDataPart> parts = [];

        AddTextPart(parts, context.Document, "subject", "Subject", message.Subject, DataPartType.Text);
        AddTextPart(parts, context.Document, "message-id", "Message-Id", message.MessageId, DataPartType.Metadata);
        AddTextPart(parts, context.Document, "in-reply-to", "In-Reply-To", message.InReplyTo, DataPartType.Metadata);
        AddTextPart(parts, context.Document, "date", "Date", message.Date == default ? null : message.Date.ToString("O"), DataPartType.Metadata);
        AddEmailAddresses(parts, context.Document, "from", "From", message.From.Mailboxes);
        AddEmailAddresses(parts, context.Document, "to", "To", message.To.Mailboxes);
        AddEmailAddresses(parts, context.Document, "cc", "Cc", message.Cc.Mailboxes);
        AddEmailAddresses(parts, context.Document, "bcc", "Bcc", message.Bcc.Mailboxes);
        AddEmailAddresses(parts, context.Document, "reply-to", "Reply-To", message.ReplyTo.Mailboxes);
        AddTextPart(parts, context.Document, "text-body", "Text Body", NormalizeBody(message.TextBody), DataPartType.Text);
        AddTextPart(parts, context.Document, "html-body", "Html Body", NormalizeBody(message.HtmlBody), DataPartType.Text);

        int attachmentIndex = 0;
        foreach (MimeEntity attachment in message.Attachments)
        {
            string attachmentPayload = FormatAttachmentPayload(attachment);

            AddTextPart(parts,
                        context.Document,
                        $"attachment-{attachmentIndex}",
                        $"Attachment {attachmentIndex + 1}",
                        attachmentPayload,
                        DataPartType.Metadata,
                        $"attachment:{attachmentIndex}");
            attachmentIndex++;
        }

        return await context.Patch(b => b.WithDataEnvelope(dataEnvelopeBuilder.InitNew()
                                  .WithDataShape(DataShape.Linear)
                                  .WithParts(parts)
                                  .Build()))
                      .Success();
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
